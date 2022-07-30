using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api;

// Adding AddDbContext method in Program.cs was causing the following migration error:
//  Error: No DbContext was found in assembly 'Api'. Ensure that you're using the correct assembly and that the type is neither abstract nor generic.
//  but a design time factory solved the problem
public class FlightContextDesignTimeFactory : IDesignTimeDbContextFactory<FlightContext>
{
    public FlightContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<FlightContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("FlightsDb"), b =>
            b.MigrationsAssembly(GetType().Assembly.FullName));

        return new FlightContext(optionsBuilder.Options);
    }
}