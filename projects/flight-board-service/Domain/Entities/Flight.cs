namespace Domain.Entities;

public class Flight
{
    public int FlightId { get; set; }
    public int AirlineId { get; set; }
    public Airline Airline { get; set; } = null!;
    public int AircraftId { get; set; }
    public Aircraft Aircraft { get; set; } = null!;
    public string Number { get; set; } = null!;
    public int SourceId { get; set; }
    public Airport Source { get; set; } = null!;
    public int DestinationId { get; set; }
    public Airport Destination { get; set; } = null!;
    public FlightStatus Status { get; set; }
}