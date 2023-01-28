using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.DomainModels
{
    public class Platform
    {
        [Required]
        public int PlatformId { get; set; }

        [Required]
        public string PlatformName { get; set; }
    }
}
