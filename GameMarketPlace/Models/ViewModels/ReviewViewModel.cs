using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
	public class ReviewViewModel
	{
		[Required(ErrorMessage = "Review ID is required")]
		public int ReviewId { get; set; }

		[Required(ErrorMessage = "Comment is required")]
		[MaxLength(255, ErrorMessage = "Cannot be more then 255 characters")]
		public string ReviewComments { get; set; }

		public int Rating { get; set; }

		public string MemberName { get; set; }

		[Required(ErrorMessage = "Game Id is required")]
		public int GameId { get; set; }
	}
}
