using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Pages;
using Test_Driven_Hotel.Services;

namespace Test_Driven_Hotel.Tests
{
    [TestFixture]
    public class SearchRoomsModelTests
    {
        private SearchRoomsModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new SearchRoomsModel();

            RoomService.Rooms = new List<Room>
            {
                new Room { Id = 1, IsAvailable = true },
                new Room { Id = 2, IsAvailable = true },
                new Room { Id = 4, IsAvailable = true }
            };
        }


        [Test]
        public async Task OnPostAsync_ReturnsAllAvailableRooms()
        {

            await _model.OnPostAsync();

            var expectedRoomIds = RoomService.Rooms.Where(room => room.IsAvailable).Select(room => room.Id).OrderBy(id => id).ToList();
            var actualRoomIds = _model.AvailableRooms.Select(room => room.Id).OrderBy(id => id).ToList();

            CollectionAssert.AreEqual(expectedRoomIds, actualRoomIds, "All available rooms should be returned.");
        }

        [Test]
        public async Task OnPostAsync_ReturnsNoRoomsWhenNoneAvailable()
        {
            RoomService.Rooms.ForEach(room => room.IsAvailable = false);

            await _model.OnPostAsync();

            Assert.That(_model.AvailableRooms, Is.Empty, "No rooms should be returned when all are marked as unavailable.");

            RoomService.Rooms.ForEach(room => room.IsAvailable = true);
        }


    }
}
