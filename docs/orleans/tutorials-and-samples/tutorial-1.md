---
title: Minimal Orleans app sample project
description: Explore the minimal Orleans app sample project.
ms.date: 02/04/2022
---

# Tutorial: Create a minimal Orleans application

This tutorial provides step-by-step instructions for creating a basic functioning Orleans application. It is designed to be self-contained and minimalistic, with the following traits:

- It relies only on NuGet packages
- It has been tested in Visual Studio 2017 using Orleans 2.2.0
- It has no reliance on external storage

Keep in mind that this is only a tutorial and lacks appropriate error handling and other goodies that would be useful for a production environment. However, it should help the readers get a real hands-on with regards to the structure of Orleans and allow them to focus their continued learning on the parts most relevant to them.

## Project setup

For this tutorial we're going to create 4 projects:

- a library to contain the grain interfaces
- a library to contain the grain classes
- a console application to host our Silo
- a console application to host our Client

### Create the structure in Visual Studio

> [!TIP]
> You can use the default project types in c# for each of these projects.

You will replace the default code with the code given for each project, below. You will also probably need to add `using` statements.

1. Start by creating a Console App (.NET Core) project in a new solution. Call the project part `Silo` and name the solution `OrleansHelloWorld`.
2. Add another Console App (.NET Core) project and name it `Client`.
3. Add a Class Library (.NET Standard) and name it `GrainInterfaces`.
4. Add another Class Library (.NET Standard) and name it `Grains`.

#### Delete default source files

1. Delete _Class1.cs_ from _Grains_
2. Delete _Class1.cs_ from _GrainInterfaces_

### Add references

1. `Grains` references `GrainInterfaces`.
2. `Silo` references `GrainInterfaces` and `Grains`.
3. `Client` references `GrainInterfaces`.

## Add Orleans NuGet Packages

| Project          | Nuget package                               |
|------------------|---------------------------------------------|
| Silo             | `Microsoft.Orleans.Server`                  |
| Silo             | `Microsoft.Extensions.Logging.Console`      |
| Client           | `Microsoft.Extensions.Logging.Console`      |
| Client           | `Microsoft.Orleans.Client`                  |
| Grain Interfaces | `Microsoft.Orleans.Core.Abstractions`       |
| Grain Interfaces | `Microsoft.Orleans.CodeGenerator.MSBuild`   |
| Grains           | `Microsoft.Orleans.CodeGenerator.MSBuild`   |
| Grains           | `Microsoft.Orleans.Core.Abstractions`       |
| Grains           | `Microsoft.Extensions.Logging.Abstractions` |

`Microsoft.Orleans.Server` and `Microsoft.Orleans.Client` are meta-packages that bring dependency that you will most likely need on the Silo and client-side.

`Microsoft.Orleans.Core.Abstractions` is needed everywhere. It is included in both `Microsoft.Orleans.Server` and `Microsoft.Orleans.Client`.

`Microsoft.Orleans.CodeGenerator.MSBuild` automatically generates code that is needed to make calls to grains across machine boundaries. So it is needed in both `GrainInterfaces` and `Grains` projects.

## Define a Grain Interface

In the GrainInterfaces project, add a `IHello.cs` code file and define the following IHello interface in it:

```csharp
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface IHello : Orleans.IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}
```

## Define a grain class

In the Grains project, add a `HelloGrain.cs` code file and define the following class in it:

```csharp
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger _logger;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }

        Task<string> IHello.SayHello(string greeting)
        {
            _logger.LogInformation("SayHello message received: greeting = '{Greeting}'", greeting);
            return Task.FromResult($"\n Client said: '{greeting}', so HelloGrain says: Hello!");
        }
    }
}
```

### Create the Silo

At this step, we add code to initialize a server that will host and run our grains&mdash;a silo. We will use the development clustering provider here, so that we can run everything locally, without a dependency on external storage systems. You can find more information about that in the [Local Development Configuration](../host/configuration-guide/local-development-configuration.md) page of the Orleans documentation. We will run a cluster with a single silo in it.

Add the following code to _Program.cs_ of the Silo project:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using OrleansBasics;

try
{
    var host = await StartSiloAsync();
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

static async Task<ISiloHost> StartSiloAsync()
{
    var builder = new SiloHostBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "OrleansBasics";
        })
        .ConfigureApplicationParts(
            parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
        .ConfigureLogging(logging => logging.AddConsole());

    var host = builder.Build();
    await host.StartAsync();

    return host;
}
```

### Create the client

Finally, we need to configure a client for communicating with our grains, connect it to the cluster (with a single silo in it), and invoke the grain. Note that the clustering configuration must match the one we used for the silo. There is more information about the client in the [Clusters and Clients](../host/client.md) section of the Orleans documentation.

```csharp
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using System;
using System.Threading.Tasks;
using OrleansBasics;

try
{
    using (var client = await ConnectClientAsync())
    {
        await DoClientWorkAsync(client);
        Console.ReadKey();
    }

    return 0;
}
catch (Exception e)
{
    Console.WriteLine($"\nException while trying to run client: {e.Message}");
    Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
    Console.WriteLine("\nPress any key to exit.");
    Console.ReadKey();
    return 1;
}

static async Task<IClusterClient> ConnectClientAsync()
{
    var client = new ClientBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "OrleansBasics";
        })
        .ConfigureLogging(logging => logging.AddConsole())
        .Build();

    await client.Connect();
    Console.WriteLine("Client successfully connected to silo host \n");

    return client;
}

static async Task DoClientWorkAsync(IClusterClient client)
{
    var friend = client.GetGrain<IHello>(0);
    var response = await friend.SayHello("Good morning, HelloGrain!");

    Console.WriteLine($"\n\n{response}\n\n");
}
```

## Run the application

Build the solution and run the Silo. After you get the confirmation message that the Silo is running ("Press enter to terminate..."), run the Client.

## See also

- [List of Orleans Packages](../resources/nuget-packages.md)
- [Orleans Configuration Guide](../host/configuration-guide/index.md)
- [Orleans Best Practices](https://www.microsoft.com/research/publication/orleans-best-practices)
