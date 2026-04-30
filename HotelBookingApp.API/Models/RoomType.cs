namespace HotelBookingApp.API.Models;

public class RoomType
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public string Amenities { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public Hotel Hotel { get; set; } = null!;
    public ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
