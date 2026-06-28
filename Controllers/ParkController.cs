using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
// using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]


public class ParkController : ControllerBase
{
    private readonly IParkingService _parkingService;

    public ParkController(IParkingService parkingService)
    {
        _parkingService = parkingService;
    }
    [Authorize]
    [HttpPost("park")]
    public async Task<IActionResult> ParkAsync([FromBody]ParkVehicleRequest request)
    {
        var result = await _parkingService.ParkAsync(request);
        return Ok(result);

    }

    [Authorize]
    [HttpPost("exit/{id}")]
    public async Task<IActionResult> ExitById([FromRoute]int id)
    {
        var result = await _parkingService.ExitAsync(id);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("active")]
    public async Task<IActionResult> GetActiveTicket()
    {
        var result = await _parkingService.GetAsync();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("ticket/{id}")]
    public async Task<IActionResult> GetTicketById([FromRoute]int id)
    {
        var result = await _parkingService.GetTicketByIdAsync(id);
        return Ok(result);
    }

}