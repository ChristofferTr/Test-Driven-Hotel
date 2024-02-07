namespace Test_Driven_Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string ImageUrl { get; set; }
    }

}
