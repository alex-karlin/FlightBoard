using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DepartureSchedule {
    public int DepartureScheduleId { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; } = null!;
    public DateTime Scheduled { get; set; }
    public DateTime Estimated { get; set; }
    public DateTime Actual { get; set; }
    public string Gate { get; set; } = null!;
}