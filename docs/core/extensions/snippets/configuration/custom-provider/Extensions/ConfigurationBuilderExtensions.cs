using CustomProvider.Example.Providers;

namespace Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddEntityConfiguration(
        this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        var connectionString =
            tempConfig.GetConnectionString("WidgetConnectionString");

        return builder.Add(new EntityConfigurationSource(connectionString));
    }
}
