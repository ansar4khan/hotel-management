using Application.Models;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        //Task<List<Hotel>> GetHotelsAsync();
        Task<IEnumerable<HotelViewModel>> GetHotelsAsync(string searchText);
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Booking> BookHotelAsync(int hotelId, Booking booking);
    }
}
