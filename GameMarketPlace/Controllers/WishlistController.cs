using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameMarketPlace.Controllers
{
    public class WishlistController : Controller
    {
        private readonly MarketContext _marketContext;
        private readonly UserManager<Member> _userManager;

        public WishlistController(MarketContext marketContext, UserManager<Member> userManager)
        {
            _marketContext = marketContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Wishlist()
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);
            List<Game> game = new List<Game>();

            List<Wishlist> list = _marketContext.Wishlists.Where(w => w.UserId == user.Id).ToList();

            foreach(var games in list)
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
    }
}
