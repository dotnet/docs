using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Orleans.Runtime;
using Orleans.Storage;

namespace GrainStorage;

public static class FileSiloBuilderExtensions
{
    public static ISiloBuilder AddFileGrainStorage(
        this ISiloBuilder builder,
        string providerName,
        Action<FileGrainStorageOptions> options)
    {
        builder.Services.AddFileGrainStorage(providerName, options);
        return builder;
    }

    public static IServiceCollection AddFileGrainStorage(
        this IServiceCollection services,
        string providerName,
        Action<FileGrainStorageOptions> options)
    {
        services.AddOptions<FileGrainStorageOptions>(providerName)
            .Configure(options);

        services.AddTransient<
            IPostConfigureOptions<FileGrainStorageOptions>,
            DefaultStorageProviderSerializerOptionsConfigurator<FileGrainStorageOptions>>();

        // Use keyed services for Orleans 10.0+
        services.AddKeyedSingleton<IGrainStorage>(
            providerName,
            (sp, key) => FileGrainStorageFactory.Create(sp, key?.ToString() ?? providerName));

        services.AddKeyedSingleton<ILifecycleParticipant<ISiloLifecycle>>(
            providerName,
            (sp, key) => (ILifecycleParticipant<ISiloLifecycle>)sp.GetRequiredKeyedService<IGrainStorage>(key));

        return services;
    }
}
