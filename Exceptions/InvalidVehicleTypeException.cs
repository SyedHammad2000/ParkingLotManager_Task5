namespace ParkingLotAPI.Exceptions;

public class InvalidVehicleTypeException : Exception
{
    public InvalidVehicleTypeException()
        : base("Invalid vehicle type.")
    {
    }
}