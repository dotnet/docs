---
title: Create a GrainService
description: Learn how to create a GrainService in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
zone_pivot_groups: orleans-version
---

# Grain services

Grain services are remotely accessible, partitioned services for supporting grain functionality. Each instance of a grain service is responsible for some set of grains. Those grains can get a reference to the grain service currently responsible for servicing them by using a `GrainServiceClient`.

Grain services exist to support cases where responsibility for servicing grains should be distributed around the Orleans cluster. For example, Orleans Reminders are implemented using grain services: each silo handles reminder operations for a subset of grains and notifies those grains when their reminders fire.

You configure grain services on silos. They initialize when the silo starts, before the silo completes initialization. They aren't collected when idle; instead, their lifetimes extend for the lifetime of the silo itself.

## Create a grain service

A <xref:Orleans.Runtime.GrainService> is a special grain: it has no stable identity and runs in every silo from startup to shutdown. Implementing an <xref:Orleans.Services.IGrainService> interface involves several steps.

1. Define the grain service communication interface. Build the interface of a `GrainService` using the same principles you use for building a grain interface.

    ```csharp
    public interface IDataService : IGrainService
    {
        Task MyMethod();
    }
    ```

1. Create the `DataService` grain service. It's helpful to know that you can also inject an <xref:Orleans.IGrainFactory> so you can make grain calls from your `GrainService`.

    <!-- markdownlint-disable MD044 -->
    :::zone target="docs" pivot="orleans-7-0"
    <!-- markdownlint-enable MD044 -->

    ```csharp
    [Reentrant]
    public class DataService : GrainService, IDataService
    {
        readonly IGrainFactory _grainFactory;

        public DataService(
            IServiceProvider services,
            GrainId id,
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

    :::zone-end

    <!-- markdownlint-disable MD044 -->
    :::zone target="docs" pivot="orleans-3-x"
    <!-- markdownlint-enable MD044 -->

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

    :::zone-end

1. Create an interface for the <xref:Orleans.Runtime.Services.GrainServiceClient%601>`GrainServiceClient` that other grains will use to connect to the `GrainService`.

    ```csharp
    public interface IDataServiceClient : IGrainServiceClient<IDataService>, IDataService
    {
    }
    ```

1. Create the grain service client. Clients typically act as proxies for the grain services they target, so you usually add a method for each method on the target service. These methods need to get a reference to the target grain service so they can call into it. The `GrainServiceClient<T>` base class provides several overloads of the `GetGrainService` method that can return a grain reference corresponding to a `GrainId`, a numeric hash (`uint`), or a `SiloAddress`. The latter two overloads are for advanced cases where you want to use a different mechanism to map responsibility to hosts or address a host directly. In the sample code below, we define a property, `GrainService`, which returns the `IDataService` for the grain calling the `DataServiceClient`. To do that, we use the `GetGrainService(GrainId)` overload in conjunction with the `CurrentGrainReference` property.

    ```csharp
    public class DataServiceClient : GrainServiceClient<IDataService>, IDataServiceClient
    {
        public DataServiceClient(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        // For convenience when implementing methods, you can define a property which gets the IDataService
        // corresponding to the grain which is calling the DataServiceClient.
        private IDataService GrainService => GetGrainService(CurrentGrainReference.GrainId);

        public Task MyMethod() => GrainService.MyMethod();
    }
    ```

1. Inject the grain service client into the other grains that need it. The `GrainServiceClient` isn't guaranteed to access the `GrainService` on the local silo. Your command could potentially be sent to the `GrainService` on any silo in the cluster.

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

1. Configure the grain service and grain service client in the silo. You need to do this so the silo starts the `GrainService`.

    ```csharp
    (ISiloHostBuilder builder) =>
        builder.ConfigureServices(
            services => services.AddGrainService<DataService>()
                                .AddSingleton<IDataServiceClient, DataServiceClient>());
    ```

## Additional notes

<!-- markdownlint-disable-next-line proper-names -->
There's an extension method, <xref:Orleans.Hosting.GrainServicesSiloBuilderExtensions.AddGrainService%2A?displayProperty=nameWithType>, used to register grain services.

```csharp
services.AddSingleton<IGrainService>(
    serviceProvider => GrainServiceFactory(grainServiceType, serviceProvider));
```

<!-- markdownlint-disable-next-line proper-names -->
The silo fetches `IGrainService` types from the service provider when starting (see _orleans/src/Orleans.Runtime/Silo/Silo.cs_):

```csharp
var grainServices = this.Services.GetServices<IGrainService>();
```

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
The [Microsoft.Orleans.Runtime](https://www.nuget.org/packages/Microsoft.Orleans.Runtime) NuGet package should be referenced by the `GrainService` project.
:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->
The [Microsoft.Orleans.OrleansRuntime](https://www.nuget.org/packages/Microsoft.Orleans.OrleansRuntime) NuGet package should be referenced by the `GrainService` project.
:::zone-end

For this to work, you must register both the service and its client. The code looks something like this:

```csharp
var builder = new HostBuilder()
    .UseOrleans(c =>
    {
        c.AddGrainService<DataService>()  // Register GrainService
        .ConfigureServices(services =>
        {
            // Register Client of GrainService
            services.AddSingleton<IDataServiceClient, DataServiceClient>();
        });
    })
 ```
