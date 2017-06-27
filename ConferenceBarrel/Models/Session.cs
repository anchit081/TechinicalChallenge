namespace ConferenceBarrel.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int InterviewDataId { get; set; }
        public InterviewData InterviewData{ get; set; }
    }
}