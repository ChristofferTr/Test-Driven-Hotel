using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_Driven_Hotel.Models;
using Test_Driven_Hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Driven_Hotel.Pages
{
    public class SearchRoomsModel : PageModel
    {
        [BindProperty]
        public DateTime CheckInDate { get; set; }

        [BindProperty]
        public DateTime CheckOutDate { get; set; }

        public List<Room> AvailableRooms { get; set; } = new List<Room>();

        public async Task<IActionResult> OnPostAsync()
        {
            AvailableRooms = RoomService.Rooms
                .Where(room => room.IsAvailable &&
                               (!room.CheckInDate.HasValue || room.CheckInDate.Value < CheckOutDate) &&
                               (!room.CheckOutDate.HasValue || room.CheckOutDate.Value > CheckInDate))
                .ToList();

            return Page();
        }

    }
}
