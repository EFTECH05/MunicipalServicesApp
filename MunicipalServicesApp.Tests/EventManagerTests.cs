
using System;
using System.Collections.Generic;
using Xunit;
using MunicipalServicesApp;

namespace MunicipalServicesApp.Tests
{
    public class EventManagerTests
    {
        private List<Event> CreateSampleEvents()
        {
            return new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Community Cleanup",
                    Category = "Environment",
                    EventDate = DateTime.Today.AddDays(1),
                    Location = "Cape Town",
                    Description = "Community cleanup event",
                    EventType = "Community",
                    CreatedAt = DateTime.Now
                },
                new Event
                {
                    Id = 2,
                    Title = "Coding Workshop",
                    Category = "Education",
                    EventDate = DateTime.Today.AddDays(2),
                    Location = "Cape Town",
                    Description = "Coding workshop for residents",
                    EventType = "Workshop",
                    CreatedAt = DateTime.Now
                },
                new Event
                {
                    Id = 3,
                    Title = "Tree Planting",
                    Category = "Environment",
                    EventDate = DateTime.Today.AddDays(3),
                    Location = "Cape Town",
                    Description = "Tree planting activity",
                    EventType = "Community",
                    CreatedAt = DateTime.Now
                },
                new Event
                {
                    Id = 4,
                    Title = "Football Tournament",
                    Category = "Sports",
                    EventDate = DateTime.Today.AddDays(4),
                    Location = "Cape Town",
                    Description = "Community football tournament",
                    EventType = "Sports",
                    CreatedAt = DateTime.Now
                }
            };
        }

        private EventManager CreateEventManager()
        {
            return new EventManager(CreateSampleEvents());
        }

        // ---------------------------------------------------------
        // GET CATEGORIES TESTS
        // ---------------------------------------------------------

        [Fact]
        public void GetCategories_ReturnsUniqueCategories()
        {
            var manager = CreateEventManager();

            var categories = manager.GetCategories();

            Assert.Equal(3, categories.Count);
            Assert.Contains("Environment", categories);
            Assert.Contains("Education", categories);
            Assert.Contains("Sports", categories);
        }

        // ---------------------------------------------------------
        // SEARCH EVENTS TESTS
        // ---------------------------------------------------------

        [Fact]
        public void SearchEvents_FiltersEventsByCategory()
        {
            var manager = CreateEventManager();

            var results = manager.SearchEvents(
                "Environment", null, null);

            Assert.Equal(2, results.Count);

            Assert.All(results, ev =>
                Assert.Equal("Environment", ev.Category));
        }

        [Fact]
        public void SearchEvents_CategorySearchIsCaseInsensitive()
        {
            var manager = CreateEventManager();

            var results = manager.SearchEvents(
                "environment", null, null);

            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void SearchEvents_ReturnsEmptyWhenCategoryDoesNotExist()
        {
            var manager = CreateEventManager();

            var results = manager.SearchEvents(
                "Unknown", null, null);

            Assert.Empty(results);
        }

        [Fact]
        public void SearchEvents_ReturnsEventsInDateOrder()
        {
            var manager = CreateEventManager();

            var results = manager.SearchEvents(
                "All Categories", null, null);

            Assert.Equal(4, results.Count);

            for (int i = 1; i < results.Count; i++)
            {
                Assert.True(
                    results[i - 1].EventDate <= results[i].EventDate);
            }
        }

        [Fact]
        public void SearchEvents_RespectsDateRange()
        {
            var manager = CreateEventManager();

            DateTime startDate = DateTime.Today.AddDays(2);
            DateTime endDate = DateTime.Today.AddDays(3);

            var results = manager.SearchEvents(
                "All Categories", startDate, endDate);

            Assert.Equal(2, results.Count);

            Assert.All(results, ev =>
            {
                Assert.True(ev.EventDate >= startDate);
                Assert.True(ev.EventDate <= endDate);
            });
        }

        [Fact]
        public void SearchEvents_RecordsCategorySearchCount()
        {
            var manager = CreateEventManager();

            manager.SearchEvents("Environment", null, null);
            manager.SearchEvents("Environment", null, null);

            var counts = manager.GetCategorySearchCounts();

            Assert.Equal(2, counts["Environment"]);
        }

        // ---------------------------------------------------------
        // GET RECENT SEARCHES TESTS
        // ---------------------------------------------------------

        [Fact]
        public void GetRecentSearches_ReturnsMostRecentSearchFirst()
        {
            var manager = CreateEventManager();

            manager.SearchEvents("Environment", null, null);
            manager.SearchEvents("Education", null, null);

            var recent = manager.GetRecentSearches(2);

            Assert.Equal(2, recent.Count);
            Assert.StartsWith("Education", recent[0]);
            Assert.StartsWith("Environment", recent[1]);
        }

        [Fact]
        public void GetRecentSearches_ReturnsEmptyWhenNoSearchesExist()
        {
            var manager = CreateEventManager();

            var results = manager.GetRecentSearches(10);

            Assert.Empty(results);
        }

        [Fact]
        public void GetRecentSearches_ReturnsEmptyForZeroCount()
        {
            var manager = CreateEventManager();

            manager.SearchEvents("Environment", null, null);

            var results = manager.GetRecentSearches(0);

            Assert.Empty(results);
        }

        [Fact]
        public void GetRecentSearches_ReturnsOnlyRequestedNumberOfSearches()
        {
            var manager = CreateEventManager();

            manager.SearchEvents("Environment", null, null);
            manager.SearchEvents("Education", null, null);
            manager.SearchEvents("Sports", null, null);

            var results = manager.GetRecentSearches(2);

            Assert.Equal(2, results.Count);
        }

        // ---------------------------------------------------------
        // PROCESS NEXT SEARCH TESTS
        // ---------------------------------------------------------

        [Fact]
        public void ProcessNextSearch_ReturnsNullWhenQueueIsEmpty()
        {
            var manager = CreateEventManager();

            var result = manager.ProcessNextSearch();

            Assert.Null(result);
        }

        [Fact]
        public void ProcessNextSearch_ReturnsQueuedSearch()
        {
            var manager = CreateEventManager();

            manager.SearchEvents("Environment", null, null);

            var result = manager.ProcessNextSearch();

            Assert.Equal("Environment", result);
        }

        // ---------------------------------------------------------
        // RECOMMENDED EVENTS TESTS
        // ---------------------------------------------------------

        [Fact]
        public void GetRecommendedEvents_ReturnsRequestedNumber()
        {
            var manager = CreateEventManager();

            var results = manager.GetRecommendedEvents(2);

            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetRecommendedEvents_ReturnsEmptyForZeroCount()
        {
            var manager = CreateEventManager();

            var results = manager.GetRecommendedEvents(0);

            Assert.Empty(results);
        }

        // ---------------------------------------------------------
        // FILTER EVENTS TESTS
        // ---------------------------------------------------------

        [Fact]
        public void FilterEventsWithoutRecording_DoesNotAddSearchHistory()
        {
            var manager = CreateEventManager();

            manager.FilterEventsWithoutRecording(
                "Environment", null, null);

            var recent = manager.GetRecentSearches(10);

            Assert.Empty(recent);
        }

        // ---------------------------------------------------------
        // CONSTRUCTOR TESTS
        // ---------------------------------------------------------

        [Fact]
        public void Constructor_ThrowsExceptionWhenEventsAreNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new EventManager(
                    (IEnumerable<Event>)null!));
        }

        // ---------------------------------------------------------
        // GET NEXT UPCOMING EVENT TESTS
        // ---------------------------------------------------------

        [Fact]
        public void GetNextUpcomingEvent_ReturnsNullWhenNoEventsExist()
        {
            var manager = new EventManager(new List<Event>());

            var result = manager.GetNextUpcomingEvent();

            Assert.Null(result);
        }

        [Fact]
        public void GetNextUpcomingEvent_ReturnsNullWhenAllEventsAreInThePast()
        {
            var pastEvent = new Event
            {
                Id = 101,
                Title = "Past Event",
                Category = "Education",
                EventDate = DateTime.Now.AddDays(-2),
                Location = "Cape Town",
                Description = "An event that has already passed",
                EventType = "Event",
                CreatedAt = DateTime.Now.AddDays(-5)
            };

            var manager = new EventManager(
                new List<Event> { pastEvent });

            var result = manager.GetNextUpcomingEvent();

            Assert.Null(result);
        }

        [Fact]
        public void GetNextUpcomingEvent_ReturnsEarliestUpcomingEvent()
        {
            var laterEvent = new Event
            {
                Id = 102,
                Title = "Later Event",
                Category = "Sports",
                EventDate = DateTime.Now.AddDays(3),
                Location = "Cape Town",
                Description = "A later event",
                EventType = "Event",
                CreatedAt = DateTime.Now
            };

            var earlierEvent = new Event
            {
                Id = 103,
                Title = "Earlier Event",
                Category = "Education",
                EventDate = DateTime.Now.AddDays(1),
                Location = "Cape Town",
                Description = "The next upcoming event",
                EventType = "Event",
                CreatedAt = DateTime.Now
            };

            var manager = new EventManager(
                new List<Event>
                {
                    laterEvent,
                    earlierEvent
                });

            var result = manager.GetNextUpcomingEvent();

            Assert.NotNull(result);
            Assert.Same(earlierEvent, result);
        }
    }
}
