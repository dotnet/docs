using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyLibraryService(
      this IServiceCollection services,
      string configurationSectionName)
    {
        services.AddOptions<LibraryOptions>()
            .BindConfiguration(configurationSectionName)
            .Configure(options =>
            {
                // Override values here if desired.
            })
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Register lib services here...
        // services.AddScoped<ILibraryService, DefaultLibraryService>();

        return services;
    }
}
