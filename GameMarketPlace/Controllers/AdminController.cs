using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using GameMarketPlace.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace GameMarketPlace.Controllers
{
    public class AdminController : Controller
    {
        private readonly MarketContext context;

        public AdminController(MarketContext marketContext)
        {
            context = marketContext;
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult GameManagement()
        {
            ViewBag.Games = GetAllGames();
            return View();
        }

        public IActionResult EventManagement()
        {
            ViewBag.Events = GetAllEvents();
            return View();
        }

        public IActionResult ReviewManagement()
        {
            ViewBag.Reviews = GetAllReviews();
            return View();
        }

        public IActionResult ReportManagement()
        {
            return View();
        }

        #region Review

        public IActionResult ApproveReview(int id)
        {
            Review review = context.Reviews.First(r => r.ReviewId == id);
            
            if (review != null)
            {
                review.Approved = true;
                context.Reviews.Update(review);
                context.SaveChanges();
            }

            ViewBag.Reviews = GetAllReviews();
            return View("ReviewManagement");
        }

        public IActionResult DeclineReview(int id)
        {
            Review review = context.Reviews.First(r => r.ReviewId == id);
            
            if (review != null)
            {
                context.Reviews.Remove(review);
                context.SaveChanges();
            }

            ViewBag.Reviews = GetAllReviews();
            return View("ReviewManagement");
        }

        #endregion

        #region Game

        public IActionResult EditGame(int id)
        {
            Game game = context.Games.Where(g => g.GameId == id).FirstOrDefault();
            GameViewModel editGame = new()
            {
                GameName = game.GameName,
                GamePrice = game.GamePrice,
                GameId = game.GameId,
                Inventory = game.Inventory,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                PhysicalEditor = game.PhysicalEditor,
                GenreId = game.GenreId
                
            };

            List<Genre> genres = GetAllGenres();
            ViewBag.Genres = genres;
            return View(editGame);
        }

        [HttpPost]
        public IActionResult EditGame(GameViewModel game)
        {
            if (ModelState.IsValid)
            {

                Game newGame = context.Games.First(g => g.GameId == game.GameId);
                
                if (newGame != null)
                {
                    newGame.GameName = game.GameName;
                    newGame.GamePrice = game.GamePrice;
                    newGame.Inventory = game.Inventory;
                    newGame.Publisher = game.Publisher;
                    newGame.ReleaseDate = game.ReleaseDate;
                    newGame.PhysicalEditor = game.PhysicalEditor;
                    newGame.GenreId = game.GenreId;

                    context.Games.Update(newGame);
                    context.SaveChanges();
                }

                List<Game> games = GetAllGames();
                ViewBag.Games = games;
                return View("GameManagement");
            }


            List<Genre> genres = GetAllGenres();
            ViewBag.Genres = genres;
            return View(game);
        }

        public IActionResult AddGame()
        {
            GameViewModel game = new()
            {
                ReleaseDate = DateTime.Now

            };

            List<Genre> genres = GetAllGenres();
            ViewBag.Genres = genres;
            return View(game);
        }

        [HttpPost]
        public IActionResult AddGame(GameViewModel game)
        {
            if (ModelState.IsValid)
            {

                Game newGame = new()
                {

                    GameName = game.GameName,
                    GamePrice = game.GamePrice,
                    Inventory = game.Inventory,
                    Publisher = game.Publisher,
                    ReleaseDate = game.ReleaseDate,
                    PhysicalEditor = game.PhysicalEditor,
                    GenreId = game.GenreId
                };

                context.Games.Add(newGame);
                context.SaveChanges();

                List<Game> games = GetAllGames();
                ViewBag.Games = games;
                return View("GameManagement");
            }


            List<Genre> genres = GetAllGenres();
            ViewBag.Genres = genres;
            return View(game);
        }

        public IActionResult RemoveGame(int id)
        {
            Game game = context.Games.Where(g => g.GameId == id).FirstOrDefault();

            if (game != null)
            {
                context.Games.Remove(game);
                context.SaveChanges();
            }

            ViewBag.Games = GetAllGames();
            return View("GameManagement");
        }

        #endregion

        #region Events

        public IActionResult AddEvent()
        {
            EventViewModel eventViewModel = new EventViewModel();
            eventViewModel.EventDate = DateTime.Now;
            return View(eventViewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EventDate < DateTime.Now)
                {
                    ModelState.AddModelError("Invalid Date", "Date cannot be in the past");
                    return View(model);
                }
                else
                {
                    Event newEvent = new()
                    {
                        EventDate = model.EventDate,
                        EventName = model.EventName,
                        EventDetails = model.EventDetails
                    };

                    context.Events.Add(newEvent);
                    context.SaveChanges();

                    ViewBag.Events = GetAllEvents();
                    return View("EventManagement");
                }
            }

            return View(model);
        }

        public IActionResult RemoveEvent(int id)
        {
            Event foundEvent = context.Events.First(e => e.EventId == id);

            if (foundEvent != null)
            {
                context.Events.Remove(foundEvent);
                context.SaveChanges();
            }

            ViewBag.Events = GetAllEvents();
            return View("EventManagement");
        }

        public IActionResult EditEvent(int id)
        {
            Event foundEvent = context.Events.First(e => e.EventId == id);

            if (foundEvent != null)
            {
                EventViewModel eventModel = new EventViewModel();
                eventModel.EventId = foundEvent.EventId;
                eventModel.EventDate = foundEvent.EventDate;
                eventModel.EventName= foundEvent.EventName;
                eventModel.EventDetails= foundEvent.EventDetails;
                return View(eventModel);
            }

            return View("EventManagement");
        }

        [HttpPost]
        public IActionResult EditEvent(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Event foundEvent = context.Events.First(e => e.EventId == model.EventId);

                if (foundEvent != null)
                {
                    foundEvent.EventId = model.EventId;
                    foundEvent.EventDate = model.EventDate;
                    foundEvent.EventName= model.EventName;
                    foundEvent.EventDetails= model.EventDetails;

                    if (foundEvent.EventDate < DateTime.Now)
                    {
                        ModelState.AddModelError("Invalid date", "Date cannot be in the past");
                        return View(model);
                    }

                    context.Events.Update(foundEvent);
                    context.SaveChanges();

                    ViewBag.Events = GetAllEvents();

                    return View("EventManagement");
                }
            }

            return View(model);
        }
        #endregion

        public List<Game> GetAllGames()
        {
            return context.Games.OrderBy(g => g.GameName).ToList();
        }
        public List<Genre> GetAllGenres()
        {
            return context.Genres.OrderBy(g => g.GenreName).ToList();
        }

        public List<Event> GetAllEvents()
        {
            return context.Events.OrderBy(e => e.EventDate).ToList();
        }
        
        public List<Review> GetAllReviews()
        {
            return context.Reviews.Where(r => r.Approved == false).ToList();
        }
    }
}
