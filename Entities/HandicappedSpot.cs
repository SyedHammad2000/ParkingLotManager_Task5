

public class HandicappedSpot : ParkingSpot
{
     public override bool CanFit(Vehicle vehicle)
    {
        return vehicle is Car || vehicle is Motorcycle;
    }
}