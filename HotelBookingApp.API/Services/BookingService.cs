using HotelBookingApp.API.Data;
using HotelBookingApp.API.DTOs;
using HotelBookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.API.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _db;

    public BookingService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
    {
        var bookings = await _db.Bookings
            .Include(b => b.Hotel)
            .Include(b => b.RoomType)
            .Include(b => b.HotelRoom)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();

        return bookings.Select(MapToDto);
    }

    public async Task<BookingDto?> GetBookingByIdAsync(int id)
    {
        var booking = await _db.Bookings
            .Include(b => b.Hotel)
            .Include(b => b.RoomType)
            .Include(b => b.HotelRoom)
            .FirstOrDefaultAsync(b => b.Id == id);

        return booking == null ? null : MapToDto(booking);
    }

    public async Task<(BookingDto? booking, string? error)> CreateBookingAsync(CreateBookingDto dto)
    {
        // Validate dates
        var checkIn  = dto.CheckInDate.Date;
        var checkOut = dto.CheckOutDate.Date;

        if (checkOut <= checkIn)
            return (null, "Check-out date must be after check-in date.");

        if (checkIn < DateTime.UtcNow.Date)
            return (null, "Check-in date cannot be in the past.");

        // Validate hotel and room type exist
        var hotel = await _db.Hotels.FindAsync(dto.HotelId);
        if (hotel == null) return (null, "Hotel not found.");

        var roomType = await _db.RoomTypes
            .FirstOrDefaultAsync(r => r.Id == dto.RoomTypeId && r.HotelId == dto.HotelId);
        if (roomType == null) return (null, "Room type not found for this hotel.");

        // Validate guest count
        if (dto.GuestsCount < 1)
            return (null, "Guests count must be at least 1.");

        if (dto.GuestsCount > roomType.Capacity)
            return (null, $"This room type accommodates a maximum of {roomType.Capacity} guests.");

        // Find an available room
        var availableRoom = await _db.HotelRooms
            .Where(hr => hr.RoomTypeId == dto.RoomTypeId && hr.HotelId == dto.HotelId && hr.IsActive)
            .Where(hr => !_db.Bookings.Any(b =>
                b.HotelRoomId == hr.Id &&
                b.Status != BookingStatus.Cancelled &&
                b.CheckInDate < checkOut && b.CheckOutDate > checkIn))
            .FirstOrDefaultAsync();

        if (availableRoom == null)
            return (null, "No rooms available for the selected dates.");

        int nights = (int)(checkOut - checkIn).TotalDays;
        var booking = new Booking
        {
            HotelId     = dto.HotelId,
            RoomTypeId  = dto.RoomTypeId,
            HotelRoomId = availableRoom.Id,
            GuestName   = dto.GuestName.Trim(),
            GuestEmail  = dto.GuestEmail.Trim().ToLowerInvariant(),
            CheckInDate = checkIn,
            CheckOutDate= checkOut,
            GuestsCount = dto.GuestsCount,
            TotalPrice  = roomType.PricePerNight * nights,
            Status      = BookingStatus.Confirmed,
            CreatedAt   = DateTime.UtcNow,
        };

        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();

        // Reload with navigation properties
        booking.Hotel    = hotel;
        booking.RoomType = roomType;
        booking.HotelRoom= availableRoom;

        return (MapToDto(booking), null);
    }

    public async Task<(bool success, string? error)> CancelBookingAsync(int id)
    {
        var booking = await _db.Bookings.FindAsync(id);
        if (booking == null) return (false, "Booking not found.");
        if (booking.Status == BookingStatus.Cancelled) return (false, "Booking is already cancelled.");

        booking.Status = BookingStatus.Cancelled;
        await _db.SaveChangesAsync();
        return (true, null);
    }

    private static BookingDto MapToDto(Booking b) => new()
    {
        Id             = b.Id,
        HotelId        = b.HotelId,
        HotelName      = b.Hotel.Name,
        HotelCity      = b.Hotel.City,
        HotelCountry   = b.Hotel.Country,
        RoomTypeId     = b.RoomTypeId,
        RoomTypeName   = b.RoomType.Name,
        HotelRoomId    = b.HotelRoomId,
        RoomNumber     = b.HotelRoom.RoomNumber,
        GuestName      = b.GuestName,
        GuestEmail     = b.GuestEmail,
        CheckInDate    = b.CheckInDate,
        CheckOutDate   = b.CheckOutDate,
        GuestsCount    = b.GuestsCount,
        TotalPrice     = b.TotalPrice,
        Status         = b.Status.ToString(),
        CreatedAt      = b.CreatedAt,
    };
}
