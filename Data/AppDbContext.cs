using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public DbSet<ParkingLot> ParkingLots => Set<ParkingLot>();
    public DbSet<Floor> Floors => Set<Floor>();
    public DbSet<ParkingSpot> ParkingSpots => Set<ParkingSpot>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<ParkingTicket> ParkingTickets => Set<ParkingTicket>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ParkingSpot>().HasDiscriminator<string>("SpotType").HasValue<CompactSpot>("Compact").HasValue<LargeSpot>("Large").HasValue<HandicappedSpot>("Handicapped");


        modelBuilder.Entity<Vehicle>().HasDiscriminator<string>("VehicleType").HasValue<Car>("Car").HasValue<Motorcycle>("Motorcycle").HasValue<Truck>("Truck");


    
    }

}