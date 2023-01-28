using GameMarketPlace.Models.DomainModels;
using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

namespace GameMarketPlace.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<Models.DomainModels.Member> _userManager;
        private MarketContext _marketContext;

        public ProfileController(UserManager<Models.DomainModels.Member> userManager, MarketContext marketContext)
        {
            _userManager = userManager;
            _marketContext = marketContext;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string filter)
        {
            // Gets the id of the current signed in user
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);

            user.DateOfBirth= DateTime.Now;

            // Gets and sets the platforms into the view bag
            ViewBag.AllPlatforms = GetAllPlatforms();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllGenders = GetAllGenders();
            ViewBag.CreditCards = GetAllUserCreditCards(user.Id);
            ViewBag.AllProvinces = GetAllProvinces();
            ViewBag.Filter = filter;

            // Return the model to the view
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.DomainModels.Member model)
        {
            // Gets the current user
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);

            // Maps data
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MailingAddress = model.MailingAddress;
            user.PlatformId = model.PlatformId;
            user.GenreId = model.GenreId;

            if (model.DateOfBirth < DateTime.Now)
            {
                user.DateOfBirth = model.DateOfBirth;
                ModelState.Clear();
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("Invalid Date", "Date cannot be in future");
                user.DateOfBirth = DateTime.Now;
            }


            user.PromotionalEmail = model.PromotionalEmail;
            user.GenderId = model.GenderId;
            user.StreetAddress = model.StreetAddress;
            user.City = model.City;
            user.ProvinceId = model.ProvinceId;
            user.APSuiteNumber = model.APSuiteNumber;

            Task.WaitAny(_userManager.UpdateAsync(user));
            Task.WaitAny(_marketContext.SaveChangesAsync());

            ViewBag.Filter = "personal";
            ViewBag.AllPlatforms = GetAllPlatforms();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.CreditCards = GetAllUserCreditCards(user.Id);
            ViewBag.AllGenders = GetAllGenders();
            ViewBag.AllProvinces = GetAllProvinces();

            return View("Profile", user);
        }

        public async Task<IActionResult> Addresses()
        {
            // Gets the current user
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.AllProvinces = GetAllProvinces();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Addresses(Models.DomainModels.Member model)
        {
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);
            user.MailingAddress = model.MailingAddress;
            user.StreetAddress = model.StreetAddress;
            user.City = model.City;
            user.ProvinceId = model.ProvinceId;
            user.APSuiteNumber = model.APSuiteNumber;
            user.MailingAPNumber = model.MailingAPNumber;
            user.MailingCity = model.MailingCity;
            user.MailingProvince = model.MailingProvince;

            bool valid = true;

            if (!String.IsNullOrWhiteSpace(user.PostalCode))
            {
                Match isPostalCodeValid = Regex.Match(user.PostalCode, @"[Z-a]\d[Z-a]\d[Z-a]\d");

                if (!isPostalCodeValid.Success)
                {
                    valid = false;
                    ModelState.AddModelError("Invalid Postal Code", "Postal code in wrong format");
                }
            }

            if (!String.IsNullOrWhiteSpace(user.MailingPostalCode))
            {
                Match isPostalCodeValid = Regex.Match(user.PostalCode, @"[Z-a]\d[Z-a]\d[Z-a]\d");
                if (!isPostalCodeValid.Success)
                {
                    valid = false;
                    ModelState.AddModelError("Invalid Mailing Postal Code", "Postal code in wrong format");
                }
            }
            


            if (valid)
            {
                Task.WaitAny(_userManager.UpdateAsync(user));
                Task.WaitAny(_marketContext.SaveChangesAsync());
            }


            ViewBag.AllProvinces = GetAllProvinces();
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AddCreditCard()
        {
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);
            CreditCardViewModel creditCard = new CreditCardViewModel();
            creditCard.ExpiryDate = DateTime.Now;
            ViewBag.Action = "Add";
            return View("CreditCard", creditCard); 
        }

        [HttpGet]
        public IActionResult EditCreditCard(uint id)
        {
            CreditCard card = _marketContext.CreditCards.Where(c => c.CreditCardId == id).FirstOrDefault();

            if (card == null)
            {
                CreditCard cardViewModel = new CreditCard();
                return View("CreditCard", cardViewModel);
            }

            CreditCardViewModel creditCardViewModel = new CreditCardViewModel
            {
                CardNumber = card.CardNumber,
                CVV = card.CVV.ToString(),
                ExpiryDate = card.ExpiryDate,
                CreditCardId = card.CreditCardId,
            };

            ViewBag.Action = "Edit";

            return View("CreditCard", creditCardViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCreditCard(CreditCardViewModel model)
        {
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
               

                if (model.ExpiryDate > DateTime.Today)
                {
                    CreditCard card = new CreditCard
                    {
                        CardNumber = model.CardNumber,
                        ExpiryDate = model.ExpiryDate,
                        CVV = Int32.Parse(model.CVV),
                        MemberId = user.Id,
                    };
                    _marketContext.CreditCards.Add(card);
                    _marketContext.SaveChanges();

                    ViewBag.Filter = "creditcard";

                    return RedirectToAction("Profile", user);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Date must be in the future");
                    ViewBag.Action = "Add";
                    return View("CreditCard", model);
                }
            }

            ViewBag.Action = "Add";
            return View("CreditCard", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCreditCard(CreditCardViewModel model)
        {
            Models.DomainModels.Member user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                CreditCard card = _marketContext.CreditCards.First(u => u.CreditCardId == model.CreditCardId);
                //card.CVV = model.CVV;
                card.CardNumber = model.CardNumber;
                card.ExpiryDate = model.ExpiryDate;

                _marketContext.CreditCards.Update(card);
                _marketContext.SaveChanges();
                ViewBag.Filter = "creditcard";

                 return RedirectToAction("Profile", user);
            }

            return View("CreditCard", model);
        }

        [HttpGet]
        public IActionResult RemoveCreditCard(int id)
        {
            CreditCard card =  _marketContext.CreditCards.First(c => c.CreditCardId == id);
            _marketContext.CreditCards.Remove(card);
            _marketContext.SaveChanges();

            ViewBag.Filter = "creditcard";
            return RedirectToAction("Profile");
        }

        public List<Platform> GetAllPlatforms()
        {
            return _marketContext.Platforms.OrderBy(p => p.PlatformId).ToList();
        }

        public List<Genre> GetAllGenres()
        {
            return _marketContext.Genres.OrderBy(p => p.GenreId).ToList();
        }

        public List<CreditCard> GetAllUserCreditCards(string userId)
        {
            List<CreditCard> cards = _marketContext.CreditCards.Where(c => c.MemberId== userId).ToList();
            if (cards.Count == 0 || cards == null)
            {
                return new List<CreditCard>();
            }

            return cards;
        }

        public List<Gender> GetAllGenders()
        {
            return _marketContext.Genders.ToList();
        }

        public List<Province> GetAllProvinces()
        {
            return _marketContext.Provinces.OrderBy(p => p.ProvinceName).ToList();
        }
    }
}
