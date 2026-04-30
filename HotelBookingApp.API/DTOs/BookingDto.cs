using HotelBookingApp.API.Models;

namespace HotelBookingApp.API.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public string HotelCity { get; set; } = string.Empty;
    public string HotelCountry { get; set; } = string.Empty;
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = string.Empty;
    public int HotelRoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string GuestEmail { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int GuestsCount { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateBookingDto
{
    public int HotelId { get; set; }
    public int RoomTypeId { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public string GuestEmail { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int GuestsCount { get; set; }
}
