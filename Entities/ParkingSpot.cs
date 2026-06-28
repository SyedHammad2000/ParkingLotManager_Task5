public abstract class ParkingSpot
{
    public int Id { get; set; }
    public string SpotNumber { get; set; } = string.Empty;

    public int FloorId { get; set; }

    public Floor? Floor { get; set; }

    public bool isOccupied { get; set; }
    public ICollection<ParkingTicket> ParkingTickets { get; set; } = new List<ParkingTicket>();

    public void Occupy()
    {
        if (isOccupied)
        {
            throw new Exception("");
        }
        isOccupied = true;
    }
    public void Free()
    {
        if (!isOccupied)
        {
            throw new Exception("");

        }
        isOccupied = false;
    }

    public abstract bool CanFit(Vehicle vehicle);


}

