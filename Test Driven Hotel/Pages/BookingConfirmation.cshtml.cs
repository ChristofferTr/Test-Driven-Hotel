using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Services;
using System;
using System.Linq;

namespace Test_Driven_Hotel.Pages
{
    public class BookingConfirmationModel : PageModel
    {
        public Booking Booking { get; set; }
        public Room SelectedRoom { get; set; }

        public void OnGet(int bookingId, string guestName, int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            Booking = new Booking
            {
                BookingId = bookingId,
                GuestName = guestName,
                RoomId = roomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            SelectedRoom = RoomService.GetRoomById(roomId);
        }


        private List<Booking> GetBookings()
        {
            var bookings = new List<Booking>
            {
                new Booking
                {
                    BookingId = 1,
                    GuestName = "Christoffer Trajkov",
                    RoomId = 101,
                    CheckInDate = DateTime.Today.AddDays(1),
                    CheckOutDate = DateTime.Today.AddDays(3)
                },
            };
            return bookings;
        }
    }
}
