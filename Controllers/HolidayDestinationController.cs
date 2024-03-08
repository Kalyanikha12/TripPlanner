using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TripPlanner_1.Models;

namespace TripPlanner.Controllers
{
    public class HolidaydestinationController : Controller
    {
        private readonly ILogger<HolidaydestinationController> _logger;
        private readonly TripPlanner1Context _context; 

        public HolidaydestinationController(ILogger<HolidaydestinationController> logger, TripPlanner1Context context)
        {
            _logger = logger;
            _context = context;
        }

        
        public IActionResult Index()
        {
            List<Holidaydestination> holidaydestinations = _context.Holidaydestinations.ToList();
            return View(holidaydestinations);
        }



        [HttpPost]
        public IActionResult Create(Holidaydestination holidaydestination)
        {
            if (ModelState.IsValid)
            {
                _context.Holidaydestinations.Add(holidaydestination);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(holidaydestination);
        }

        
[HttpPost]
public IActionResult Book(int destinationId)
{
    return RedirectToAction("Index", "Hotel", new { destinationId });
}

    }
}