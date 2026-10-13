
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

        private readonly SortedDictionary<DateTime, List<Event>> eventsByDate =
            new SortedDictionary<DateTime, List<Event>>();

        private readonly Dictionary<int, Event> eventsById =
            new Dictionary<int, Event>();

        private readonly HashSet<string> categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private readonly Stack<string> recentSearches =
            new Stack<string>();

        private readonly Queue<string> searchQueue =
            new Queue<string>();

        private readonly SortedDictionary<DateTime, Queue<Event>> priorityQueue =
            new SortedDictionary<DateTime, Queue<Event>>();

        private readonly Dictionary<string, int> categorySearchCounts =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Load events from SQL Server into the existing data structures.
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

                            Description = reader["Description"] == DBNull.Value
                                ? string.Empty
                                : Convert.ToString(reader["Description"]),

                            EventType = reader["EventType"] == DBNull.Value
                                ? "Event"
                                : Convert.ToString(reader["EventType"]),

                            CreatedAt = reader["CreatedAt"] == DBNull.Value
                                ? DateTime.MinValue
                                : Convert.ToDateTime(reader["CreatedAt"])
                        };

                        loadedEvents.Add(ev);
                    }
                }
            }

            // Clear existing in-memory event data after loading succeeds.
            eventsByDate.Clear();
            eventsById.Clear();
            categories.Clear();
            priorityQueue.Clear();

            foreach (Event ev in loadedEvents)
            {
                eventsById[ev.Id] = ev;

                if (!string.IsNullOrWhiteSpace(ev.Category))
                {
                    categories.Add(ev.Category);
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
                        priorityQueue[ev.EventDate] =
                            new Queue<Event>();
                    }

                    priorityQueue[ev.EventDate].Enqueue(ev);
                }
            }
        }

        // Search events by category and optional date range.
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

            RecordSearch(searchDescription);

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

        // Record searches without replacing the readonly Stack.
        private void RecordSearch(string searchDescription)
        {
            if (string.IsNullOrWhiteSpace(searchDescription))
                return;

            searchQueue.Enqueue(searchDescription);

            // Keep a maximum of 20 pending search descriptions.
            while (searchQueue.Count > 20)
            {
                searchQueue.Dequeue();
            }

            // Build an updated list of recent searches.
            List<string> items = recentSearches.ToList();

            // Remove duplicates so the latest search appears first.
            items.RemoveAll(item =>
                string.Equals(
                    item,
                    searchDescription,
                    StringComparison.OrdinalIgnoreCase));

            items.Insert(0, searchDescription);

            // Keep only the ten most recent searches.
            List<string> limitedItems = items
                .Take(10)
                .ToList();

            // Stack enumeration returns newest-first.
            // Clear and repopulate the same readonly Stack instance.
            recentSearches.Clear();

            foreach (string item in limitedItems.AsEnumerable().Reverse())
            {
                recentSearches.Push(item);
            }

            if (!categorySearchCounts.ContainsKey(searchDescription))
            {
                categorySearchCounts[searchDescription] = 0;
            }

            categorySearchCounts[searchDescription]++;
        }

        // Recommend upcoming events based on search activity.
        public List<Event> GetRecommendedEvents(int count)
        {
            if (count <= 0)
                return new List<Event>();

            HashSet<string> preferredCategories =
                categorySearchCounts
                    .OrderByDescending(pair => pair.Value)
                    .Take(5)
                    .Select(pair => pair.Key)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

            IEnumerable<Event> upcoming = eventsById.Values
                .Where(ev => ev.EventDate >= DateTime.Now)
                .OrderBy(ev => ev.EventDate);

            List<Event> preferred = upcoming
                .Where(ev => preferredCategories.Contains(ev.Category))
                .ToList();

            List<Event> otherUpcoming = upcoming
                .Where(ev => !preferredCategories.Contains(ev.Category))
                .ToList();

            return preferred
                .Concat(otherUpcoming)
                .Take(count)
                .ToList();
        }

        // Return category search counts.
        public Dictionary<string, int> GetCategorySearchCounts()
        {
            return new Dictionary<string, int>(
                categorySearchCounts,
                StringComparer.OrdinalIgnoreCase);
        }

        // Return the next upcoming event.
        public Event GetNextUpcomingEvent()
        {
            foreach (KeyValuePair<DateTime, Queue<Event>> entry
                in priorityQueue)
            {
                while (entry.Value.Count > 0)
                {
                    Event ev = entry.Value.Peek();

                    if (ev.EventDate >= DateTime.Now)
                        return ev;

                    entry.Value.Dequeue();
                }
            }

            return null;
        }

        // Return recent searches, newest first.
        public List<string> GetRecentSearches(int count)
        {
            if (count <= 0)
                return new List<string>();

            return recentSearches.Take(count).ToList();
        }

        // Process the next queued search.
        public string ProcessNextSearch()
        {
            if (searchQueue.Count == 0)
                return null;

            return searchQueue.Dequeue();
        }

        // Filter events without recording another search.
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
                        category,
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

        // Update an existing event or announcement in SQL Server.
        public void UpdateEvent(Event ev)
        {
            if (ev == null)
                throw new ArgumentNullException(nameof(ev));

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

            // Refresh the in-memory collections after a successful update.
            LoadEvents();
        }

        // Delete an event or announcement from SQL Server.
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

            // Refresh the in-memory collections after deletion.
            LoadEvents();
        }
    }
}
