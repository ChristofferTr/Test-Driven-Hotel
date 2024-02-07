using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Pages;
using Test_Driven_Hotel.Services;

namespace TestDrivenHotel.Tests
{
    [TestFixture]
    public class BookingConfirmationModelTests
    {
        private BookingConfirmationModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new BookingConfirmationModel();
            RoomService.Rooms = new List<Room>
            {
                new Room { Id = 101, IsAvailable = true },
            };
        }

        [Test]
        public void OnGet_SetsBookingAndSelectedRoomPropertiesCorrectly()
        {
            int bookingId = 1;
            string guestName = "Christoffer Trajkov";
            int roomId = 101;
            DateTime checkInDate = DateTime.Today.AddDays(1);
            DateTime checkOutDate = DateTime.Today.AddDays(3);

            _model.OnGet(bookingId, guestName, roomId, checkInDate, checkOutDate);

            Assert.That(_model.Booking, Is.Not.Null, "Booking property should not be null.");
            Assert.That(_model.Booking.GuestName, Is.EqualTo(guestName), "GuestName should match the input.");
            Assert.That(_model.Booking.RoomId, Is.EqualTo(roomId), "RoomId should match the input.");

            Assert.That(_model.SelectedRoom, Is.Not.Null, "SelectedRoom property should not be null.");
            Assert.That(_model.SelectedRoom.Id, Is.EqualTo(roomId), "SelectedRoom's Id should match the roomId input.");
        }
    }


}
