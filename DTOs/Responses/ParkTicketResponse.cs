
public class ParkTicketResponse
{
    public int TicketId { get; set; }

    public string PlateNumber { get; set; } = string.Empty;

    public string SpotNumber { get; set; } = string.Empty;

    public int FloorNumber { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public decimal Amount { get; set; }

    public string FeeType { get; set; }

    public bool IsActive { get; set; }
}