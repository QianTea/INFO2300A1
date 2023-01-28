using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class SearchGameViewModel
    {
        [Required(ErrorMessage = "Game Name required")]
        public string GameName { get; set; }
    }
}
