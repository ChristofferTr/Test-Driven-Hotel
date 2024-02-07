using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Pages;
using Test_Driven_Hotel.Services;

namespace TestDrivenHotel.Tests
{
    [TestFixture]
    public class BookRoomModelTests
    {
        private BookRoomModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new BookRoomModel();
            RoomService.Rooms = new List<Room>
            {
                new Room { Id = 1, IsAvailable = true },
            };
        }

        [Test]
        public void OnPost_ValidRoom_BooksRoomAndRedirects()
        {
            _model.Booking = new Booking
            {
                RoomId = 1,
                GuestName = "Test Guest",
                CheckInDate = DateTime.Today.AddDays(1),
                CheckOutDate = DateTime.Today.AddDays(2)
            };

            var result = _model.OnPost();

            Assert.That(result, Is.InstanceOf<RedirectToPageResult>());
            Assert.That(RoomService.Rooms.First(r => r.Id == 1).IsAvailable, Is.False);
        }

        [Test]
        public void OnPost_InvalidRoomId_ReturnsError()
        {
            _model.Booking = new Booking
            {
                RoomId = 0,
                GuestName = "Test Guest",
                CheckInDate = DateTime.Today.AddDays(1),
                CheckOutDate = DateTime.Today.AddDays(2)
            };

            var result = _model.OnPost();

            Assert.That(result, Is.InstanceOf<PageResult>());
            Assert.That(_model.ModelState.ErrorCount > 0, Is.True);
        }
    }


}
