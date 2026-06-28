namespace ParkingLotAPI.Exceptions;

public class TicketAlreadyClosedException : Exception
{
    public TicketAlreadyClosedException()
        : base("This parking ticket is already closed.")
    {
    }
}