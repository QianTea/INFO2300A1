using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.DomainModels
{
    public class Admin
    {
        [Required]
        private int AdminId { get; set; }

        [Required]
        private string Email { get; set; }

        [Required]
        private string Password { get; set; }
    }
}
