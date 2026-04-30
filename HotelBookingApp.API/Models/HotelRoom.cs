namespace HotelBookingApp.API.Models;

public class HotelRoom
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int RoomTypeId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int Floor { get; set; }
    public bool IsActive { get; set; } = true;

    public Hotel Hotel { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
