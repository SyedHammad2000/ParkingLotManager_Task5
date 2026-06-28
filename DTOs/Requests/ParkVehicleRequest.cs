using System.ComponentModel.DataAnnotations;



public class ParkVehicleRequest
{
    [Required]
    public string PlateNumber { get; set; } = string.Empty;
    [Required]
    public string VehicleType { get; set; } = string.Empty;

    [Required]
    public string FeeType { get; set; } = string.Empty;
}