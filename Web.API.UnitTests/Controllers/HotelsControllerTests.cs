using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Controllers;
using Xunit;

namespace Web.API.UnitTests.Controllers
{
    public class HotelsControllerTests
    {


        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WithAListOfHotels()
        {
            var mockHotelService = new Mock<IHotelService>();
            mockHotelService.Setup(service => service.GetHotelsAsync(It.IsAny<string>())).ReturnsAsync(GetHotels());

            var controller = new HotelsController(mockHotelService.Object);
            var result = await controller.GetAll(string.Empty);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var hotels = Assert.IsType<List<HotelViewModel>>(okObjectResult.Value);
            Assert.NotEmpty(hotels);
            Assert.Single(hotels);

        }

        [Fact]
        public async Task GetById_ShouldReturnOkResult_WithHotelDetails()
        {
            var hotel = GetHotel();
            var mockHotelService = new Mock<IHotelService>();
            mockHotelService.Setup(service => service.GetHotelByIdAsync(hotel.Id)).ReturnsAsync(hotel);
            var controller = new HotelsController(mockHotelService.Object);

            var result = await controller.GetById(hotel.Id);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var hotelResult = Assert.IsType<Hotel>(okObjectResult.Value);

            Assert.NotNull(hotelResult);
            Assert.Equal(hotel.Id, hotelResult.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-11)]
        public async Task GetById_ShouldReturnNotFound_WhenTheHotelIsNotFound(int hotelId)
        {
            Hotel hotel = null;
            var mockHotelService = new Mock<IHotelService>();
            mockHotelService.Setup(service => service.GetHotelByIdAsync(It.IsAny<int>())).ReturnsAsync(hotel);
            var controller = new HotelsController(mockHotelService.Object);

            var result = await controller.GetById(hotelId);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task BookHotelAsync_ShouldReturnBookingDetails()
        {
            var hotel = GetHotel();
            var booking = new Booking { Id = 3, HotelId = hotel.Id, CheckInTime = DateTime.Now, CheckOutTime = DateTime.Now.AddDays(2) };
            var mockHotelService = new Mock<IHotelService>();
            mockHotelService.Setup(service => service.GetHotelByIdAsync(It.IsAny<int>())).ReturnsAsync(hotel);
            mockHotelService.Setup(service => service.BookHotelAsync(It.IsAny<int>(), It.IsAny<Booking>())).ReturnsAsync(booking);
            var controller = new HotelsController(mockHotelService.Object);

            var result = await controller.BookHotelAsync(hotel.Id, booking);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var bookingResult = Assert.IsType<Booking>(okObjectResult.Value);
            Assert.Equal(hotel.Id, booking.HotelId);
        }

        [Fact]
        public async Task BookHotelAsync_ShouldReturnBadRequest()
        {
            var hotel = GetHotel();
            var booking = new Booking { Id = 3, HotelId = 5, CheckInTime = DateTime.Now, CheckOutTime = DateTime.Now.AddDays(2) };
            var mockHotelService = new Mock<IHotelService>();

            var controller = new HotelsController(mockHotelService.Object);

            var result = await controller.BookHotelAsync(hotel.Id, booking);
            Assert.IsType<BadRequestResult>(result);
        }

        private List<HotelViewModel> GetHotels()
        {

            var hotels = new List<HotelViewModel>();


            hotels.Add(
                new HotelViewModel()
                {
                    HotelId = 1,
                    Name = "Hotel One",
                    ActualRent = 350,
                    DiscountedRent = 275,
                    Image = string.Empty,
                    NoOfReviews = 20,
                    Rating = 4,
                });

            return hotels;

        }

        private Hotel GetHotel()
        {
            var hotel = new Hotel();
            hotel.Id = 1;
            hotel.Name = "Hotel 1";
            hotel.Address = "Dubai, United Arab Emirates";
            hotel.Description = "Luxury 5 star hotel with cool view";
            hotel.Image = string.Empty;
            hotel.ActualRent = 350;
            hotel.DiscountedRent = 275;
            hotel.Reviews = new List<Review>();
            hotel.Facilities = new List<Facility>();
            return hotel;
        }
    }
}
