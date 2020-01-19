using System;
namespace Interview.Data
{


    public class MainApp
    {
        public string Id { get; set; }
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public float Amount { get; set; }
        public DateTime PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedDate { get; set; }
    }
}