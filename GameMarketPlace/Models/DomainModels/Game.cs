namespace GameMarketPlace.Models.DomainModels
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public double GamePrice { get; set; }
        public int Inventory { get; set; }
        public string PhysicalEditor { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
