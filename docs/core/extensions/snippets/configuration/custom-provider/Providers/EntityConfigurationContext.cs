using CustomProvider.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomProvider.Example.Providers;

public class EntityConfigurationContext(string? connectionString) : DbContext
{
    private readonly string _connectionString = connectionString ?? "";

    public DbSet<Settings> Settings => Set<Settings>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = _connectionString switch
        {
            { Length: > 0 } => optionsBuilder.UseSqlServer(_connectionString),
            _ => optionsBuilder.UseInMemoryDatabase("InMemoryDatabase")
        };
    }
}
