---
title: Create a GrainService
description: Learn how to create a GrainService in .NET Orleans.
ms.date: 12/16/2022
zone_pivot_groups: orleans-version
---

# Grain Services

Grain Services are remotely accessible, partitioned services for supporting the functionality grains. Each instance of a grain service is responsible for some set of grains and those grains can get a reference to the grain service which is currently responsible for servicing them by using a `GrainServiceClient`.

Grain Services exist to support cases where responsibility for servicing grains should be distributed around the Orleans cluster. For example, Orleans Reminders are implemented using grain services: each silo is responsible for handling reminder operations for a subset of grains and notifying those grains when their reminders fire.

Grain Services are configured on silos and are initialized when the silo starts, before the silo completes initialization. They are not collected when idle and instead have lifetimes which extend for the lifetime of the silo itself.

## Create a GrainService

A <xref:Orleans.Runtime.GrainService> is a special grain; one that has no stable identity, and runs in every silo from startup to shutdown. There are several steps involved when implementing an <xref:Orleans.Services.IGrainService> interface.

1. Define the grain service communication interface. The interface of a `GrainService` is built using the same principles you would use for building the interface of a grain.

    ```csharp
    public interface IDataService : IGrainService
    {
        Task MyMethod();
    }
    ```

1. Create the `DataService` grain service. It's good to know that you can also inject an <xref:Orleans.IGrainFactory> so you can make grain calls from your `GrainService`.

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

1. Create an interface for the <xref:Orleans.Runtime.Services.GrainServiceClient%601>`GrainServiceClient` to be used by other grains to connect to the `GrainService`.

    ```csharp
    public interface IDataServiceClient : IGrainServiceClient<IDataService>, IDataService
    {
    }
    ```

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
1. Create the grain service client. Clients typically act as proxies for the grain services which they target, so you will usually add a method for each method on the target service. These methods will need to get a reference to the grain service which they target so that they can call into it. The `GrainServiceClient<T>` base class provides several overloads of the `GetGrainService` method which can return a grain reference corresponding to a `GrainId`, a numeric hash (`uint`), or a `SiloAddress`. The latter two overloads are for advanced cases where a developer wants to use a different mechanism to map responsibility to hosts or wants to address a host directly. In our sample code below, we define a property, `GrainService`, which returns the `IDataService` for the grain which is calling the `DataServiceClient`. To do that, we use the `GetGrainService(GrainId)` overload in conjunction with the `CurrentGrainReference` property.

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

:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

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

:::zone-end

1. Inject the grain service client into the other grains that need it. The `GrainServiceClient` is not guaranteed to access the `GrainService` on the local silo. Your command could potentially be sent to the `GrainService` on any silo in the cluster.

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

1. Configure the grain service and grain service client in the silo. You need to do this so that the silo will start the `GrainService`.

    ```csharp
    (ISiloHostBuilder builder) =>
        builder.ConfigureServices(
            services => services.AddGrainService<DataService>()
                                .AddSingleton<IDataServiceClient, DataServiceClient>());
    ```

## Additional notes

<!-- markdownlint-disable-next-line proper-names -->
There's an extension method on <xref:Orleans.Hosting.GrainServicesSiloBuilderExtensions.AddGrainService%2A?displayProperty=nameWithType> which is used to register grain services.

```csharp
services.AddSingleton<IGrainService>(
    serviceProvider => GrainServiceFactory(grainServiceType, serviceProvider));
```

<!-- markdownlint-disable-next-line proper-names -->
The silo fetches `IGrainService` types from the service provider when starting: _orleans/src/Orleans.Runtime/Silo/Silo.cs_

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

In order for this to work you have to register both the service and its client. The code looks something like this:

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
