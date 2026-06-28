public static class ParkingMapper
{
    public static ParkTicketResponse ToTicketResponse(ParkingTicket ticket)
    {
        return new ParkTicketResponse
        {
            TicketId = ticket.Id,
            PlateNumber = ticket.Vehicle.PlateNumber,
            SpotNumber = ticket.ParkingSpot?.SpotNumber,
            FloorNumber = ticket.ParkingSpot.Floor.FloorNumber,
            EntryTime = ticket.EntryTime,
            ExitTime = ticket.ExitTime,
            Amount = ticket.Amount,
            FeeType = ticket.FeeType,
            IsActive = ticket.IsActive,


        };

    }

    public static ActiveSpotResponse ToActiveSpotResponse(ParkingTicket ticket)
    {
        return new ActiveSpotResponse
        {
            PlateNumber = ticket.Vehicle.PlateNumber,
            SpotNumber = ticket.ParkingSpot.SpotNumber,
            FloorNumber = ticket.ParkingSpot.Floor.FloorNumber,
            EntryTime = ticket.EntryTime

        };
    }
}