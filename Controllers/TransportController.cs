// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using System.Collections.Generic;
// using System.Linq;
// using TripPlanner_1.Models;

// namespace TripPlanner.Controllers
// {
//     public class HotelController : Controller
//     {
//         private readonly ILogger<HotelController> _logger;
//         private readonly TripPlanner1Context _context;

//         public HotelController(ILogger<HotelController> logger, TripPlanner1Context context)
//         {
//             _logger = logger;
//             _context = context;
//         }

//         public IActionResult Index()
//         {
//             List<Hotel> hotels = _context.Hotels.ToList();
//             _logger.LogInformation($"Number of hotels retrieved: {hotels.Count}");
//             return View(hotels);
//         }

//         // Action method to book a hotel
//         public IActionResult BookHotel(int hotelId)
//         {
//             // Logic to book the hotel with the provided hotelId
//             Hotel hotel = _context.Hotels.FirstOrDefault(h => h.Hotelid == hotelId);
//             if (hotel == null)
//             {
//                 _logger.LogInformation($"Hotel with ID {hotelId} not found.");
//                 return NotFound(); // Return a 404 Not Found response if the hotel is not found
//             }

//             // Perform booking operations here

//             // Redirect to a confirmation page or return a view with booking details
//             return View(hotel);
//         }
//     }
// }
