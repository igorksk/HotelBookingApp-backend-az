using HotelBookingApp.API.DTOs;

namespace HotelBookingApp.API.Services;

public interface IHotelService
{
    Task<IEnumerable<HotelDto>> SearchHotelsAsync(HotelSearchParams searchParams);
    Task<HotelDetailDto?> GetHotelByIdAsync(int id);
    Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync(int hotelId, DateTime? checkIn, DateTime? checkOut, int? guests);
    Task<IEnumerable<string>> GetCountriesAsync();
    Task<IEnumerable<string>> GetCitiesAsync(string? country);
}
