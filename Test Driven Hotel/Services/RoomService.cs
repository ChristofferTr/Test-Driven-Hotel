using Test_Driven_Hotel.Models;
using System;
using System.Collections.Generic;

namespace Test_Driven_Hotel.Services
{
    public static class RoomService
    {
        public static List<Room> Rooms = new List<Room>
        {
            new Room { Id = 1, Type = "Single", IsAvailable = true, ImageUrl = "/images/single-room.jpg" },
            new Room { Id = 2, Type = "Double", IsAvailable = true, ImageUrl = "/images/double-room.jpg" },
            new Room { Id = 3, Type = "Suite", IsAvailable = true, ImageUrl = "/images/suite-room.jpg" }
        };
        public static Room GetRoomById(int roomId)
        {
            return Rooms.Find(room => room.Id == roomId);
        }
    }
}
