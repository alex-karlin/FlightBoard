using Api.Application.Flights.Models;
using AutoMapper;
using Domain.Entities;

namespace Api.Application.Flights;

public class FlightProfile : Profile    
{
    public FlightProfile()
    {
        CreateMap<DepartureSchedule, FlightOutputModel>()
            .ForMember(d => d.AirlineName, o => o.MapFrom(s => s.Flight.Airline.Name))
            .ForMember(d => d.Destination, o => o.MapFrom(s => s.Flight.Destination.Name))
            .ForMember(d => d.ScheduledDepartureTime, o => o.MapFrom(s => s.Scheduled))
            .ForMember(d => d.EstimatedDepartureTime, o => o.MapFrom(s => s.Estimated))
            .ForMember(d => d.ActualDepartureTime, o => o.MapFrom(s => s.Actual))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Flight.Status))
            .ForMember(d => d.DepartureGate, o => o.MapFrom(s => s.Gate));
    }
}