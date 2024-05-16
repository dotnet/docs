using CustomProvider.Example.Providers;

namespace Microsoft.Extensions.Configuration;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddEntityConfiguration(
        this ConfigurationManager manager)
    {
        var connectionString = manager.GetConnectionString("WidgetConnectionString");

        IConfigurationBuilder configBuilder = manager;
        configBuilder.Add(new EntityConfigurationSource(connectionString));

        return manager;
    }
}
