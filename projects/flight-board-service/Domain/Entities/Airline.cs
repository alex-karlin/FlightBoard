using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Airline
{
    public int AirlineId { get; set; }
    public string Name { get; set; } = null!;
}