using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Services
{

    public class HotelService : IHotelService
    {
        private readonly IApplicationDbContext _context;
        
        public HotelService(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Booking> BookHotelAsync(int hotelId, Booking booking)
        {

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
        public async Task<IEnumerable<HotelViewModel>> GetHotelsAsync(string searchText)
        {

            var query = _context.Hotels.Include(h => h.Reviews).AsQueryable();
                
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(h => h.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) 
                || h.Address.Contains(searchText,StringComparison.OrdinalIgnoreCase)
                || h.Description.Contains(searchText,StringComparison.OrdinalIgnoreCase));
            }


            return await query.Select(h =>
                             new HotelViewModel
                             {
                                 HotelId = h.Id,
                                 Name = h.Name,
                                 Image = h.Image,
                                 ActualRent = h.ActualRent,
                                 DiscountedRent = h.DiscountedRent,
                                 NoOfReviews = h.Reviews.Count(),
                                 Rating = Math.Round(h.Reviews.Average(r => r.Rating), 2),
                             }
                        ).ToListAsync();
            
        }
        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotels.Include(h=>h.Reviews).Include(h=>h.Facilities).FirstOrDefaultAsync(h=> h.Id==id);

            if (hotel == null)
                return null;

            return hotel;
        }
    }
}
