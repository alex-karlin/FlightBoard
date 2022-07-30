namespace Api.Application.Airports.Models;

public class AirportOutputModel
{
    public int AirportId { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
}