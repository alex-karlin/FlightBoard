namespace Api.Application.Flights.Models;

public enum FlightStatusModel
{
    OnTime = 1,
    CheckIn,
    Boarding,
    Departed,
    Cancelled,
    Delayed
}