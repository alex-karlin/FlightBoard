namespace Domain.Entities;

public enum FlightStatus
{
    OnTime = 1,
    CheckIn,
    Boarding,
    Departed,
    Cancelled,
    Delayed
}