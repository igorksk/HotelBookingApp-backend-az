namespace HotelBookingApp.API.DTOs;

public class HotelDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int StarRating { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> Amenities { get; set; } = new();
    public decimal LowestPrice { get; set; }
}

public class HotelDetailDto : HotelDto
{
    public List<RoomTypeDto> RoomTypes { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class HotelSearchParams
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public int? StarRating { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? Guests { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
}
