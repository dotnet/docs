using GrainStorage;
using Microsoft.Extensions.Hosting;

using IHost host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering()
            .AddFileGrainStorage("File", options =>
            {
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData);

                options.RootDirectory = Path.Combine(path, "Orleans/GrainState/v1");
            });
    })
    .Build();

await host.RunAsync();
