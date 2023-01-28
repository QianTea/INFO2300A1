using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [Remote("CheckEmail", "Validation")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username can't be empty")]
        [Remote("CheckUsername", "Validation")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
