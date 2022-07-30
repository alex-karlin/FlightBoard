using Api.Controllers;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace UnitTests.Api.Controllers;

public class AirportsControllerBuilder
{
    public AirportsControllerBuilder()
    {
        Logger = Substitute.For<ILogger<AirportsController>>();
        AirportRepository = Substitute.For<IRepository<Airport>>();
        DepartureScheduleRepository = Substitute.For<IRepository<DepartureSchedule>>();
        Mapper = Substitute.For<IMapper>();
    }

    public ILogger<AirportsController> Logger { get; set; }
    public IRepository<Airport> AirportRepository { get; set; }
    public IRepository<DepartureSchedule> DepartureScheduleRepository { get; set; }
    public IMapper Mapper { get; set; }

    public AirportsController Build()
    {
        return new AirportsController(Logger, AirportRepository, DepartureScheduleRepository, Mapper);
    }
}