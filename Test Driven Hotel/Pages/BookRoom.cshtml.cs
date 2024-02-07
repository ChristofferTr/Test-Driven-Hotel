using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Services;
using System;
using System.Linq;

namespace Test_Driven_Hotel.Pages
{
    public class BookRoomModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }

        public List<Room> AvailableRooms { get; set; } = RoomService.Rooms;

        public Room SelectedRoom { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Booking.RoomId == 0)
            {
                ModelState.AddModelError("Booking.RoomId", "Please select a room.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SelectedRoom = RoomService.Rooms.FirstOrDefault(r => r.Id == Booking.RoomId && r.IsAvailable);

            if (SelectedRoom == null)
            {
                return Page();
            }

            if (BookingDatesOverlap(Booking.CheckInDate, Booking.CheckOutDate, SelectedRoom))
            {
                return Page();
            }

            SelectedRoom.IsAvailable = false;

            return RedirectToPage("BookingConfirmation", new
            {
                bookingId = Booking.BookingId,
                guestName = Booking.GuestName,
                roomId = Booking.RoomId,
                checkInDate = Booking.CheckInDate,
                checkOutDate = Booking.CheckOutDate
            });
        }

        private bool BookingDatesOverlap(DateTime checkIn, DateTime checkOut, Room room)
        {
            return false;
        }
    }
}
