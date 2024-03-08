using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TripPlanner_1.Models;

namespace TripPlanner.Controllers
{
    [Route("Hotel")]
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        private readonly TripPlanner1Context _context;

        public HotelController(ILogger<HotelController> logger, TripPlanner1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Hotel> hotels = _context.Hotels.ToList();
            _logger.LogInformation($"Number of hotels retrieved: {hotels.Count}");
            return View(hotels);
        }

        [HttpPost("GetDestinationHotel")]
        public IActionResult GetDestinationHotel(IEnumerable<Holidaydestination> Destinationid)
        {
            var dest = Destinationid;
            // List<Hotel> hotels = _context.Hotels.Include(x => x.Destination).Where(x => x.Destinationid == dest.Destinationid).ToList();
            // _logger.LogInformation($"Number of hotels retrieved: {hotels.Count}");
            return View("Index");
        }
    }
}
