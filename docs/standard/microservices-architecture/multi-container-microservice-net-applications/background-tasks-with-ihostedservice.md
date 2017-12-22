---
title: Implement background tasks in microservices with IHostedService and the BackgroundService class
description: .NET Microservices Architecture for Containerized .NET Applications | Implement background tasks in microservices with IHostedService and the BackgroundService class
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 12/11/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Implement background tasks in microservices with IHostedService and the BackgroundService class

Background tasks and scheduled jobs are something you might need to implement, eventually, in a microservice based application or in any kind of application. The difference when using a microservices architecture is that you can implement a single microservice process/container for hosting these background tasks so you can scale it down/up as you need or you can even make sure that it runs a single instance of that microservice process/container.

From a generic point of view, in .NET Core we called these type of tasks Hosted Services, because they are services/logic that you host within your host/application/microservice. Note that in this case, the hosted service simply means a class with the background task logic.

Since .NET Core 2.0, the framework provides a new interface named <xref:Microsoft.Extensions.Hosting.IHostedService> helping you to easily implement hosted services. The basic idea is that you can register multiple background tasks (hosted services), that run in the background while your web host or host is running, as shown in the image below.

![](./media/image26.png)

**Figure 8-25.** Using IHostedService in a WebHost vs. a Host

Note the difference made between `WebHost` and `Host`. 
A `WebHost` (base class implementing `IWebHost`) in ASP.NET Core 2.0 is the infrastructure artifact you use to provide HTTP server features to your process, such as if you are implementing an MVC web app or Web API service. It provides all the new infrastructure goodness in ASP.NET Core, enabling you to use dependency injection, insert middlewares in the HTTP pipeline, etc. and precisely use these `IHostedServices` for background tasks.

A `Host` (base class implementing `IHost`), however, is something new in .NET Core 2.1. Basically, a `Host` allows you to have a similar infrastructure than what you have with `WebHost` (dependency injection, hosted services, etc.), but in this case, you just want to have a simple and lighter process as the host, with nothing related to MVC, Web API or HTTP server features.

Therefore, you can choose and either create a specialized host-process with IHost to handle the hosted services and nothing else, such a microservice made just for hosting the `IHostedServices`, or you can alternatevely extend an existing ASP.NET Core `WebHost`, such as an existing ASP.NET Core Web API or MVC app. 

Each approach has pros and cons depending on your business and scalability needs. The bottom line is basically that if your background tasks have nothing to do with HTTP (IWebHost) you should use and IHost, when available in .NET Core 2.1.

## Registering hosted services in your WebHost or Host

Let’s drill down further on the `IHostedService` interface since its usage is pretty similar in a `WebHost` or in a `Host`. 

SignalR is one example of an artifact using hosted services, but you can also use it for much simpler things like:

-   A background task polling a database looking for changes.
-   A scheduled task updating some cache periodically.
-   An implementation of QueueBackgroundWorkItem that allows a task to be executed on a background thread.
-   Processing messages from a message queue in the background of a web app while sharing common services such as `ILogger`.
-   A background task started with `Task.Run()`.

You can basically offload any of those actions to a background task based on IHostedService.

The way you add one or multiple `IHostedServices` into your `WebHost` or `Host` is by registering them up through the standard DI (dependency injection) in an ASP.NET Core `WebHost` (or in a `Host` in .NET Core 2.1). Basically, you have to register the hosted services within the familiar `ConfigureServices()` method of the `Startup` class, as in the following code from a typical ASP.NET WebHost. 

```csharp
public IServiceProvider ConfigureServices(IServiceCollection services)
{            
    //Other DI registrations;

    // Register Hosted Services
    services.AddSingleton<IHostedService, GracePeriodManagerService>();
    services.AddSingleton<IHostedService, MyHostedServiceB>();
    services.AddSingleton<IHostedService, MyHostedServiceC>();
    //...
}
```

In that code, the `GracePeriodManagerService` hosted service is real code from the Ordering business microservice in eShopOnContainers, while the other two are just two additional samples.

The `IHostedService` background task execution is coordinated with the lifetime of the application (host or microservice, for that matter). You register tasks when the application starts and you have the opportunity to do some graceful action or clean-up when the application is shutting down.

Without using `IHostedService`, you could always start a background thread to run any task. The difference is precisely at the app’s shutdown time when that thread would simply be killed without having the opportunity to run graceful clean-up actions.


## The IHostedService interface

When you register an `IHostedService`, .NET Core will call the `StartAsync()` and `StopAsync()` methods of your `IHostedService` type during application start and stop respectively. Specifically, start is called after the server has started and `IApplicationLifetime.ApplicationStarted` is triggered.

The `IHostedService` as defined in .NET Core, looks like the following.

```csharp
namespace Microsoft.Extensions.Hosting
{
    //
    // Summary:
    //     Defines methods for objects that are managed by the host.
    public interface IHostedService
    {
        //
        // Summary:
        // Triggered when the application host is ready to start the service.
        Task StartAsync(CancellationToken cancellationToken);
        //
        // Summary:
        // Triggered when the application host is performing a graceful shutdown.
        Task StopAsync(CancellationToken cancellationToken);
    }
}
```
As you can imagine, you can create multiple implementations of IHostedService and register them at the `ConfigureService()` method into the DI container, as shown previously. All those hosted services will be started and stopped along with the application/microservice.

As a developer, you are responsible for handling the stopping action or your services when `StopAsync()` method is triggered by the host.

## Implementing IHostedService with a custom hosted service class deriving from the BackgroundService base class

You could go ahead and create you custom hosted service class from scratch and implement the `IHostedService`, as you need to do when using .NET Core 2.0. 

However, since most background tasks will have similar needs in regard to the cancellation tokens management and other tipical operations, .NET Core 2.1 will be providing a very convenient abstract base class you can derive from, named BackgroundService.

That class provides the main work needed to set up the background task. Note that this class will come in the .NET Core 2.1 library so you don’t need to write it.

However, as of the time of this writing, .NET Core 2.1 has not been released. Therefore, in eShopOnContainers which is currently using .NET Core 2.0, we are just temporally incorporating that class from the .NET Core 2.1 open-source repo (no need of any proprietary license other than the open-source license) because it is compatible with the current IHostedService interface in .NET Core 2.0. When .NET Core 2.1 is released, you’ll just need to point to the right NuGet package.

The next code is the abstract BackgroundService base class as implemented in .NET Core 2.1.

```csharp
// Copyright (c) .NET Foundation. Licensed under the Apache License, Version 2.0. 
/// <summary>
/// Base class for implementing a long running <see cref="IHostedService"/>.
/// </summary>
public abstract class BackgroundService : IHostedService, IDisposable
{
    private Task _executingTask;
    private readonly CancellationTokenSource _stoppingCts = 
                                                   new CancellationTokenSource();

    protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        // Store the task we're executing
        _executingTask = ExecuteAsync(_stoppingCts.Token);

        // If the task is completed then return it, 
        // this will bubble cancellation and failure to the caller
        if (_executingTask.IsCompleted)
        {
            return _executingTask;
        }

        // Otherwise it's running
        return Task.CompletedTask;
    }
    
    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        // Stop called without start
        if (_executingTask == null)
        {
            return;
        }

        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite,
                                                          cancellationToken));
        }

    }

    public virtual void Dispose()
    {
        _stoppingCts.Cancel();
    }
}
```

When deriving from the previous abstract base class, thanks to that inherited implementation, you just need to implement the `ExecuteAsync()` method in your own custom hosted service class, as in the following simplified code from eShopOnContainers which is polling a database and publishing integration events into the Event Bus when needed.

```csharp
public class GracePeriodManagerService : BackgroundService
{        
    private readonly ILogger<GracePeriodManagerService> _logger;
    private readonly OrderingBackgroundSettings _settings;

    private readonly IEventBus _eventBus;

    public GracePeriodManagerService(IOptions<OrderingBackgroundSettings> settings,
                                     IEventBus eventBus,
                                     ILogger<GracePeriodManagerService> logger)
        {
            //Constructor’s parameters validations...       
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            stoppingToken.Register(() => 
                    _logger.LogDebug($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"GracePeriod task doing background work.");

                // This eShopOnContainers method is quering a database table 
                // and publishing events into the Event Bus (RabbitMS / ServiceBus)
                CheckConfirmedGracePeriodOrders();

                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }
            
            _logger.LogDebug($"GracePeriod background task is stopping.");

        }

        protected override async Task StopAsync (CancellationToken stoppingToken)
        {
               // Run your graceful clean-up actions
        }
}
```

In this specific case for eShopOnContainers, it is executing an application method which is quering a database table looking for orders with a specific state and when applying changes, it is publishing integration events through the event bus (underneath it can be using RabbitMQ or Azure Service Bus). 

Of course, you could run any other business background task, instead.

By default, the cancellation token is set with a 5 second timeout, although you can change that value when building your `WebHost` using the `UseShutdownTimeout` extension of the `IWebHostBuilder`. This means that our service is expected to cancel within 5 seconds otherwise it will be more abruptly killed.

The following code would be changing that time to 10 seconds.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseShutdownTimeout(TimeSpan.FromSeconds(10))
    ...
```

### Summary class diagram

The following image 8-26 shows a visual summary of the classes and interfaced involved when implementing IHostedServices.
 
![](./media/image27.png)

**Figure 8-26.** Class diagram showing the multiple classes and interfaces related to IHostedService

### Deployment considerations and takeaways

It is important to note that the way you deploy your ASP.NET Core `WebHost` or .NET Core `Host` might impact the final solution. For instance, if you deploy your `WebHost` on IIS or a regular Azure App Service, your host can be shut down because of app pool recycles. But if you are deploying your host as a container into an orchestrator like Kubernetes or Service Fabric, you can control the assured number of live instances of your host. In addition, you could consider other approaches in the cloud especially made for these scenarios, like Azure Functions. 

But even for a `WebHost` deployed into an app pool, there are scenarios like repopulating or flushing application’s in-memory cache, that would be still applicable.

The `IHostedService` interface provides a convenient way to start background tasks in an ASP.NET Core web application (in .NET Core 2.0) or in any process/host (starting in .NET Core 2.1 with `IHost`). Its main benefit is the opportunity you get with the graceful cancellation to clean-up code of your background tasks when the host itself is shutting down.


#### Additional resources

-   **Building a scheduled task in ASP.NET Core/Standard 2.0** 

    [*https://blog.maartenballiauw.be/post/2017/08/01/building-a-scheduled-cache-updater-in-aspnet-core-2.html*](https://blog.maartenballiauw.be/post/2017/08/01/building-a-scheduled-cache-updater-in-aspnet-core-2.html)

-   **Implementing IHostedService in ASP.NET Core 2.0** 

    [*https://www.stevejgordon.co.uk/asp-net-core-2-ihostedservice*](https://www.stevejgordon.co.uk/asp-net-core-2-ihostedservice)

-   **ASP.NET Core 2.1 Hosting samples** 

    [*https://github.com/aspnet/Hosting/tree/dev/samples/GenericHostSample*](https://github.com/aspnet/Hosting/tree/dev/samples/GenericHostSample)



>[!div class="step-by-step"]
[Previous] (test-aspnet-core-services-web-apps.md)
[Next] (../microservice-ddd-cqrs-patterns/index.md)
