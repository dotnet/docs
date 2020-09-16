using CustomProvider.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomProvider.Example.Providers
{
    public class EntityConfigurationContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }

        public EntityConfigurationContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
