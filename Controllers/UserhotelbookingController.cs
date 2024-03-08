 using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Logging;
 using System.Collections.Generic;
 using System.Linq;
 using TripPlanner_1.Models;

namespace TripPlanner.Controllers
{
    public class UserHotelBookingController : Controller
    {
        private readonly ILogger<UserHotelBookingController> _logger;
        private readonly TripPlanner1Context _context;

        public UserHotelBookingController(ILogger<UserHotelBookingController> logger, TripPlanner1Context context)
        {
            _logger = logger;
            _context = context;
        }




        
        [HttpPost]
        public IActionResult Userhotelbooking(int hotelId, string fullName, string email, DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {
                var hotel = _context.Hotels.Find(hotelId);
                if (hotel == null)
                {
                    _logger.LogInformation($"Hotel with ID {hotelId} not found.");
                    return NotFound();
                }

                
                var checkInDateOnly = new DateOnly(checkInDate.Year, checkInDate.Month, checkInDate.Day);
                var checkOutDateOnly = new DateOnly(checkOutDate.Year, checkOutDate.Month, checkOutDate.Day);

                
                var booking = new Userhotelbooking
                {
                    Userid = 1, 
                    Hotelid = hotelId,
                    CheckInDate = checkInDateOnly,
                    CheckOutDate = checkOutDateOnly,
                    User = new User(), 
                    Hotel = hotel 
                };

                _context.Userhotelbookings.Add(booking);
                _context.SaveChanges();

                
                return RedirectToAction("BookingConfirmation", new { hotelId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error confirming booking: {ex.Message}");
            
                return RedirectToAction("Index", "Userhotelbooking");
            }
        }


        
        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }

    
[HttpPost]
public IActionResult ConfirmBooking(int hotelId, int userId, DateTime checkInDate, DateTime checkOutDate)
{
    try
    {
        

        return RedirectToAction("BookingConfirmation", new { hotelId });
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error confirming booking: {ex.Message}");
        return RedirectToAction("Index", "Home");
    }
}


public IActionResult BookingConfirmation(int hotelId)
{
    var hotel = _context.Hotels.FirstOrDefault(h => h.Hotelid == hotelId);
    if (hotel == null)
    {
        _logger.LogInformation($"Hotel with ID {hotelId} not found.");
        return NotFound();
    }

    return View(hotel);
}

    }
    }

