using GameMarketPlace.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameMarketPlace.Controllers
{
    public class ValidationController : Controller
    {
        private MarketContext _marketContext;
        public ValidationController(MarketContext context)
        {
            _marketContext = context;
        }

        [HttpGet]
        private IActionResult CheckUsername(string username)
        {
            string message = String.Empty;

            if (!String.IsNullOrEmpty(username))
            {
                var user = _marketContext.Members.Where(m => m.UserName ==username).FirstOrDefault();

                if (user != null)
                {
                    message = "Username is already taken";
                    return Json(message);
                }
            }

            return Json(true);
        }

        [HttpGet]
        private IActionResult CheckEmail(string email)
        {
            string message = String.Empty;

            if (!String.IsNullOrEmpty(email))
            {
                var user = _marketContext.Members.Where(m => m.Email == email).FirstOrDefault();

                if (user != null)
                {
                    message = "Email is already taken";
                    return Json(message);
                }
            }

            return Json(true);
        }

        [HttpGet]
        private IActionResult CheckDate(DateTime expiryDate)
        {
            string message = String.Empty;


  //          if (date <= DateTime.Now)
//            {
                message = "Cannot have date in the past";
                return Json(message);
    //        }

      //      return Json(true);
        }

        [HttpGet]
        private IActionResult CheckCVVNumber(int cvv)
        {
            string message = String.Empty;

            string cvvToString = cvv.ToString();

            if (cvvToString.Length != 3)
            {
                message = "CVV must have 3 numbers";
                return Json(message);
            }

            return Json(true);
        }
    }
}
