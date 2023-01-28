using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameMarketPlace.Controllers
{
    public class EventController : Controller
    {
        private readonly MarketContext _marketContext;
        private readonly UserManager<Member> _userManager;

        public EventController(MarketContext marketContext, UserManager<Member> userManager)
        {
            _marketContext = marketContext;
            _userManager = userManager;
        }

        public IActionResult EventListing()
        {
            List<Event> events = _marketContext.Events.ToList();
            ViewBag.Events = events;

            return View();
        }

        public async Task<IActionResult> RegisterEvent(int id)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);
            Event specificEvent = _marketContext.Events.FirstOrDefault(e => e.EventId == id)!;
            RegisteredEvents newEvent = new RegisteredEvents
            {
                EventId = id,
                MemberId = user.Id,
            };

            _marketContext.RegisteredEvents.Add(newEvent);
            _marketContext.SaveChanges();

            ViewBag.Registered = true;

           

            return View("Event", specificEvent);
        }

        public async Task<IActionResult> UnregisterEvent(int id)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);

            RegisteredEvents foundEvent = _marketContext.RegisteredEvents.FirstOrDefault(e => e.EventId == id && e.MemberId == user.Id)!;

            _marketContext.RegisteredEvents.Remove(foundEvent);
            _marketContext.SaveChanges();

            ViewBag.Registered = false;

            Event specificEvent = _marketContext.Events.FirstOrDefault(e => e.EventId == id)!;

            return View("Event", specificEvent);
        }

        public async Task<IActionResult> Event(int id)
        {
            Member user = await _userManager.GetUserAsync(HttpContext.User);

            Event specificEvent = _marketContext.Events.FirstOrDefault(e => e.EventId == id)!;

            bool registered = false;

            RegisteredEvents registeredEvent = _marketContext.RegisteredEvents.Where(w => w.EventId == specificEvent.EventId).Where(w => w.MemberId == user.Id).FirstOrDefault()!;

            if (registeredEvent != null)
            {
                registered = true;
            }

            ViewBag.Registered = registered;


            return View(specificEvent);
        }
    }
}
