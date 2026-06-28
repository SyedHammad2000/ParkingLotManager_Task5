public abstract class Vehicle
{
    public int Id { get; set; }

    public string PlateNumber { get; set; }=string.Empty;

    public ICollection<ParkingTicket> ParkingTickets { get; set; } = new List<ParkingTicket>();
}