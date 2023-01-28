using Microsoft.AspNetCore.Mvc;

namespace GameMarketPlace.Controllers;

public class Employee : Controller
{
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
}