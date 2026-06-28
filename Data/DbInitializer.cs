public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.ParkingLots.Any()) return;

        var parkinglot = new ParkingLot
        {
            Name = "LuckyOne",
            Address = "Shafeeq Mor"
        };
        var floor1 = new Floor
        {
            FloorNumber = 1,
            ParkingLot = parkinglot,

        };
        var floor2 = new Floor
        {
            FloorNumber = 2,
            ParkingLot = parkinglot,

        };
        floor1.ParkingSpots.Add(new CompactSpot { SpotNumber = "C1" });
        floor1.ParkingSpots.Add(new CompactSpot { SpotNumber = "C2" });
        floor1.ParkingSpots.Add(new LargeSpot { SpotNumber = "L1" });
        floor1.ParkingSpots.Add(new HandicappedSpot { SpotNumber = "H1" });

        floor2.ParkingSpots.Add(new CompactSpot { SpotNumber = "C3" });
        floor2.ParkingSpots.Add(new CompactSpot { SpotNumber = "C4" });
        floor2.ParkingSpots.Add(new LargeSpot { SpotNumber = "L2" });
        floor2.ParkingSpots.Add(new HandicappedSpot { SpotNumber = "H2" });
        parkinglot.Floors.Add(floor1);
        parkinglot.Floors.Add(floor2);
        context.ParkingLots.Add(parkinglot);

        context.SaveChanges();




    }



}