using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example.Providers;

public class EntityConfigurationSource : IConfigurationSource
{
    private readonly string _connectionString;

    public EntityConfigurationSource(string connectionString) =>
        _connectionString = connectionString;

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EntityConfigurationProvider(_connectionString);
}
