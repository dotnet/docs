using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyLibraryService(
          this IServiceCollection services,
          IConfiguration namedConfigurationSection)
        {
            namedConfigurationSection.Bind(new LibraryOptions
            {
                // Default library options are overridden
                // by bound configuration values.
            });

            // Register lib services here...
            // services.AddScoped<ILibraryService, DefaultLibraryService>();

            return services;
        }
    }
}
