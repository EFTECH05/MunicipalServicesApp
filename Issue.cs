
using System;

namespace MunicipalServicesApp
{
    public class Issue
    {
        // ==========================================
        // EXISTING PART 1 PROPERTIES
        // ==========================================

        public int Id { get; set; }

        public string Location { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Attachment { get; set; }

        public DateTime DateReported { get; set; }


        // ==========================================
        // PART 3: SERVICE REQUEST TRACKING
        // ==========================================

        // Account that submitted the service request
        public int? AccountId { get; set; }

        // Current status of the request
        public string Status { get; set; } = "Received";

        // Priority: 1 = Critical, 2 = High,
        // 3 = Medium, 4 = Low
        public int Priority { get; set; } = 3;

        // Municipal department responsible
        public string Department { get; set; }

        // Date and time of the last update
        public DateTime LastUpdated { get; set; }


        // ==========================================
        // UNIQUE SERVICE REQUEST REFERENCE
        // ==========================================

        public string RequestReference
        {
            get
            {
                return "MSR-" + Id.ToString("D6");
            }
        }


        // ==========================================
        // PRIORITY DESCRIPTION
        // ==========================================

        public string PriorityName
        {
            get
            {
                switch (Priority)
                {
                    case 1:
                        return "Critical";

                    case 2:
                        return "High";

                    case 3:
                        return "Medium";

                    case 4:
                        return "Low";

                    default:
                        return "Unknown";
                }
            }
        }
    }
}
