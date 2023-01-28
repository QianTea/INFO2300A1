namespace GameMarketPlace.Models.DomainModels
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }
    }
}
