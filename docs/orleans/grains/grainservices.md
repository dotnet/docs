---
title: Create a GrainService
description: Learn how to create a GrainService in .NET Orleans.
ms.date: 01/31/2022
---

# Create a GrainService

A GrainService is a special grain; one that has no identity, and runs in every silo from startup to shutdown. There are several steps involved when implementing an `IGrainService` interface.

1. Create the interface. The interface of a `GrainService` is built using the same principles you would use for building the interface of any other grain.

    ```csharp
    public interface IDataService : IGrainService
    {
        Task MyMethod();
    }
    ```

1. Create the DataService grain itself. If possible, make the GrainService reentrant for better performance. It's good to know that you can also inject an `IGrainFactory` so you can make grain calls from your `GrainService`.

    > [!TIP]
    > A `GrainService` cannot write to Orleans streams because it doesn't work within a grain task scheduler. If you need the `GrainService` to write to streams for you, then you will have to send the object to another kind of grain for writing to the stream.

```csharp
[Reentrant]
public class DataService : GrainService, IDataService
{
    readonly IGrainFactory _grainFactory;

    public DataService(
        IServiceProvider services,
        IGrainIdentity id,
        Silo silo,
        ILoggerFactory loggerFactory,
        IGrainFactory grainFactory)
        : base(id, silo, loggerFactory)
    {
        _grainFactory = grainFactory;
    }

    public override Task Init(IServiceProvider serviceProvider) =>
        base.Init(serviceProvider);

    public override Task Start() => base.Start();

    public override Task Stop() => base.Stop();

    public Task MyMethod()
    {
        // TODO: custom logic here.
        return Task.CompletedTask;
    }
}
```

1. Create an interface for the `GrainServiceClient` to be used by other grains to connect to the `GrainService`.

    ```csharp
    public interface IDataServiceClient : IGrainServiceClient<IDataService>, IDataService
    {
    }
    ```

1. Create the actual grain service client. It pretty much just acts as a proxy for the data service. Unfortunately, you have to manually type in all the method mappings, which are just simple one-liners.

    ```csharp
    public class DataServiceClient : GrainServiceClient<IDataService>, IDataServiceClient
    {
        public DataServiceClient(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public Task MyMethod() => GrainService.MyMethod();
    }
    ```

1. Inject the grain service client into the other grains that need it. The `GrainServiceClient` does not guarantee accessing the `GrainService` on the local silo. Your command could potentially be sent to the `GrainService` on any silo in the cluster.

    ```csharp
    public class MyNormalGrain: Grain<NormalGrainState>, INormalGrain
    {
        readonly IDataServiceClient _dataServiceClient;
    
        public MyNormalGrain(
            IGrainActivationContext grainActivationContext,
            IDataServiceClient dataServiceClient) =>
                _dataServiceClient = dataServiceClient;
    }
    ```

1. Inject the grain service into the silo itself. You need to do this so that the silo will start the `GrainService`.

```csharp
(ISiloHostBuilder builder) =>
    builder.ConfigureServices(
        services => services.AddSingleton<IDataService, DataService>());
```

## Additional notes

<!-- markdownlint-disable-next-line proper-names -->
There's an extension method on `ISiloHostBuilder: AddGrainService<SomeGrainService>()`. Type constraint is: `where T : GrainService`. It ends up calling this bit: _orleans/src/Orleans.Runtime/Services/GrainServicesSiloBuilderExtensions.cs_

```csharp
services.AddSingleton<IGrainService>(
    serviceProvider => GrainServiceFactory(grainServiceType, serviceProvider));
```

<!-- markdownlint-disable-next-line proper-names -->
The silo fetches `IGrainService` types from the service provider when starting: _orleans/src/Orleans.Runtime/Silo/Silo.cs_
 `var grainServices = this.Services.GetServices<IGrainService>();`

The `Microsoft.Orleans.OrleansRuntime` NuGet package should be referenced by the `GrainService` project.

In order for this to work you have to register both the service and its client. The code looks something like this:

```csharp
var builder = new SiloHostBuilder()
    .AddGrainService<DataService>()  // Register GrainService
    .ConfigureServices(services =>
    {
        // Register Client of GrainService
        services.AddSingleton<IDataServiceClient, DataServiceClient>(); 
    })
 ```
