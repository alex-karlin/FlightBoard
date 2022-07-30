using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Aircraft
{
    public int AircraftId { get; set; }
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Capacity { get; set; }
}