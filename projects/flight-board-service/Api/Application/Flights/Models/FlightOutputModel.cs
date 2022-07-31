namespace Api.Application.Flights.Models;

public class FlightOutputModel
{
    public int FlightId { get; set; }
    public string FlightNumber { get; set; }
    public string AirlineName { get; set; } = null!;
    public string Destination { get; set; } = null!;
    public DateTime ScheduledDepartureTime { get; set; }
    public DateTime EstimatedDepartureTime { get; set; }
    public DateTime? ActualDepartureTime { get; set; }
    public FlightStatusModel Status { get; set; }
    public string DepartureGate { get; set; } = null!;
}