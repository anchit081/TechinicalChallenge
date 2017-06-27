using System.Collections.Generic;

namespace ConferenceBarrel.Models
{
    public class InterviewData
    {
        public int Id { get; set;}
        public string supplier { get; set; }
        public int year { get; set; }
        public int spend { get; set; }
        public int quantity { get; set; }
        public int no_of_products { get; set; }
        public List<Session> Sessions { get; set; }
    }
}