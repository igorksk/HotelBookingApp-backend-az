using HotelBookingApp.API.Data;
using HotelBookingApp.API.DTOs;
using HotelBookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.API.Services;

public class HotelService : IHotelService
{
    private readonly AppDbContext _db;

    public HotelService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<HotelDto>> SearchHotelsAsync(HotelSearchParams p)
    {
        var query = _db.Hotels
            .Include(h => h.RoomTypes)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(p.Country))
            query = query.Where(h => h.Country == p.Country);

        if (!string.IsNullOrWhiteSpace(p.City))
            query = query.Where(h => h.City == p.City);

        if (p.StarRating.HasValue)
            query = query.Where(h => h.StarRating == p.StarRating.Value);

        var hotels = await query.ToListAsync();

        // Filter by guests and price (in-memory after loading)
        var result = new List<HotelDto>();
        foreach (var hotel in hotels)
        {
            var eligibleRooms = hotel.RoomTypes.AsEnumerable();

            if (p.Guests.HasValue)
                eligibleRooms = eligibleRooms.Where(r => r.Capacity >= p.Guests.Value);

            if (p.MinPrice.HasValue)
                eligibleRooms = eligibleRooms.Where(r => r.PricePerNight >= p.MinPrice.Value);

            if (p.MaxPrice.HasValue)
                eligibleRooms = eligibleRooms.Where(r => r.PricePerNight <= p.MaxPrice.Value);

            var roomList = eligibleRooms.ToList();

            // If date filters are applied, check availability
            if (p.CheckIn.HasValue && p.CheckOut.HasValue && roomList.Any())
            {
                var checkIn  = p.CheckIn.Value.Date;
                var checkOut = p.CheckOut.Value.Date;

                var availableRoomTypeIds = await _db.HotelRooms
                    .Where(hr => hr.HotelId == hotel.Id && hr.IsActive)
                    .Where(hr => !_db.Bookings.Any(b =>
                        b.HotelRoomId == hr.Id &&
                        b.Status != BookingStatus.Cancelled &&
                        b.CheckInDate < checkOut && b.CheckOutDate > checkIn))
                    .Select(hr => hr.RoomTypeId)
                    .Distinct()
                    .ToListAsync();

                roomList = roomList.Where(r => availableRoomTypeIds.Contains(r.Id)).ToList();
            }

            if ((p.Guests.HasValue || p.MinPrice.HasValue || p.MaxPrice.HasValue) && !roomList.Any())
                continue;

            var lowestPrice = hotel.RoomTypes.Any()
                ? hotel.RoomTypes.Min(r => r.PricePerNight)
                : 0;

            result.Add(MapToDto(hotel, lowestPrice));
        }

        return result;
    }

    public async Task<HotelDetailDto?> GetHotelByIdAsync(int id)
    {
        var hotel = await _db.Hotels
            .Include(h => h.RoomTypes)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hotel == null) return null;

        var dto = new HotelDetailDto
        {
            Id          = hotel.Id,
            Name        = hotel.Name,
            Description = hotel.Description,
            Country     = hotel.Country,
            City        = hotel.City,
            Address     = hotel.Address,
            StarRating  = hotel.StarRating,
            ImageUrl    = hotel.ImageUrl,
            Amenities   = hotel.Amenities.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList(),
            LowestPrice = hotel.RoomTypes.Any() ? hotel.RoomTypes.Min(r => r.PricePerNight) : 0,
            CreatedAt   = hotel.CreatedAt,
            RoomTypes   = hotel.RoomTypes.Select(MapRoomTypeToDto).ToList(),
        };
        return dto;
    }

    public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync(int hotelId, DateTime? checkIn, DateTime? checkOut, int? guests)
    {
        var roomTypes = await _db.RoomTypes
            .Where(r => r.HotelId == hotelId)
            .ToListAsync();

        var result = new List<RoomTypeDto>();
        foreach (var rt in roomTypes)
        {
            if (guests.HasValue && rt.Capacity < guests.Value) continue;

            int available = 0;
            if (checkIn.HasValue && checkOut.HasValue)
            {
                var ci = checkIn.Value.Date;
                var co = checkOut.Value.Date;
                available = await _db.HotelRooms
                    .Where(hr => hr.RoomTypeId == rt.Id && hr.IsActive)
                    .Where(hr => !_db.Bookings.Any(b =>
                        b.HotelRoomId == hr.Id &&
                        b.Status != BookingStatus.Cancelled &&
                        b.CheckInDate < co && b.CheckOutDate > ci))
                    .CountAsync();
            }
            else
            {
                available = await _db.HotelRooms
                    .CountAsync(hr => hr.RoomTypeId == rt.Id && hr.IsActive);
            }

            var dto = MapRoomTypeToDto(rt);
            dto.AvailableRooms = available;
            result.Add(dto);
        }

        return result;
    }

    public async Task<IEnumerable<string>> GetCountriesAsync() =>
        await _db.Hotels.Select(h => h.Country).Distinct().OrderBy(c => c).ToListAsync();

    public async Task<IEnumerable<string>> GetCitiesAsync(string? country)
    {
        var query = _db.Hotels.AsQueryable();
        if (!string.IsNullOrWhiteSpace(country))
            query = query.Where(h => h.Country == country);
        return await query.Select(h => h.City).Distinct().OrderBy(c => c).ToListAsync();
    }

    private static HotelDto MapToDto(Hotel hotel, decimal lowestPrice) => new()
    {
        Id          = hotel.Id,
        Name        = hotel.Name,
        Description = hotel.Description,
        Country     = hotel.Country,
        City        = hotel.City,
        Address     = hotel.Address,
        StarRating  = hotel.StarRating,
        ImageUrl    = hotel.ImageUrl,
        Amenities   = hotel.Amenities.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList(),
        LowestPrice = lowestPrice,
    };

    private static RoomTypeDto MapRoomTypeToDto(RoomType rt) => new()
    {
        Id            = rt.Id,
        HotelId       = rt.HotelId,
        Name          = rt.Name,
        Description   = rt.Description,
        Capacity      = rt.Capacity,
        PricePerNight = rt.PricePerNight,
        Amenities     = rt.Amenities.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList(),
        ImageUrl      = rt.ImageUrl,
    };
}
