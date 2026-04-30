using HotelBookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<HotelRoom> HotelRooms => Set<HotelRoom>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hotel>(e =>
        {
            e.HasKey(h => h.Id);
            e.HasMany(h => h.RoomTypes).WithOne(r => r.Hotel).HasForeignKey(r => r.HotelId);
            e.HasMany(h => h.HotelRooms).WithOne(r => r.Hotel).HasForeignKey(r => r.HotelId);
            e.HasMany(h => h.Bookings).WithOne(b => b.Hotel).HasForeignKey(b => b.HotelId);
        });

        modelBuilder.Entity<RoomType>(e =>
        {
            e.HasKey(r => r.Id);
            e.HasMany(r => r.HotelRooms).WithOne(hr => hr.RoomType).HasForeignKey(hr => hr.RoomTypeId);
            e.HasMany(r => r.Bookings).WithOne(b => b.RoomType).HasForeignKey(b => b.RoomTypeId);
        });

        modelBuilder.Entity<HotelRoom>(e =>
        {
            e.HasKey(hr => hr.Id);
            e.HasMany(hr => hr.Bookings).WithOne(b => b.HotelRoom).HasForeignKey(b => b.HotelRoomId);
        });

        modelBuilder.Entity<Booking>(e =>
        {
            e.HasKey(b => b.Id);
        });
    }
}
