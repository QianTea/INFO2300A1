using GameMarketPlace.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameMarketPlace.Models.DomainModels;
using GameMarketPlace.Models.DataAccess;

namespace GameMarketPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MarketContext _marketContext;

        public HomeController(ILogger<HomeController> logger, MarketContext marketContext)
        {
            _logger = logger;
            _marketContext = marketContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Game> games = new List<Game>();
            games = _marketContext.Games.OrderBy(g => g.GameName).ToList<Game>();
            ViewBag.Games = games;
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            List<Game> games = new List<Game>();
            games = _marketContext.Games.OrderBy(g => g.GameName).ToList<Game>();
            ViewBag.Games = games;
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(SearchGameViewModel game, string? clear)
        {
            List<Game> games = new List<Game>();
            if (clear == null) {
                if (ModelState.IsValid)
                {
                    games = _marketContext.Games.Where(g => g.GameName == game.GameName).ToList();
                    ViewBag.Games = games;
                    return View();
                }
            }

            if (clear != null)
            {
                ModelState.Clear();
            }

            games = _marketContext.Games.OrderBy(g => g.GameName).ToList<Game>();

            ViewBag.Games = games;
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}