using Domain.Abstractions;

namespace DataAccess;

public class Database : IDatabase
{
    private readonly FlightContext _context;

    public Database(FlightContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}