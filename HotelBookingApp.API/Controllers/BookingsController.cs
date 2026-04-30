using HotelBookingApp.API.DTOs;
using HotelBookingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.API.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    /// <summary>Get all bookings (admin view).</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _bookingService.GetAllBookingsAsync();
        return Ok(bookings);
    }

    /// <summary>Get a specific booking by ID.</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var booking = await _bookingService.GetBookingByIdAsync(id);
        return booking == null ? NotFound(new { message = $"Booking {id} not found." }) : Ok(booking);
    }

    /// <summary>Create a new booking.</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (booking, error) = await _bookingService.CreateBookingAsync(dto);
        if (error != null)
            return BadRequest(new { message = error });

        return CreatedAtAction(nameof(GetById), new { id = booking!.Id }, booking);
    }

    /// <summary>Cancel a booking.</summary>
    [HttpPatch("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        var (success, error) = await _bookingService.CancelBookingAsync(id);
        if (!success)
            return error == "Booking not found."
                ? NotFound(new { message = error })
                : BadRequest(new { message = error });

        return NoContent();
    }
}
