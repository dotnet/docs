using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyLibraryService(
      this IServiceCollection services,
      LibraryOptions userOptions)
    {
        services.AddOptions<LibraryOptions>()
            .Configure(options =>
            {
                    // Overwrite default option values
                    // with the user provided options.
                    // options.SomeValue = userOptions.SomeValue;
            });

        // Register lib services here...
        // services.AddScoped<ILibraryService, DefaultLibraryService>();

        return services;
    }
}
