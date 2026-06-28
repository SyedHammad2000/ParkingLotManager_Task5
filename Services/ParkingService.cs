using Microsoft.EntityFrameworkCore;
using ParkingLotApi;
using ParkingLotAPI.Exceptions;


public class ParkingService : IParkingService
{
    private readonly AppDbContext _context;
    // private readonly IFeeService _feeService;

    private readonly IFeeCheckService _feeCheck;



    public ParkingService(AppDbContext context, IFeeCheckService feeCheck)
    {
        _context = context;
        _feeCheck = feeCheck;
    }
    public async Task<ParkTicketResponse> ParkAsync(ParkVehicleRequest request)
    {
        Vehicle vehicle = request.VehicleType.ToLower() switch
        {
            "car" => new Car(),
            "truck" => new Truck(),
            "motorcycle" => new Motorcycle(),
            _ => throw new InvalidVehicleTypeException(),

        };

        vehicle.PlateNumber = request.PlateNumber;

        var spots = await _context.ParkingSpots.Include(a => a.Floor).ToListAsync();



        var availableSpot = spots.FirstOrDefault(a => !a.isOccupied && a.CanFit(vehicle));
        if (availableSpot == null)
        {
            throw new SpotNotAvailableException();
        }
        ;



        availableSpot.Occupy();


        _context.Vehicles.Add(vehicle);

        var ticket = new ParkingTicket
        {
            Vehicle = vehicle,
            ParkingSpot = availableSpot,
            EntryTime = DateTime.Now,
            FeeType = request?.FeeType,
            IsActive = true,
        };

        _context.ParkingTickets.Add(ticket);

        await _context.SaveChangesAsync();

        await _context.Entry(ticket)
        .Reference(t => t.Vehicle)
        .LoadAsync();

        await _context.Entry(ticket)
            .Reference(t => t.ParkingSpot)
            .Query()
            .Include(s => s.Floor)
            .LoadAsync();

        return ParkingMapper.ToTicketResponse(ticket);




    }

    public async Task<ParkTicketResponse> ExitAsync(int ticketId)
    {

        var ticket = await _context.ParkingTickets.Include(s => s.Vehicle).Include(a => a.ParkingSpot).ThenInclude(b => b.Floor).FirstOrDefaultAsync(t => t.Id == ticketId);
        // ticket.ParkingSpot.Free();
        if (ticket == null)
        {

           throw new TicketNotFoundException(ticketId);

        }

        if (!ticket.IsActive)
        {
            // return


            throw new TicketAlreadyClosedException();
        }


        ticket.ExitTime = DateTime.Now;

        var feetype = _feeCheck.GetFeeService(ticket.FeeType);

        ticket.Amount = feetype.CalculateFee(ticket.EntryTime, ticket.ExitTime.Value);

        ticket.IsActive = false;

        ticket.ParkingSpot.Free();

        await _context.SaveChangesAsync();





        return ParkingMapper.ToTicketResponse(ticket);
    }

    public async Task<List<ActiveSpotResponse>> GetAsync()
    {
        var activeVehi = await _context.ParkingTickets
            .Include(t => t.Vehicle)
            .Include(t => t.ParkingSpot).ThenInclude(t => t.Floor)
            .Where(t => t.IsActive)
            .ToListAsync();

        return activeVehi.Select(ParkingMapper.ToActiveSpotResponse).ToList();
    }

    public async Task<ParkTicketResponse> GetTicketByIdAsync(int ticketId)
    {
        var ticket = await _context.ParkingTickets.Include(t => t.Vehicle).Include(t => t.ParkingSpot).ThenInclude(t => t.Floor).FirstOrDefaultAsync(t => t.Id == ticketId);

        if (ticket == null)
        {
            throw new  TicketNotFoundException(ticketId);
        }


        return ParkingMapper.ToTicketResponse(ticket);
    }

}