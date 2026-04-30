namespace HotelBookingApp.API.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int StarRating { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Amenities { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
    public ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
