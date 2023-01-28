using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameMarketPlace.Models.DomainModels
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public string CardNumber { get; set; } 

        public DateTime ExpiryDate { get; set; }

        public int CVV { get; set; }

        public string MemberId { get; set; }

        /*YL*/
        public Member Member { get; set; }
    }
}
