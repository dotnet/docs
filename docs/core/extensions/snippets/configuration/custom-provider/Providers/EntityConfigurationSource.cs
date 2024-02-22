using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example.Providers;

public sealed class EntityConfigurationSource(
    string? connectionString) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EntityConfigurationProvider(connectionString);
}
