using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example.Providers;

public class EntityConfigurationSource(
    string? connectionString) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EntityConfigurationProvider(connectionString);
}
