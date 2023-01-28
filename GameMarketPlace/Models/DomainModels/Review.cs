namespace GameMarketPlace.Models.DomainModels
{
	public class Review
	{
		public int ReviewId { get; set; }

		public string ReviewComments { get; set; }

		public int Rating { get; set; }

		public int GameId { get; set; }

		public string MemberName { get; set; }

		public bool Approved { get; set; }
	}
}
