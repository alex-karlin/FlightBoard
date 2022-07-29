using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Actual",
                table: "DepartureSchedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Aircraft",
                columns: new[] { "AircraftId", "Capacity", "Manufacturer", "Model" },
                values: new object[,]
                {
                    { 1, 294, "Boeing", "787-9" },
                    { 2, 332, "Boeing", "777-300ER" },
                    { 3, 171, "Airbus", "A320" }
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "Name" },
                values: new object[] { 1, "Air New Zealand" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "30 Durey Road, Christchurch 8053", "Christchurch Airport" },
                    { 2, "Sir Henry Wigley Drive, Frankton, Queenstown 9300", "Queenstown Airport" },
                    { 3, "Ray Emery Drive, Māngere, Auckland 2022", "Auckland Airport" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AircraftId", "AirlineId", "DestinationId", "Number", "SourceId", "Status" },
                values: new object[,]
                {
                    { 1, 3, 1, 2, "NZ5659", 1, "OnTime" },
                    { 2, 3, 1, 2, "NZ5647", 1, "OnTime" },
                    { 3, 3, 1, 2, "NZ5653", 1, "OnTime" },
                    { 4, 3, 1, 2, "NZ643", 1, "OnTime" }
                });

            migrationBuilder.InsertData(
                table: "DepartureSchedules",
                columns: new[] { "DepartureScheduleId", "Actual", "Estimated", "FlightId", "Gate", "Scheduled" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 8, 3, 8, 40, 0, 0, DateTimeKind.Unspecified), 1, "30", new DateTime(2022, 8, 3, 8, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2022, 8, 3, 11, 5, 0, 0, DateTimeKind.Unspecified), 2, "28", new DateTime(2022, 8, 3, 11, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(2022, 8, 4, 11, 5, 0, 0, DateTimeKind.Unspecified), 2, "28", new DateTime(2022, 8, 4, 11, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(2022, 8, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), 3, "19", new DateTime(2022, 8, 3, 14, 40, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "AircraftId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "AircraftId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepartureSchedules",
                keyColumn: "DepartureScheduleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DepartureSchedules",
                keyColumn: "DepartureScheduleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepartureSchedules",
                keyColumn: "DepartureScheduleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepartureSchedules",
                keyColumn: "DepartureScheduleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "AircraftId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Actual",
                table: "DepartureSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
