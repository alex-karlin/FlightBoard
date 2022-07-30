using Api.Application.Airports.Models;
using Api.Application.Flights.Models;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/airports")]
public class AirportsController
{
    private readonly ILogger<AirportsController> _logger;
    private readonly IRepository<Airport> _airportRepository;
    private readonly IRepository<DepartureSchedule> _departureScheduleRepository;
    private readonly IMapper _mapper;

    public AirportsController(
        ILogger<AirportsController> logger,
        IRepository<Airport> airportRepository,
        IRepository<DepartureSchedule> departureScheduleRepository,
        IMapper mapper)
    {
        _logger = logger;
        _airportRepository = airportRepository;
        _departureScheduleRepository = departureScheduleRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<AirportOutputModel> GetAll()
    {
        var airports = _airportRepository.GetAll();
        return _mapper.Map<IEnumerable<Airport>, IEnumerable<AirportOutputModel>>(airports);
    }

    [HttpGet]
    [Route("{airportId:int}/flights")]
    public IEnumerable<FlightOutputModel> GetFlights(int airportId)
    {
        var airports = _airportRepository.GetAll();
        var departures = _departureScheduleRepository.GetAll()
                .Where(departure => departure.Flight.SourceId == airportId)
                .Include(departure => departure.Flight)
                .Include(departure => departure.Flight.Airline)
                .Include(departure => departure.Flight.Destination);
        return _mapper.Map<IEnumerable<DepartureSchedule>, IEnumerable<FlightOutputModel>>(departures);
    }
}