using HotelBookingApp.API.DTOs;
using HotelBookingApp.API.Models;

namespace HotelBookingApp.API.Services;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
    Task<BookingDto?> GetBookingByIdAsync(int id);
    Task<(BookingDto? booking, string? error)> CreateBookingAsync(CreateBookingDto dto);
    Task<(bool success, string? error)> CancelBookingAsync(int id);
}
