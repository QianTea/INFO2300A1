using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class GameViewModel
    {
        public int GameId { get; set; }

        [Required(ErrorMessage = "Game Name is required")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Game Price is required")]
        [RegularExpression("[0-9]{1,10}", ErrorMessage = "Game price can only contain numbers")]
        public double GamePrice { get; set; }

        [Required(ErrorMessage = "Inventory is required")]
        [RegularExpression("[0-9]{1,10}", ErrorMessage = "Inventory can only contain numbers")]
        public int Inventory { get; set; }

        [Required(ErrorMessage = "Physical Editor is required")]
        public string PhysicalEditor { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Genre is Required")]
        public int GenreId { get; set; }
    }
}
