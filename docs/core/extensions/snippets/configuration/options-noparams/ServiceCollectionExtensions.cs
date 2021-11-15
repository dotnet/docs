using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyLibraryService(
        this IServiceCollection services)
    {
        services.AddOptions<LibraryOptions>()
            .Configure(options =>
            {
                    // Specify default option values
            });

        // Register lib services here...
        // services.AddScoped<ILibraryService, DefaultLibraryService>();

        return services;
    }
}
