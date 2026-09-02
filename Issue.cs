namespace MunicipalServicesApp
{
    public class Issue
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Attachment { get; set; }

        public System.DateTime DateReported { get; set; }
    }
}