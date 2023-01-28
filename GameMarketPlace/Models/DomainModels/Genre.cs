using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.DomainModels
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }


        [Required]
        public string GenreName { get; set; }
    }
}
