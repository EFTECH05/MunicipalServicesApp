
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MunicipalServicesApp
{
    public class EventManager
    {
        private readonly string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        // Events grouped by date.
        private readonly SortedDictionary<DateTime, List<Event>> eventsByDate =
            new SortedDictionary<DateTime, List<Event>>();

        // Fast lookup of events by ID.
        private readonly Dictionary<int, Event> eventsById =
            new Dictionary<int, Event>();

        // Unique event categories.
        private readonly HashSet<string> categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Recent searches, newest first.
        private readonly Stack<string> recentSearches =
            new Stack<string>();

        // Searches waiting to be processed.
        private readonly Queue<string> searchQueue =
            new Queue<string>();

        // Upcoming events organised by date.
        private readonly SortedDictionary<DateTime, Queue<Event>> priorityQueue =
            new SortedDictionary<DateTime, Queue<Event>>();

        // Number of searches for each category.
        private readonly Dictionary<string, int> categorySearchCounts =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Normal constructor for the application.
        public EventManager()
        {
        }

        // Constructor for unit testing with sample events.
        public EventManager(IEnumerable<Event> events)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            foreach (Event ev in events)
            {
                if (ev == null)
                {
                    throw new ArgumentException(
                        "The event collection cannot contain null events.",
                        nameof(events));
                }

                AddEventToCollections(ev);
            }
        }

        // Add an event to the in-memory collections.
        private void AddEventToCollections(Event ev)
        {
            eventsById[ev.Id] = ev;

            if (!string.IsNullOrWhiteSpace(ev.Category))
            {
                categories.Add(ev.Category.Trim());
            }

            if (!eventsByDate.ContainsKey(ev.EventDate))
            {
                eventsByDate[ev.EventDate] = new List<Event>();
            }

            eventsByDate[ev.EventDate].Add(ev);

            if (ev.EventDate >= DateTime.Now)
            {
                if (!priorityQueue.ContainsKey(ev.EventDate))
                {
                    priorityQueue[ev.EventDate] = new Queue<Event>();
                }

                priorityQueue[ev.EventDate].Enqueue(ev);
            }
        }

        // ---------------------------------------------------------
        // LOAD EVENTS FROM SQL SERVER
        // ---------------------------------------------------------
        public void LoadEvents()
        {
            List<Event> loadedEvents = new List<Event>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "SELECT Id, Title, Category, EventDate, Location, " +
                    "Description, EventType, CreatedAt " +
                    "FROM dbo.Events";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event ev = new Event
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = Convert.ToString(reader["Title"]),
                            Category = Convert.ToString(reader["Category"]),
                            EventDate = Convert.ToDateTime(reader["EventDate"]),
                            Location = Convert.ToString(reader["Location"]),

                            Description =
                                reader["Description"] == DBNull.Value
                                    ? string.Empty
                                    : Convert.ToString(reader["Description"]),

                            EventType =
                                reader["EventType"] == DBNull.Value
                                    ? "Event"
                                    : Convert.ToString(reader["EventType"]),

                            CreatedAt =
                                reader["CreatedAt"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(reader["CreatedAt"])
                        };

                        loadedEvents.Add(ev);
                    }
                }
            }

            // Clear the event collections only after a successful load.
            eventsByDate.Clear();
            eventsById.Clear();
            categories.Clear();
            priorityQueue.Clear();

            foreach (Event ev in loadedEvents)
            {
                AddEventToCollections(ev);
            }
        }

        // ---------------------------------------------------------
        // GET CATEGORIES
        // ---------------------------------------------------------
        public List<string> GetCategories()
        {
            return categories
                .OrderBy(category => category)
                .ToList();
        }

        // ---------------------------------------------------------
        // SEARCH EVENTS BY CATEGORY AND DATE
        // ---------------------------------------------------------
        public List<Event> SearchEvents(
            string category,
            DateTime? startDate,
            DateTime? endDate)
        {
            string selectedCategory =
                string.IsNullOrWhiteSpace(category)
                    ? "All Categories"
                    : category.Trim();

            string searchDescription = selectedCategory;

            if (startDate.HasValue || endDate.HasValue)
            {
                searchDescription += " | " +
                    (startDate.HasValue
                        ? startDate.Value.ToString("dd MMM yyyy")
                        : "Any start date") +
                    " to " +
                    (endDate.HasValue
                        ? endDate.Value.ToString("dd MMM yyyy")
                        : "Any end date");
            }

            RecordSearch(searchDescription, selectedCategory);

            IEnumerable<Event> results = eventsById.Values;

            if (!selectedCategory.Equals(
                "All Categories",
                StringComparison.OrdinalIgnoreCase))
            {
                results = results.Where(ev =>
                    string.Equals(
                        ev.Category,
                        selectedCategory,
                        StringComparison.OrdinalIgnoreCase));
            }

            if (startDate.HasValue)
            {
                results = results.Where(ev =>
                    ev.EventDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                results = results.Where(ev =>
                    ev.EventDate <= endDate.Value);
            }

            return results
                .OrderBy(ev => ev.EventDate)
                .ToList();
        }

        // ---------------------------------------------------------
        // RECORD SEARCH HISTORY AND CATEGORY PREFERENCES
        // ---------------------------------------------------------
        private void RecordSearch(
            string searchDescription,
            string selectedCategory)
        {
            if (string.IsNullOrWhiteSpace(searchDescription))
            {
                return;
            }

            searchQueue.Enqueue(searchDescription);

            // Keep no more than 20 queued searches.
            while (searchQueue.Count > 20)
            {
                searchQueue.Dequeue();
            }

            List<string> items = recentSearches.ToList();

            // Keep searches unique in recent history.
            items.RemoveAll(item =>
                string.Equals(
                    item,
                    searchDescription,
                    StringComparison.OrdinalIgnoreCase));

            items.Insert(0, searchDescription);

            List<string> limitedItems = items
                .Take(10)
                .ToList();

            recentSearches.Clear();

            foreach (string item in limitedItems.AsEnumerable().Reverse())
            {
                recentSearches.Push(item);
            }

            // Count only searches for a specific category.
            if (!string.IsNullOrWhiteSpace(selectedCategory) &&
                !selectedCategory.Equals(
                    "All Categories",
                    StringComparison.OrdinalIgnoreCase))
            {
                if (!categorySearchCounts.ContainsKey(selectedCategory))
                {
                    categorySearchCounts[selectedCategory] = 0;
                }

                categorySearchCounts[selectedCategory]++;
            }
        }

        // ---------------------------------------------------------
        // GET RECOMMENDED UPCOMING EVENTS
        // ---------------------------------------------------------
        public List<Event> GetRecommendedEvents(int count)
        {
            if (count <= 0)
            {
                return new List<Event>();
            }

            DateTime now = DateTime.Now;

            IEnumerable<Event> upcoming = eventsById.Values
                .Where(ev => ev.EventDate >= now);

            return upcoming
                .OrderByDescending(ev =>
                    GetCategorySearchCount(ev.Category))
                .ThenBy(ev => ev.EventDate)
                .Take(count)
                .ToList();
        }

        private int GetCategorySearchCount(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return 0;
            }

            int searchCount;

            if (categorySearchCounts.TryGetValue(
                category,
                out searchCount))
            {
                return searchCount;
            }

            return 0;
        }

        // ---------------------------------------------------------
        // GET CATEGORY SEARCH COUNTS
        // ---------------------------------------------------------
        public Dictionary<string, int> GetCategorySearchCounts()
        {
            return new Dictionary<string, int>(
                categorySearchCounts,
                StringComparer.OrdinalIgnoreCase);
        }

        // ---------------------------------------------------------
        // GET THE NEXT UPCOMING EVENT
        // ---------------------------------------------------------
        public Event GetNextUpcomingEvent()
        {
            DateTime now = DateTime.Now;

            foreach (KeyValuePair<DateTime, Queue<Event>> entry
                in priorityQueue)
            {
                if (entry.Key < now)
                {
                    continue;
                }

                while (entry.Value.Count > 0)
                {
                    Event ev = entry.Value.Peek();

                    if (ev.EventDate >= now)
                    {
                        return ev;
                    }

                    entry.Value.Dequeue();
                }
            }

            return null;
        }

        // ---------------------------------------------------------
        // GET RECENT SEARCHES
        // ---------------------------------------------------------
        public List<string> GetRecentSearches(int count)
        {
            if (count <= 0)
            {
                return new List<string>();
            }

            return recentSearches
                .Take(count)
                .ToList();
        }

        // ---------------------------------------------------------
        // PROCESS NEXT QUEUED SEARCH
        // ---------------------------------------------------------
        public string ProcessNextSearch()
        {
            if (searchQueue.Count == 0)
            {
                return null;
            }

            return searchQueue.Dequeue();
        }

        // ---------------------------------------------------------
        // FILTER EVENTS WITHOUT RECORDING A SEARCH
        // ---------------------------------------------------------
        public List<Event> FilterEventsWithoutRecording(
            string category,
            DateTime? startDate,
            DateTime? endDate)
        {
            IEnumerable<Event> results = eventsById.Values;

            if (!string.IsNullOrWhiteSpace(category) &&
                !category.Equals(
                    "All Categories",
                    StringComparison.OrdinalIgnoreCase))
            {
                results = results.Where(ev =>
                    string.Equals(
                        ev.Category,
                        category.Trim(),
                        StringComparison.OrdinalIgnoreCase));
            }

            if (startDate.HasValue)
            {
                results = results.Where(ev =>
                    ev.EventDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                results = results.Where(ev =>
                    ev.EventDate <= endDate.Value);
            }

            return results
                .OrderBy(ev => ev.EventDate)
                .ToList();
        }

        // ---------------------------------------------------------
        // UPDATE AN EXISTING EVENT
        // ---------------------------------------------------------
        public void UpdateEvent(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentNullException(nameof(ev));
            }

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "UPDATE dbo.Events SET " +
                    "Title = @Title, " +
                    "Category = @Category, " +
                    "EventDate = @EventDate, " +
                    "Location = @Location, " +
                    "Description = @Description, " +
                    "EventType = @EventType " +
                    "WHERE Id = @Id";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Id", SqlDbType.Int).Value = ev.Id;

                    command.Parameters.Add(
                        "@Title", SqlDbType.NVarChar, 255).Value =
                        ev.Title ?? string.Empty;

                    command.Parameters.Add(
                        "@Category", SqlDbType.NVarChar, 100).Value =
                        ev.Category ?? string.Empty;

                    command.Parameters.Add(
                        "@EventDate", SqlDbType.DateTime).Value =
                        ev.EventDate;

                    command.Parameters.Add(
                        "@Location", SqlDbType.NVarChar, 255).Value =
                        ev.Location ?? string.Empty;

                    command.Parameters.Add(
                        "@Description", SqlDbType.NVarChar, -1).Value =
                        ev.Description ?? string.Empty;

                    command.Parameters.Add(
                        "@EventType", SqlDbType.NVarChar, 50).Value =
                        ev.EventType ?? "Event";

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException(
                            "The selected event was not found.");
                    }
                }
            }

            LoadEvents();
        }

        // ---------------------------------------------------------
        // DELETE AN EVENT
        // ---------------------------------------------------------
        public void DeleteEvent(int eventId)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "DELETE FROM dbo.Events WHERE Id = @Id";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Id", SqlDbType.Int).Value = eventId;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException(
                            "The selected event was not found.");
                    }
                }
            }

            LoadEvents();
        }
    }
}
