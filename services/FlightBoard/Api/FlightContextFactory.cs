using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api;

// Adding AddDbContext method in Program.cs was causing migration errors (see below)
//  but falling back to the context factory solved the problem
// Error: No DbContext was found in assembly 'Api'. Ensure that you're using the correct assembly and that the type is neither abstract nor generic.
public class FlightContextFactory : IDesignTimeDbContextFactory<FlightContext>
{
    public FlightContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<FlightContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("FlightsDb"), b => b.MigrationsAssembly("Api"));

        return new FlightContext(optionsBuilder.Options);
    }
}