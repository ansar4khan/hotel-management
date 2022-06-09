using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.API.Controllers //WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string searchText)
        {
            return Ok(await _hotelService.GetHotelsAsync(searchText));

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPost]
        [Route("{hotelId}/book")]
        public async Task<IActionResult> BookHotelAsync(int hotelId, [FromBody] Booking booking)
        {

            if (hotelId != booking.HotelId)
                return BadRequest();

            var hotel = await _hotelService.GetHotelByIdAsync(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var response = await _hotelService.BookHotelAsync(hotelId, booking);

            return Ok(response);

        }
    }
}
