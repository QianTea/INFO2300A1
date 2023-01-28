using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username can't be empty")]
        [StringLength(24)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(18, MinimumLength = 5, ErrorMessage = "A password must be between 6-18 characters")]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
