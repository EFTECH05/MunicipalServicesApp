
using System;

namespace MunicipalServicesApp
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string EventType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
