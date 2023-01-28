using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameMarketPlace.Models.DomainModels
{
    public class Employee
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}