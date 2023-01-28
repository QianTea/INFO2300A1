using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameMarketPlace.Models.DomainModels
{
    public class Member : IdentityUser { 
        [NotMapped]
        public IList<string> RoleNames { get; set; }

        [Required]
        public string MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MailingAddress { get; set; }

        public string StreetAddress { get; set; }

        public string APSuiteNumber { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string MailingAPNumber { get; set; }

        public string MailingCity { get; set; }

        public int MailingProvince { get; set; }

        public string MailingPostalCode { get; set; }

        public bool SameAsShipping { get; set; }

        public int WishListId { get; set; }

        public bool PromotionalEmail { get; set; }

        [Required]
        public int PlatformId { get; set; } = 1;

        [Required]
        public int GenreId { get; set; } = 1;

        [Required]
        public int GenderId { get; set; } = 1;

        [Required]
        public int ProvinceId { get; set; } = 1;
        
        public Platform Platform { get; set; }

        public Genre Genre { get; set; }

        public Gender Gender { get; set; }
        
        public Province Province { get; set; }
    }
}