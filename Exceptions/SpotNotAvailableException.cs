namespace ParkingLotAPI.Exceptions;

public class SpotNotAvailableException : Exception
{
    public SpotNotAvailableException()
        : base("No suitable parking spot is available.")
    {
    }
}