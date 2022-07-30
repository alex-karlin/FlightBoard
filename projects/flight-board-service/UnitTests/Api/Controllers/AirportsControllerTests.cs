using Api.Application.Airports.Models;
using Api.Controllers;
using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace UnitTests.Api.Controllers;

public class AirportsControllerTests
{
    public class Access
    {
        [Fact]
        public void Should_Not_Require_Authentication()
        {
            ControllerHelper.CheckMarkedWith<AirportsController, AllowAnonymousAttribute>()
                .Should().Be(true);
        }
    }

    public class GetAllMethod
    {
        private readonly AirportsControllerBuilder _builder;
        private readonly Fixture _fixture;

        public GetAllMethod()
        {
            _builder = new AirportsControllerBuilder();
            _fixture = new Fixture();
        }

        [Fact]
        public void Should_Register_Correct_Route()
        {
            ActionHelper.GetPath(() => _builder.Build().GetAll())
                .Should().Be("api/airports");
        }

        [Fact]
        public void Should_Register_Correct_Method()
        {
            ActionHelper.GetHttpMethod(() => _builder.Build().GetAll())
                .Should().BeOfType<HttpGetAttribute>();
        }

        [Fact]
        public void Given_Called_Then_Returns_Airports()
        {
            var entities = _fixture.Create<List<Airport>>().AsQueryable();
            _builder.AirportRepository.GetAll()
                .Returns(entities);
            var models = _fixture.Create<List<AirportOutputModel>>();
            _builder.Mapper.Map<IEnumerable<Airport>, IEnumerable<AirportOutputModel>>(entities)
                .Returns(models);

            _builder.Build().GetAll()
                .Should().BeEquivalentTo(models);
        }
    }
}