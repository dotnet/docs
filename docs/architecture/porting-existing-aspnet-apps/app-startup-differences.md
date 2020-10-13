---
title: App startup differences between ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# App startup differences between ASP.NET MVC and ASP.NET Core

ASP.NET MVC applications lived entirely within Internet Information Server (IIS), the primary web server available on Windows operating systems. Unlike ASP.NET MVC, ASP.NET Core applications are executable applications. You can run them from the command line, using `dotnet run`. They have an entry point method like all C# programs, typically `public static void main()` or a similar variation (perhaps with arguments or async support). This is perhaps the biggest architectural difference between ASP.NET Core and ASP.NET MVC, and is one of several differences that allows ASP.NET Core to run on non-Windows systems.

## ASP.NET MVC Startup

Hosted within IIS, ASP.NET applications rely on IIS to instantiate certain objects and call certain methods when a request arrives. ASP.NET creates an instance of the `Global.asax` class, which derives from `HttpApplication`. When the first request is received, before handling the request itself, ASP.NET calls the `Application_Start` method on the `Global.asax` class. Any logic that needs to run when the ASP.NET MVC application begins can be added to this method.

Many NuGet packages for ASP.NET MVC and Web API use the [WebActivator](https://github.com/davidebbo/WebActivator) package to let them run some code during application startup. By convention, this code would typically be added to an `App_Start` folder and would be configured via attribute to run either immediately before or just after `Application_Start`.

It's also possible to use the [Open Web Interface for .NET (OWIN) and Project Katana with ASP.NET MVC](https://docs.microsoft.com/aspnet/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana). When doing so, the application will include a `Startup.cs` file that is responsible for setting up request middleware in a way that's very similar to how ASP.NET Core behaves.

If you need to run code when your ASP.NET MVC app starts up, it will typically use one of these approaches.

## ASP.NET Core Startup

As noted previously, ASP.NET Core applications are standalone programs. As such, they typically include a `Program.cs` file containing the entry point for the application. A typical such file is shown in Figure 2-1.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

**Figure 2-1. A typical ASP.NET Core Program.cs file.

The code shown in Figure 2-1 creates a *host* for the application, builds it, and runs it. The ASP.NET Core application runs within the host configured by the `IHostBuilder` shown. While it's possible to completely configure an ASP.NET Core app using the `IHostBuilder`, typically the bulk of this work is done in a `Startup` class.

The `Startup` class exposes two methods to the host, `ConfigureServices` and `Configure`. The `ConfigureServices` method is used to define the services the app will use and their respective lifetimes. The `Configure` method is used to define how each request to the app will be handled by setting up a request pipeline composed of middleware.

Code that isn't related to configuring the application's services or request pipeline, but which you need to run when the app begins, is typically placed in `Program.cs` or registered as an `IHostedService` which will be started by the [generic host](https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1) when the application starts.

The `IHostedService` interface just exposes two methods, `StartAsync` and `StopAsync`. You register the interface in `ConfigureServices` and the host does the rest, calling the `StartAsync` method before the app starts up.

## Porting considerations

Teams looking to migrate from apps from ASP.NET MVC to ASP.NET Core will need to identify what code is being run when their app starts up and determine the appropriate location for such code in their ASP.NET Core app. For custom code needed to run when the app starts up, especially async code, the recommended approach is typically to put such code into `IHostedService` implementations.

## References

- [ASP.NET Application Life Cycle Overview for IIS 7](https://docs.microsoft.com/previous-versions/aspnet/bb470252(v=vs.100))
- [ASP.NET Application Life Cycle Overview for IIS 5 and 6](https://docs.microsoft.com/en-us/previous-versions/aspnet/ms178473(v=vs.100))
- [Getting Started with OWIN and Katana](https://docs.microsoft.com/aspnet/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana)
- [WebActivator](https://github.com/davidebbo/WebActivator)
- [App Startup in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/startup?view=aspnetcore-3.1)
- [.NET Generic Host in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1)
- [IHostedService](https://docs.microsoft.com/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)

>[!div class="step-by-step"]
>[Previous](architectural-differences.md)
>[Next](hosting-differences.md)
