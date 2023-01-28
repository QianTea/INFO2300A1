using System.Xml.XPath;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GameMarketPlace.Models.DomainModels;

namespace GameMarketPlace.Controllers;

public class EmailController : Controller
{
    private UserManager<Member> _userManager;
    
    public EmailController(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user != null)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View();
            }
        }

        return Redirect("Error");
    }
}