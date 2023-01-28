namespace GameMarketPlace.Models.DomainModels
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
    }
}
