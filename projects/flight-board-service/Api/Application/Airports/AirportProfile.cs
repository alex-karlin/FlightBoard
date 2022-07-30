using Api.Application.Airports.Models;
using AutoMapper;
using Domain.Entities;

namespace Api.Application.Airports;

public class AirportProfile : Profile
{
    public AirportProfile()
    {
        CreateMap<Airport, AirportOutputModel>();
    }
}