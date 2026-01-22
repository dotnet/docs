using Microsoft.Extensions.Options;
using Orleans.Configuration;
using Orleans.Storage;

namespace Orleans.Docs.Snippets.Serialization;

// Define a placeholder interface for the custom serializer example
public interface IMySerializer : IGrainStorageSerializer { }

public static class GrainStorageConfiguration
{
    // <grain_storage_serializer_config>
    public static void ConfigureGrainStorageSerializer(ISiloBuilder siloBuilder)
    {
        siloBuilder.AddAzureBlobGrainStorage(
            "MyGrainStorage",
            (OptionsBuilder<AzureBlobStorageOptions> optionsBuilder) =>
            {
                optionsBuilder.Configure<IMySerializer>(
                    (options, serializer) => options.GrainStorageSerializer = serializer);
            });
    }
    // </grain_storage_serializer_config>
}
