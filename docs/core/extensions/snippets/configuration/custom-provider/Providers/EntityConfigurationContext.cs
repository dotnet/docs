using CustomProvider.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomProvider.Example.Providers;

public class EntityConfigurationContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Settings>? Settings { get; set; }

    public EntityConfigurationContext(string connectionString) =>
        _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = _connectionString switch
        {
            { Length: > 0 } => optionsBuilder.UseSqlServer(_connectionString),
            _ => optionsBuilder.UseInMemoryDatabase("InMemoryDatabase")
        };
    }
}
