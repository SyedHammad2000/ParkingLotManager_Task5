

public class CompactSpot : ParkingSpot
{
    public override bool CanFit(Vehicle vehicle)
    {
        return vehicle is Car || vehicle is Motorcycle;
    }
}