using GrainStorage;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering()
            .AddFileGrainStorage("File", options =>
            {
                options.RootDirectory = "C:/TestFiles";
            });
    })
    .Build();

host.Run();
