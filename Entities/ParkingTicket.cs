public class ParkingTicket
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public int ParkingSpotId { get; set; }

    public ParkingSpot? ParkingSpot { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public decimal Amount { get; set; }

    public string FeeType { get; set; }

    public bool IsActive { get; set; } = false;
   
}