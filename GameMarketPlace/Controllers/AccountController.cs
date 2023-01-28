using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GameMarketPlace.Models.ViewModels;
using GameMarketPlace.Models.DomainModels;
using GameMarketPlace.Models.Utilities;
using DNTCaptcha.Core;
using Microsoft.Extensions.Options;
using GameMarketPlace.Models.DataAccess;

// https://code-maze.com/email-confirmation-aspnet-core-identity/ // Email COnfirmation
namespace GameMarketPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IDNTCaptchaValidatorService _captchaValidatorService;
        private readonly DNTCaptchaOptions _captchaOptions;
        private readonly MarketContext _marketContext;

        public AccountController(UserManager<Member> userManager, SignInManager<Member> signInManager, IDNTCaptchaValidatorService captchaValidatorService, IOptions<DNTCaptchaOptions>captchaOptions, MarketContext marketContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _captchaValidatorService = captchaValidatorService;
            _captchaOptions = captchaOptions == null ? throw new ArgumentNullException(nameof(captchaOptions)):captchaOptions.Value;
            _marketContext = marketContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Checks if the model is valid
            if (ModelState.IsValid)
            {
                if (!_captchaValidatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
                {
                    ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Didn't match image");
                    return View(model);
                }

                var user = new Member { Email = model.Email, UserName = model.UserName, DateOfBirth = DateTime.Today };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email },
                        Request.Scheme);
                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendConfirmationEmail(user.Email, confirmationLink);

                    if (emailResponse)
                    {
                        ViewBag.Message = "Check your email for the confirmation link";
                        return View(model);
                    }

                    ViewBag.Message = "";
                    ModelState.AddModelError(string.Empty, "Failed to register user");
                    RedirectToAction("ConfirmEmail", "Email");
                }
                // Adds all the errors to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewBag.Message = "";
            // Goes back to the register form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Signs user out
            await _signInManager.SignOutAsync();

            // Returns user to home page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "Home")
        {
            LoginViewModel model = new() { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false
                );

           
                if (result.Succeeded)
                {
                    if (user.EmailConfirmed)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            // Goes to return url
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                if (!result.Succeeded)
                {
                    if (user != null)
                    {
                        user.AccessFailedCount+=1;
                        Task.WaitAny(_userManager.UpdateAsync(user));
                        Task.WaitAny(_marketContext.SaveChangesAsync());
                        
                        if (user.AccessFailedCount > 2)
                        {
                            // Locks the user account out for three minutes
                            user.LockoutEnd = DateTime.Now.AddMinutes(3);
                            ModelState.AddModelError("", "Your account is locked out for 3 minutes");
                            return View(model);
                        }
                    }
                }
            }

            ModelState.AddModelError("", "Invalid email/password");
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Gets the password Hasher
                var passwordHasher = new PasswordHasher<Member>();

                var password = GeneratePassword();

                // Gets the current user
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user == null)
                {
                    ModelState.AddModelError("", "Couldn't find user with that name");
                    ViewBag.Message = "";
                    return View(model);
                }
                user.PasswordHash = passwordHasher.HashPassword(null, password);
                
                if (user.AccessFailedCount > 2)
                {
                    user.AccessFailedCount = 0;
                }

                Task.WaitAny(_userManager.UpdateAsync(user));
                Task.WaitAny(_marketContext.SaveChangesAsync());

                EmailHelper emailHelper = new EmailHelper();
                emailHelper.SendForgotPasswordEmail(user.Email, password);


                ViewBag.Message = "Check email for new password";
                return View(model);
            }

            ModelState.AddModelError("", "Invalid Username");
            ViewBag.Message = "";
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public string GeneratePassword()
        {
            var generatedString = string.Empty;
            const int MAX_LENGTH = 10;

            char[] alphabet = {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            var random = new Random();

            for (var i = 0; i < MAX_LENGTH; i++)
            {
                var randInt = random.Next(alphabet.Length-1);
                generatedString += alphabet[random.Next(randInt)];
            }

            return generatedString;
        }
    }
}
