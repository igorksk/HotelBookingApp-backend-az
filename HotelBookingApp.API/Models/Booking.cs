namespace HotelBookingApp.API.Models;

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled
}

public class Booking
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int RoomTypeId { get; set; }
    public int HotelRoomId { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public string GuestEmail { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int GuestsCount { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Hotel Hotel { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
    public HotelRoom HotelRoom { get; set; } = null!;
}
