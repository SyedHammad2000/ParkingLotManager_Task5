namespace ParkingLotAPI.Exceptions;

public class TicketNotFoundException : Exception
{
    public TicketNotFoundException(int ticketId)
        : base($"Ticket with Id {ticketId} was not found.")
    {
    }
}