public interface IParkingService
{
    Task<ParkTicketResponse> ParkAsync(ParkVehicleRequest request);

    Task<ParkTicketResponse> ExitAsync(int ticketId);

    Task<List<ActiveSpotResponse>> GetAsync();

    Task<ParkTicketResponse> GetTicketByIdAsync(int ticketId);




}