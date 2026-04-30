# HotelBookingApp — Backend API

ASP.NET Core 8 Web API for the StayEasy hotel booking application. Uses Entity Framework Core In-Memory for zero-cost local development and demo deployments.

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 8 |
| ORM | Entity Framework Core 8 (In-Memory) |
| API Docs | Swagger / Swashbuckle |
| Hosting target | Azure App Service |

## Project Structure

```
HotelBookingApp.API/
├── Controllers/
│   ├── HotelsController.cs      # Hotel search and room type endpoints
│   └── BookingsController.cs    # Booking CRUD endpoints
├── Data/
│   ├── AppDbContext.cs          # EF Core DbContext
│   └── DataSeeder.cs           # Seed: 20 hotels, 469 rooms, 25 bookings
├── DTOs/
│   ├── HotelDto.cs             # HotelDto, HotelDetailDto, HotelSearchParams
│   ├── RoomTypeDto.cs          # RoomTypeDto with availability
│   └── BookingDto.cs           # BookingDto, CreateBookingDto
├── Models/
│   ├── Hotel.cs
│   ├── RoomType.cs
│   ├── HotelRoom.cs
│   └── Booking.cs              # includes BookingStatus enum
├── Services/
│   ├── IHotelService.cs / HotelService.cs
│   └── IBookingService.cs / BookingService.cs
├── Program.cs                  # DI, CORS, Swagger, seeding
└── appsettings.json            # AllowedOrigins CORS config
```

## Running Locally

```bash
cd backend/HotelBookingApp.API
dotnet run --urls http://localhost:5000
```

- Swagger UI: http://localhost:5000/swagger
- Health check: http://localhost:5000/health

## API Endpoints

### Hotels

| Method | Path | Description |
|---|---|---|
| `GET` | `/api/hotels` | Search hotels (country, city, starRating, minPrice, maxPrice, guests, checkIn, checkOut) |
| `GET` | `/api/hotels/{id}` | Hotel detail with room types |
| `GET` | `/api/hotels/{id}/room-types` | Available room types (optionally filtered by dates/guests) |
| `GET` | `/api/hotels/countries` | List of all countries |
| `GET` | `/api/hotels/cities?country=` | Cities, optionally filtered by country |

### Bookings

| Method | Path | Description |
|---|---|---|
| `GET` | `/api/bookings` | All bookings |
| `GET` | `/api/bookings/{id}` | Single booking |
| `POST` | `/api/bookings` | Create booking |
| `PATCH` | `/api/bookings/{id}/cancel` | Cancel booking |

### Create Booking Payload

```json
{
  "hotelId": 1,
  "roomTypeId": 3,
  "guestName": "Jane Doe",
  "guestEmail": "jane@example.com",
  "checkInDate": "2026-06-01",
  "checkOutDate": "2026-06-05",
  "guestsCount": 2
}
```

## Seed Data

20 hotels across 6 countries seeded at startup:

| Country | Cities |
|---|---|
| Ukraine | Kyiv (×2), Lviv (×2), Odesa (×1) |
| Poland | Warsaw (×2), Kraków (×1) |
| Germany | Berlin (×2), Munich (×1) |
| France | Paris (×2), Nice (×1) |
| Italy | Rome (×2), Milan (×1) |
| Spain | Barcelona (×2), Madrid (×1) |

Each hotel has 5 room types (Standard → Presidential Suite) and 3–8 physical rooms per type.

## CORS Configuration

Allowed origins are read from `appsettings.json`:

```json
"AllowedOrigins": [
  "http://localhost:5173",
  "http://localhost:3000",
  "https://*.azurestaticapps.net",
  "https://*.azurewebsites.net"
]
```

## Azure Deployment

1. Publish to Azure App Service (.NET 8 runtime)
2. Add app setting `AllowedOrigins__0 = https://<your-static-web-app>.azurestaticapps.net`
3. The In-Memory database reseeds on each cold start — no database provisioning needed
