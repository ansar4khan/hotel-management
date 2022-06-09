using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTests.Services
{
    public class HotelServiceTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _contextOptions;

        public HotelServiceTests()
        {
            _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase("test_db")
           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

            using var context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
       
        [Fact]
        public async Task GetHotelsAsync_ShouldReturnHotels()
        {

            using var context = CreateContext();
            var service = new HotelService(context);

            var hotels = await service.GetHotelsAsync(string.Empty);

            Assert.NotEmpty(hotels);
            Assert.Equal(3, hotels.Count());
            Assert.Collection(hotels,
                h => Assert.Equal(1, h.HotelId),
                h => Assert.Equal(2, h.HotelId),
                h => Assert.Equal(3, h.HotelId));
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        public async Task GetHotelByIdAsync_ShouldReturnSingleHotel(int hotelId,int expectedHoteId)
        {

            using var context = CreateContext();
            var service = new HotelService(context);

            var hotel = await service.GetHotelByIdAsync(hotelId);

            Assert.NotNull(hotel);
            Assert.Equal(expectedHoteId, hotel.Id);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(50)]
        public async Task GetHotelByIdAsync_ShouldReturnNull_WhenTheHotelIsNotFound(int invalidHotelId)
        {

            using var context = CreateContext();
            var service = new HotelService(context);

            var hotel = await service.GetHotelByIdAsync(invalidHotelId);

            Assert.Null(hotel);
        }


        [Fact]
        public async Task BookHotelAsync_ShouldReturnBooking()
        {

            using var context = CreateContext();
            var service = new HotelService(context);

            var booking = new Booking();

            int hotelId = 1;

            booking.HotelId = hotelId;
            booking.CheckInTime = DateTime.Now;
            booking.CheckOutTime = DateTime.Now.AddDays(2);

            var result = await service.BookHotelAsync(hotelId,booking);

            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal(hotelId, result.HotelId);
        }
        ApplicationDbContext CreateContext() => new ApplicationDbContext(_contextOptions);
    }
}
