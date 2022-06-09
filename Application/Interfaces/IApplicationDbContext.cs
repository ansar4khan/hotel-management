using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Facility> Facilities { get; set; }
        DbSet<Review> Reviews { get; set; }

        DbSet<Booking> Bookings { get; set; }

        Task<int> SaveChangesAsync();
    }
}
