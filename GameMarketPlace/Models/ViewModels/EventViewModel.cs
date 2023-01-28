using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Event Details is required")]
        public string EventDetails { get; set; }
    }
}
