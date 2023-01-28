using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.ViewModels
{
    public class CreditCardViewModel
    {
        public int CreditCardId { get; set; }

        [Required(ErrorMessage = "Card number is required.")]
        [MaxLength(16, ErrorMessage = "Mastercard must have 16 numbers")]
        [MinLength(16, ErrorMessage = "Mastercard must have 16 numbers")]
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV Number is required")]
        [MaxLength(3, ErrorMessage = "CVV must have 3 numbers")]
        [MinLength(3, ErrorMessage = "CVV must have 3 numbers")]
        [RegularExpression("[0-9]{3}", ErrorMessage = "Must be only digits")]
        public string CVV { get; set; }
    }
}
