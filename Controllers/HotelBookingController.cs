using HotelManagementWebsite.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementWebsite.Controllers
{
    public class HotelBookingController : Controller
    {
        private readonly IHotelBooking _hotelBooking;

        public HotelBookingController(IHotelBooking hotelBooking)
        {
            _hotelBooking = hotelBooking;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult>SearchResult(string name, string hotelName, int perDayPrice)
        {
            var hotelSearchViewModel = await _hotelBooking.GetAll(name, hotelName, perDayPrice);

            return View(hotelSearchViewModel);
        }
    }
}
