using HotelBookingApp.API.DTOs;
using HotelBookingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.API.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    /// <summary>Search hotels with optional filters.</summary>
    [HttpGet]
    public async Task<IActionResult> GetHotels([FromQuery] HotelSearchParams searchParams)
    {
        var hotels = await _hotelService.SearchHotelsAsync(searchParams);
        return Ok(hotels);
    }

    /// <summary>Get a single hotel with full details.</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetHotel(int id)
    {
        var hotel = await _hotelService.GetHotelByIdAsync(id);
        return hotel == null ? NotFound(new { message = $"Hotel {id} not found." }) : Ok(hotel);
    }

    /// <summary>Get available room types for a hotel, optionally filtered by dates and guests.</summary>
    [HttpGet("{id:int}/room-types")]
    public async Task<IActionResult> GetRoomTypes(
        int id,
        [FromQuery] DateTime? checkIn,
        [FromQuery] DateTime? checkOut,
        [FromQuery] int? guests)
    {
        var roomTypes = await _hotelService.GetRoomTypesAsync(id, checkIn, checkOut, guests);
        return Ok(roomTypes);
    }

    /// <summary>Get all distinct countries that have hotels.</summary>
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _hotelService.GetCountriesAsync();
        return Ok(countries);
    }

    /// <summary>Get cities, optionally filtered by country.</summary>
    [HttpGet("cities")]
    public async Task<IActionResult> GetCities([FromQuery] string? country)
    {
        var cities = await _hotelService.GetCitiesAsync(country);
        return Ok(cities);
    }
}
