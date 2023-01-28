using Microsoft.AspNetCore.Mvc;
using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace GameMarketPlace.Controllers
{
    public class CartController : Controller
    {
		private readonly MarketContext _marketContext;
		private readonly UserManager<Member> _userManager;

		public CartController(MarketContext marketContext, UserManager<Member> userManager)
		{
			_marketContext = marketContext;
			_userManager = userManager;
		}

		// TODO: change the wishlist below to shopping cart list
		public async Task<IActionResult> Cartlist()
		{
			Member user = await _userManager.GetUserAsync(HttpContext.User);
			List<Game> game = new List<Game>();

			List<Wishlist> list = _marketContext.Wishlists.Where(w => w.UserId == user.Id).ToList();
		
			foreach (var games in list)
			{
				Game foundGame = _marketContext.Games.FirstOrDefault(g => g.GameId == games.GameId);

				if (foundGame != null)
				{
					game.Add(foundGame);
				}
			}

			ViewBag.wishlist = game;

			return View(list);
		}

/*		public IActionResult Index()
        {
            return View();
        }*/
    }
}
