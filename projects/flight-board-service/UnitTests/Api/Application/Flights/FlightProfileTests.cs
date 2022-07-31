using Api.Application.Flights;
using Api.Application.Flights.Models;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace UnitTests.Api.Application.Flights;

public class FlightProfileTests
{
    public class DepartureScheduleToFlightOutputModel
    {
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public DepartureScheduleToFlightOutputModel()
        {
            var config = new MapperConfiguration(c => c.AddProfile<FlightProfile>());
            _mapper = config.CreateMapper();
            _fixture = new Fixture();
        }

        [Fact]
        public void Given_Called_Then_Maps_Properties()
        {
            var source = _fixture.Create<DepartureSchedule>();
            var result = _mapper.Map<DepartureSchedule, FlightOutputModel>(source);

            result.FlightId.Should().Be(source.FlightId);
            result.FlightNumber.Should().Be(source.Flight.Number);
            result.AirlineName.Should().Be(source.Flight.Airline.Name);
            result.Destination.Should().Be(source.Flight.Destination.Name);
            result.ScheduledDepartureTime.Should().Be(source.Scheduled);
            result.EstimatedDepartureTime.Should().Be(source.Estimated);
            result.ActualDepartureTime.Should().Be(source.Actual);
            result.Status.Should().Be((FlightStatusModel)source.Flight.Status);
            result.DepartureGate.Should().Be(source.Gate);
        }
    }
}