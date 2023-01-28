using GameMarketPlace.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace GameMarketPlace.Controllers
{
    public class GameController : Controller
    {
        private readonly MarketContext _marketContext;
        private readonly UserManager<Member> _userManager;

        public GameController(MarketContext marketContext, UserManager<Member> userManager)
        {
            _marketContext = marketContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Game(int id)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);

            

            if (_marketContext.Games.Where(g => g.GameId == id).FirstOrDefault() == null)
            {
                ViewBag.InWishlist = false;
                return View();
            }

            Game game = _marketContext.Games.FirstOrDefault(g => g.GameId == id)!;
            Genre genre = _marketContext.Genres.FirstOrDefault(g => g.GenreId == game.GenreId)!;

            if (user == null)
            {
                ViewBag.InWishlist = false;
                ViewBag.Genre = genre;
                return View(game);
            }
            else
            {
                Wishlist list = _marketContext.Wishlists.Where(w => w.UserId == user.Id).Where(w => w.GameId == game.GameId).FirstOrDefault();

                ViewBag.Genre = genre;

                if (list != null)
                {
                    ViewBag.InWishlist = true;
                }
                else
                {
                    ViewBag.InWishList = false;
                }

                List<Review> reviews = _marketContext.Reviews.Where(r => r.GameId == id && r.Approved).ToList();
                ViewBag.Reviews = reviews;
                return View(game);
            }
        }

        public async Task<IActionResult> AddToWishList(uint id)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);

            Wishlist list = new Wishlist
            {
                GameId = (int)id,
                UserId = user.Id
            };

            _marketContext.Wishlists.Add(list);
            _marketContext.SaveChanges();

            Game game = _marketContext.Games.FirstOrDefault(g => g.GameId == id)!;
            Genre genre = _marketContext.Genres.FirstOrDefault(g => g.GenreId == game.GenreId)!;

            List<Review> reviews = _marketContext.Reviews.Where(r => r.Approved == true).ToList();
            ViewBag.Genre = genre;
            ViewBag.InWishList = true;
            ViewBag.Reviews = reviews;

            return View("Game", game);
        }

        public async Task<IActionResult> RemoveFromWishlist(uint id, string? wishlist)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);

            Wishlist list = _marketContext.Wishlists.Where(w => w.GameId == id).Where(w => w.UserId == user.Id).FirstOrDefault();

            _marketContext.Wishlists.Remove(list);
            _marketContext.SaveChanges();

            if (wishlist != null)
            {
                return RedirectToAction("Wishlist", "Wishlist");         
            }

            Game game = _marketContext.Games.FirstOrDefault(g => g.GameId == id)!;
            Genre genre = _marketContext.Genres.FirstOrDefault(g => g.GenreId == game.GenreId)!;
            List<Review> reviews = _marketContext.Reviews.Where(r => r.Approved == true).ToList();

            ViewBag.Genre = genre;
            ViewBag.InWishList = false;
            ViewBag.Reviews = reviews;

            return View("Game", game);
        }
    }
}
