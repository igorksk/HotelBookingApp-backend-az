namespace HotelBookingApp.API.DTOs;

public class RoomTypeDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public List<string> Amenities { get; set; } = new();
    public string ImageUrl { get; set; } = string.Empty;
    public int AvailableRooms { get; set; }
}
