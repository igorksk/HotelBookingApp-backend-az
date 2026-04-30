using HotelBookingApp.API.Models;

namespace HotelBookingApp.API.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Hotels.Any()) return;

        // ── Hotels ──────────────────────────────────────────────────────────────
        var hotels = new List<Hotel>
        {
            // Ukraine – Kyiv
            new Hotel { Id = 1,  Name = "Grand Kyiv Palace",        Description = "A luxurious five-star hotel in the heart of Kyiv offering world-class service, panoramic city views and fine dining.", Country = "Ukraine", City = "Kyiv",    Address = "1 Khreshchatyk Street",      StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?w=800", Amenities = "Free WiFi,Spa,Pool,Gym,Restaurant,Bar,Concierge,Valet Parking",   CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 2,  Name = "Kyiv Business Inn",         Description = "Modern business hotel near the financial district with fully equipped conference rooms and fast broadband.",              Country = "Ukraine", City = "Kyiv",    Address = "45 Velyka Vasylkivska St",   StarRating = 3, ImageUrl = "https://images.unsplash.com/photo-1582719508461-905c673771fd?w=800", Amenities = "Free WiFi,Business Centre,Restaurant,Gym",                       CreatedAt = DateTime.UtcNow },

            // Ukraine – Lviv
            new Hotel { Id = 3,  Name = "Lviv Heritage Hotel",       Description = "Charming boutique hotel set inside a restored 19th-century townhouse steps from the UNESCO Old Town.",                 Country = "Ukraine", City = "Lviv",    Address = "7 Rynok Square",             StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?w=800", Amenities = "Free WiFi,Breakfast Included,Bar,Tour Desk",                     CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 4,  Name = "Lviv Cozy Rooms",           Description = "Affordable guesthouse with cozy rooms and genuine Ukrainian hospitality in a quiet residential area.",                  Country = "Ukraine", City = "Lviv",    Address = "22 Franka Street",           StarRating = 2, ImageUrl = "https://images.unsplash.com/photo-1445019980597-93fa8acb246c?w=800", Amenities = "Free WiFi,Breakfast Included,Luggage Storage",                   CreatedAt = DateTime.UtcNow },

            // Ukraine – Odesa
            new Hotel { Id = 5,  Name = "Black Sea Resort & Spa",    Description = "Beachfront resort on the Black Sea coast featuring water sports, a full-service spa and sunset terrace dining.",        Country = "Ukraine", City = "Odesa",   Address = "10 Primorsky Boulevard",     StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d?w=800", Amenities = "Beach Access,Pool,Spa,Water Sports,Restaurant,Bar,Free WiFi",    CreatedAt = DateTime.UtcNow },

            // Poland – Warsaw
            new Hotel { Id = 6,  Name = "Warsaw Royal Suites",       Description = "Elegant hotel near Warsaw Old Town with spacious suites, rooftop bar and curated cultural tours.",                      Country = "Poland",  City = "Warsaw",  Address = "18 Nowy Swiat Street",       StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1551882547-ff40c63fe5fa?w=800", Amenities = "Free WiFi,Rooftop Bar,Spa,Gym,Restaurant,Concierge",             CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 7,  Name = "Warsaw Central Hotel",      Description = "Contemporary hotel adjacent to Warsaw Central Station offering practical amenities for business and leisure travellers.", Country = "Poland",  City = "Warsaw",  Address = "5 Aleje Jerozolimskie",      StarRating = 3, ImageUrl = "https://images.unsplash.com/photo-1534438327276-14e5300c3a48?w=800", Amenities = "Free WiFi,Restaurant,Business Centre,Gym",                       CreatedAt = DateTime.UtcNow },

            // Poland – Krakow
            new Hotel { Id = 8,  Name = "Krakow Old Town Boutique",  Description = "Intimate boutique hotel within walking distance of Wawel Castle, featuring hand-painted ceilings and original stone walls.", Country = "Poland", City = "Krakow", Address = "3 Grodzka Street",           StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1590381105924-c72589b9ef3f?w=800", Amenities = "Free WiFi,Breakfast Included,Bar,Tour Desk,Bike Rental",         CreatedAt = DateTime.UtcNow },

            // Germany – Berlin
            new Hotel { Id = 9,  Name = "Berlin Mitte Grand",        Description = "Stylish design hotel in Berlin-Mitte with minimalist décor, a rooftop bar overlooking the TV Tower and a celebrated brunch.",  Country = "Germany", City = "Berlin", Address = "12 Unter den Linden",       StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?w=800", Amenities = "Free WiFi,Rooftop Bar,Spa,Pool,Gym,Restaurant,Valet Parking",    CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 10, Name = "Berlin Budget Stay",         Description = "Clean and affordable rooms near public transport links, ideal for budget-conscious travellers exploring Berlin.",              Country = "Germany", City = "Berlin", Address = "66 Friedrichstrasse",        StarRating = 2, ImageUrl = "https://images.unsplash.com/photo-1483058712412-4245e9b90334?w=800", Amenities = "Free WiFi,24h Reception,Luggage Storage",                        CreatedAt = DateTime.UtcNow },

            // Germany – Munich
            new Hotel { Id = 11, Name = "Munich Bavarian Lodge",      Description = "Traditional Bavarian-style hotel with oak-panelled rooms, beer garden and proximity to Marienplatz.",                       Country = "Germany", City = "Munich", Address = "8 Maximilianstrasse",        StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1568084680786-a84f91d1153c?w=800", Amenities = "Free WiFi,Beer Garden,Restaurant,Gym,Concierge",                 CreatedAt = DateTime.UtcNow },

            // France – Paris
            new Hotel { Id = 12, Name = "Paris Lumière Hotel",        Description = "Chic Haussmann-era hotel on the Right Bank boasting Eiffel Tower views, a Michelin-starred restaurant and private garden.",  Country = "France",  City = "Paris",  Address = "24 Avenue des Champs-Élysées", StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?w=800", Amenities = "Free WiFi,Fine Dining,Spa,Pool,Gym,Concierge,Valet Parking",     CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 13, Name = "Montmartre Maison",           Description = "Romantic guesthouse perched on the Montmartre hill offering artist studio-themed rooms and panoramic Paris skyline views.",   Country = "France",  City = "Paris",  Address = "14 Rue Lepic",               StarRating = 3, ImageUrl = "https://images.unsplash.com/photo-1549294413-26f195200c16?w=800", Amenities = "Free WiFi,Breakfast Included,Bar,Tour Desk",                     CreatedAt = DateTime.UtcNow },

            // France – Nice
            new Hotel { Id = 14, Name = "Côte d'Azur Palace",         Description = "Glamorous seafront palace on the Promenade des Anglais with private beach, infinity pool and celebrated French cuisine.",      Country = "France",  City = "Nice",   Address = "5 Promenade des Anglais",    StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1560347876-aeef00ee58a1?w=800", Amenities = "Private Beach,Pool,Spa,Free WiFi,Restaurant,Bar,Concierge",      CreatedAt = DateTime.UtcNow },

            // Italy – Rome
            new Hotel { Id = 15, Name = "Roma Imperiale",              Description = "Grand hotel a short walk from the Colosseum featuring opulent décor, terrace dining and guided heritage tours.",               Country = "Italy",   City = "Rome",   Address = "9 Via Veneto",               StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1455587734955-081b22074882?w=800", Amenities = "Free WiFi,Fine Dining,Spa,Pool,Gym,Heritage Tours,Concierge",    CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 16, Name = "Trastevere Inn",               Description = "Cosy inn nestled in the cobblestone streets of Trastevere, offering authentic Roman atmosphere at an accessible price.",       Country = "Italy",   City = "Rome",   Address = "3 Piazza Santa Maria",       StarRating = 3, ImageUrl = "https://images.unsplash.com/photo-1477120128765-a0528148fed6?w=800", Amenities = "Free WiFi,Breakfast Included,Bar",                               CreatedAt = DateTime.UtcNow },

            // Italy – Milan
            new Hotel { Id = 17, Name = "Milano Fashion Suites",       Description = "Design-forward hotel in the Brera district, minutes from La Scala and the Quadrilatero della Moda fashion quarter.",           Country = "Italy",   City = "Milan",  Address = "17 Via Montenapoleone",      StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?w=800", Amenities = "Free WiFi,Gym,Restaurant,Bar,Concierge,Valet Parking",           CreatedAt = DateTime.UtcNow },

            // Spain – Barcelona
            new Hotel { Id = 18, Name = "Barcelona Gaudí Retreat",     Description = "Modernista-inspired hotel in Eixample with rooftop terrace offering views of Sagrada Família and craft cocktail bar.",          Country = "Spain",   City = "Barcelona", Address = "88 Passeig de Gràcia",   StarRating = 4, ImageUrl = "https://images.unsplash.com/photo-1506059612708-99d6c258160e?w=800", Amenities = "Free WiFi,Rooftop Terrace,Bar,Gym,Restaurant,Tour Desk",         CreatedAt = DateTime.UtcNow },
            new Hotel { Id = 19, Name = "El Born Budget Hotel",         Description = "Vibrant budget hotel in the trendy El Born neighbourhood, surrounded by tapas bars, art galleries and boutiques.",              Country = "Spain",   City = "Barcelona", Address = "11 Carrer del Rec",      StarRating = 2, ImageUrl = "https://images.unsplash.com/photo-1526400473556-aac12354f3db?w=800", Amenities = "Free WiFi,24h Reception,Luggage Storage",                        CreatedAt = DateTime.UtcNow },

            // Spain – Madrid
            new Hotel { Id = 20, Name = "Madrid Gran Vía Hotel",       Description = "Iconic landmark hotel on the Gran Vía boulevard with Art Deco interiors, rooftop pool and fine Castilian dining.",              Country = "Spain",   City = "Madrid", Address = "50 Gran Vía",                StarRating = 5, ImageUrl = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?w=800", Amenities = "Free WiFi,Rooftop Pool,Spa,Gym,Fine Dining,Bar,Concierge",       CreatedAt = DateTime.UtcNow },
        };
        context.Hotels.AddRange(hotels);
        context.SaveChanges();

        // ── Room Types (5 per hotel) ─────────────────────────────────────────────
        var roomTypes = new List<RoomType>();
        int rtId = 1;

        var roomTypeTemplates = new[]
        {
            new { Name = "Standard Room",      Desc = "Comfortable room with all essential amenities for a pleasant stay.", Capacity = 2, BasePriceMult = 1.0m,  Amenities = "Free WiFi,Air Conditioning,TV,Safe,Minibar",                     Img = "https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=600" },
            new { Name = "Deluxe Room",         Desc = "Spacious deluxe room with upgraded furnishings and garden or city views.", Capacity = 2, BasePriceMult = 1.5m,  Amenities = "Free WiFi,Air Conditioning,TV,Safe,Minibar,Coffee Machine,Bathrobe", Img = "https://images.unsplash.com/photo-1618773928121-c32242e63f39?w=600" },
            new { Name = "Family Suite",        Desc = "Generous suite with a separate living area ideal for families with children.", Capacity = 4, BasePriceMult = 2.0m,  Amenities = "Free WiFi,Air Conditioning,TV,Safe,Minibar,Sofa Bed,Kids Amenities",  Img = "https://images.unsplash.com/photo-1590490360182-c33d57733427?w=600" },
            new { Name = "Business Suite",      Desc = "Executive suite featuring a dedicated work desk, meeting table and premium business services.", Capacity = 2, BasePriceMult = 2.5m,  Amenities = "Free WiFi,Air Conditioning,TV,Safe,Minibar,Work Desk,Coffee Machine,Printer", Img = "https://images.unsplash.com/photo-1584132967334-10e028bd69f7?w=600" },
            new { Name = "Presidential Suite",  Desc = "The pinnacle of luxury: a multi-room suite with panoramic views, private butler and exclusive amenities.", Capacity = 6, BasePriceMult = 5.0m,  Amenities = "Free WiFi,Private Butler,Jacuzzi,Panoramic View,Minibar,Kitchen,Meeting Room,Bathrobe,Slippers", Img = "https://images.unsplash.com/photo-1631049421450-348ccd7f8949?w=600" },
        };

        // Base prices per hotel star rating
        var basePrices = new Dictionary<int, decimal> { { 2, 50m }, { 3, 90m }, { 4, 150m }, { 5, 250m } };

        foreach (var hotel in hotels)
        {
            var basePrice = basePrices[hotel.StarRating];
            foreach (var template in roomTypeTemplates)
            {
                roomTypes.Add(new RoomType
                {
                    Id           = rtId++,
                    HotelId      = hotel.Id,
                    Name         = template.Name,
                    Description  = template.Desc,
                    Capacity     = template.Capacity,
                    PricePerNight = Math.Round(basePrice * template.BasePriceMult, 0),
                    Amenities    = template.Amenities,
                    ImageUrl     = template.Img,
                });
            }
        }
        context.RoomTypes.AddRange(roomTypes);
        context.SaveChanges();

        // ── Hotel Rooms (3–8 physical rooms per room type) ──────────────────────
        var hotelRooms = new List<HotelRoom>();
        int hrId = 1;
        var rng = new Random(42);

        foreach (var rt in roomTypes)
        {
            // Presidential suites are rare (1–2), others 3–8
            int count = rt.Name == "Presidential Suite" ? rng.Next(1, 3) : rng.Next(3, 9);
            for (int i = 1; i <= count; i++)
            {
                int floor = rt.Name switch
                {
                    "Presidential Suite" => rng.Next(8, 16),
                    "Business Suite"     => rng.Next(5, 12),
                    "Family Suite"       => rng.Next(3, 8),
                    "Deluxe Room"        => rng.Next(2, 6),
                    _                    => rng.Next(1, 5)
                };
                hotelRooms.Add(new HotelRoom
                {
                    Id         = hrId++,
                    HotelId    = rt.HotelId,
                    RoomTypeId = rt.Id,
                    RoomNumber = $"{floor}{i:D2}",
                    Floor      = floor,
                    IsActive   = true,
                });
            }
        }
        context.HotelRooms.AddRange(hotelRooms);
        context.SaveChanges();

        // ── Bookings (25 existing bookings) ─────────────────────────────────────
        var bookings = new List<Booking>();
        int bId = 1;
        var today = DateTime.UtcNow.Date;

        // Helper: pick a random active room for a given hotel + roomType
        HotelRoom? PickRoom(int hotelId, int roomTypeId, DateTime checkIn, DateTime checkOut)
        {
            var candidates = hotelRooms
                .Where(r => r.HotelId == hotelId && r.RoomTypeId == roomTypeId && r.IsActive)
                .ToList();
            foreach (var candidate in candidates.OrderBy(_ => rng.Next()))
            {
                bool overlaps = bookings.Any(b =>
                    b.HotelRoomId == candidate.Id &&
                    b.Status != BookingStatus.Cancelled &&
                    b.CheckInDate < checkOut && b.CheckOutDate > checkIn);
                if (!overlaps) return candidate;
            }
            return null;
        }

        // Gather first room type IDs (Standard) per hotel for simple seeding
        var standardRTs = roomTypes.Where(r => r.Name == "Standard Room").ToList();
        var deluxeRTs   = roomTypes.Where(r => r.Name == "Deluxe Room").ToList();
        var familyRTs   = roomTypes.Where(r => r.Name == "Family Suite").ToList();
        var businessRTs = roomTypes.Where(r => r.Name == "Business Suite").ToList();
        var presidentialRTs = roomTypes.Where(r => r.Name == "Presidential Suite").ToList();

        // Past bookings
        var pastBookingData = new[]
        {
            (1,  standardRTs.First(r=>r.HotelId==1).Id,  "Alice Johnson",    "alice@example.com",    today.AddDays(-30), today.AddDays(-25), 2, BookingStatus.Confirmed),
            (1,  deluxeRTs.First(r=>r.HotelId==1).Id,    "Bob Smith",        "bob@example.com",      today.AddDays(-20), today.AddDays(-17), 2, BookingStatus.Confirmed),
            (2,  standardRTs.First(r=>r.HotelId==2).Id,  "Carol White",      "carol@example.com",    today.AddDays(-15), today.AddDays(-12), 1, BookingStatus.Confirmed),
            (3,  deluxeRTs.First(r=>r.HotelId==3).Id,    "David Brown",      "david@example.com",    today.AddDays(-40), today.AddDays(-35), 2, BookingStatus.Confirmed),
            (5,  standardRTs.First(r=>r.HotelId==5).Id,  "Emma Wilson",      "emma@example.com",     today.AddDays(-10), today.AddDays(-7),  2, BookingStatus.Cancelled),
            (6,  businessRTs.First(r=>r.HotelId==6).Id,  "Frank Miller",     "frank@example.com",    today.AddDays(-50), today.AddDays(-47), 1, BookingStatus.Confirmed),
            (9,  presidentialRTs.First(r=>r.HotelId==9).Id, "Grace Lee",     "grace@example.com",    today.AddDays(-60), today.AddDays(-55), 3, BookingStatus.Confirmed),
            (12, deluxeRTs.First(r=>r.HotelId==12).Id,   "Henry Taylor",     "henry@example.com",    today.AddDays(-25), today.AddDays(-21), 2, BookingStatus.Confirmed),
            (15, familyRTs.First(r=>r.HotelId==15).Id,   "Isabella Martin",  "isabella@example.com", today.AddDays(-45), today.AddDays(-40), 4, BookingStatus.Confirmed),
            (18, standardRTs.First(r=>r.HotelId==18).Id, "James Davis",      "james@example.com",    today.AddDays(-18), today.AddDays(-15), 2, BookingStatus.Cancelled),
        };

        // Current / upcoming bookings
        var futureBookingData = new[]
        {
            (1,  deluxeRTs.First(r=>r.HotelId==1).Id,    "Olivia Anderson",  "olivia@example.com",   today.AddDays(5),  today.AddDays(10), 2, BookingStatus.Confirmed),
            (1,  familyRTs.First(r=>r.HotelId==1).Id,    "Noah Thomas",      "noah@example.com",     today.AddDays(3),  today.AddDays(8),  4, BookingStatus.Confirmed),
            (2,  standardRTs.First(r=>r.HotelId==2).Id,  "Sophia Jackson",   "sophia@example.com",   today.AddDays(1),  today.AddDays(4),  1, BookingStatus.Confirmed),
            (3,  standardRTs.First(r=>r.HotelId==3).Id,  "Liam Harris",      "liam@example.com",     today.AddDays(7),  today.AddDays(12), 2, BookingStatus.Confirmed),
            (5,  deluxeRTs.First(r=>r.HotelId==5).Id,    "Ava Martinez",     "ava@example.com",      today.AddDays(14), today.AddDays(21), 2, BookingStatus.Confirmed),
            (6,  standardRTs.First(r=>r.HotelId==6).Id,  "Ethan Garcia",     "ethan@example.com",    today.AddDays(2),  today.AddDays(6),  2, BookingStatus.Confirmed),
            (8,  familyRTs.First(r=>r.HotelId==8).Id,    "Mia Rodriguez",    "mia@example.com",      today.AddDays(20), today.AddDays(27), 3, BookingStatus.Confirmed),
            (9,  businessRTs.First(r=>r.HotelId==9).Id,  "William Lewis",    "william@example.com",  today.AddDays(10), today.AddDays(14), 1, BookingStatus.Confirmed),
            (11, standardRTs.First(r=>r.HotelId==11).Id, "Charlotte Walker", "charlotte@example.com",today.AddDays(6),  today.AddDays(9),  2, BookingStatus.Confirmed),
            (12, presidentialRTs.First(r=>r.HotelId==12).Id,"Benjamin Hall",  "benjamin@example.com", today.AddDays(30), today.AddDays(37), 2, BookingStatus.Confirmed),
            (14, deluxeRTs.First(r=>r.HotelId==14).Id,   "Amelia Allen",     "amelia@example.com",   today.AddDays(15), today.AddDays(22), 2, BookingStatus.Confirmed),
            (16, standardRTs.First(r=>r.HotelId==16).Id, "Lucas Young",      "lucas@example.com",    today.AddDays(8),  today.AddDays(11), 1, BookingStatus.Confirmed),
            (17, businessRTs.First(r=>r.HotelId==17).Id, "Harper Hernandez", "harper@example.com",   today.AddDays(4),  today.AddDays(7),  2, BookingStatus.Confirmed),
            (18, deluxeRTs.First(r=>r.HotelId==18).Id,   "Evelyn King",      "evelyn@example.com",   today.AddDays(12), today.AddDays(18), 2, BookingStatus.Confirmed),
            (20, presidentialRTs.First(r=>r.HotelId==20).Id,"Alexander Wright","alex@example.com",   today.AddDays(25), today.AddDays(32), 4, BookingStatus.Confirmed),
        };

        foreach (var (hotelId, rtId2, name, email, checkIn, checkOut, guests, status) in pastBookingData)
        {
            var rt = roomTypes.First(r => r.Id == rtId2);
            var room = PickRoom(hotelId, rt.Id, checkIn, checkOut);
            if (room == null) continue;
            int nights = (int)(checkOut - checkIn).TotalDays;
            bookings.Add(new Booking
            {
                Id = bId++, HotelId = hotelId, RoomTypeId = rt.Id, HotelRoomId = room.Id,
                GuestName = name, GuestEmail = email, CheckInDate = checkIn, CheckOutDate = checkOut,
                GuestsCount = guests, TotalPrice = rt.PricePerNight * nights, Status = status,
                CreatedAt = today.AddDays(-rng.Next(1, 60)),
            });
        }

        foreach (var (hotelId, rtId2, name, email, checkIn, checkOut, guests, status) in futureBookingData)
        {
            var rt = roomTypes.First(r => r.Id == rtId2);
            var room = PickRoom(hotelId, rt.Id, checkIn, checkOut);
            if (room == null) continue;
            int nights = (int)(checkOut - checkIn).TotalDays;
            bookings.Add(new Booking
            {
                Id = bId++, HotelId = hotelId, RoomTypeId = rt.Id, HotelRoomId = room.Id,
                GuestName = name, GuestEmail = email, CheckInDate = checkIn, CheckOutDate = checkOut,
                GuestsCount = guests, TotalPrice = rt.PricePerNight * nights, Status = status,
                CreatedAt = today.AddDays(-rng.Next(0, 10)),
            });
        }

        context.Bookings.AddRange(bookings);
        context.SaveChanges();
    }
}
