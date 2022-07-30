using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Airport
{
    public int AirportId { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
}