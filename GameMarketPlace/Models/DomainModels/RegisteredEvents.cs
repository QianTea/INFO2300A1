using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.DomainModels
{
	public class RegisteredEvents
	{
		[Key]
		public int RegisteredEventId { get; set; }
		public int EventId { get; set; }
		public string MemberId { get; set; }
	}
}
