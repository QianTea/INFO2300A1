using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using GameMarketPlace.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Bmp;

namespace GameMarketPlace.Controllers
{
	public class ReviewController : Controller
	{
		private readonly SignInManager<Member> signInManager;
		private readonly UserManager<Member> userManager;
		private readonly MarketContext marketContext;

		public ReviewController(SignInManager<Member> signInManager, UserManager<Member> userManager, MarketContext context)
		{	
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.marketContext = context;
		}

		public async Task<IActionResult> WriteReview(int id)
		{
			if (signInManager.IsSignedIn(HttpContext.User))
			{
				Member member = await userManager.GetUserAsync(HttpContext.User);

				Game game = marketContext.Games.First(g => g.GameId == id);
				ViewBag.Game = game;
				ViewBag.Member = member;

				ReviewViewModel review = new ReviewViewModel();
				review.GameId = game.GameId;
				return View(review);
			}
			return RedirectToAction("Login", "Account");
		}

		[HttpPost]
		public async Task<IActionResult> WriteReview(ReviewViewModel model)
		{
			if (ModelState.IsValid)
			{
				Review review = new()
				{
					ReviewComments = model.ReviewComments,
					GameId = model.GameId,
					MemberName = model.MemberName,
					Rating = model.Rating,
					Approved = false
					
				};
				Game foundGame = marketContext.Games.First(g => g.GameId == review.GameId);

				marketContext.Reviews.Add(review);
				marketContext.SaveChanges();

				ViewBag.Games = marketContext.Games.OrderBy(g => g.GameName).ToList();
				return RedirectToAction("Index", "Home");
			}

			Game game = marketContext.Games.First(g => g.GameId == model.GameId);
			Member member = await userManager.GetUserAsync(HttpContext.User);
			ViewBag.Game = game;
			ViewBag.Member = member;
			return View(model);
		}
	}
}
