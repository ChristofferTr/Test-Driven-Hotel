namespace Test_Driven_Hotel.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string GuestName { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
