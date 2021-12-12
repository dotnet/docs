---
title: App startup differences between ASP.NET MVC and ASP.NET Core
description: ASP.NET MVC and ASP.NET Core differ significantly in how the apps start up. Learn the important differences and how to migrate from ASP.NET MVC to ASP.NET Core.
author: ardalis
ms.date: 12/10/2021
---

# App startup differences between ASP.NET MVC and ASP.NET Core

ASP.NET MVC apps lived entirely within Internet Information Server (IIS), the primary web server available on Windows operating systems. Unlike ASP.NET MVC, ASP.NET Core apps are executable apps. You can run them from the command line, using `dotnet run`. They have an entry point method like all C# programs, typically `public static void Main()` or a similar variation (perhaps with arguments or `async` support). This is perhaps the biggest architectural difference between ASP.NET Core and ASP.NET MVC, and is one of several differences that allows ASP.NET Core to run on non-Windows systems.

## ASP.NET MVC Startup

Hosted within IIS, ASP.NET apps rely on IIS to instantiate certain objects and call certain methods when a request arrives. ASP.NET creates an instance of the *Global.asax* file's class, which derives from `HttpApplication`. When the first request is received, before handling the request itself, ASP.NET calls the `Application_Start` method in the *Global.asax* file's class. Any logic that needs to run when the ASP.NET MVC app begins can be added to this method.

Many NuGet packages for ASP.NET MVC and Web API use the [WebActivator](https://github.com/davidebbo/WebActivator) package to let them run some code during app startup. By convention, this code would typically be added to an *App_Start* folder and would be configured via attribute to run either immediately before or just after `Application_Start`.

It's also possible to use the [Open Web Interface for .NET (OWIN) and Project Katana with ASP.NET MVC](/aspnet/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana). When doing so, the app will include a *Startup.cs* file that is responsible for setting up request middleware in a way that's very similar to how ASP.NET Core behaves.

If you need to run code when your ASP.NET MVC app starts up, it will typically use one of these approaches.

## ASP.NET Core Startup

As noted previously, ASP.NET Core apps are standalone programs. As such, they typically include a *Program.cs* file containing the entry point for the app. A typical example of this file is shown in Figure 2-1. Notice that in .NET 6, this file is streamlined by the use of implicit using statements and top-level statements, eliminating the need for a lot of "boiler plate" code.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

```

**Figure 2-1**. A typical ASP.NET Core *Program.cs* file.

The code shown in Figure 2-1 uses a builder to configure the host and its services. Then, it creates the request pipeline for the app, which controls how every request to the app is handled.

Previous versions of .NET would use a separate *Startup.cs* file, referenced by *Program.cs*. This approach is still supported in .NET 6, but is no longer the default approach.

In addition to code related to configuring the app's services and request pipeline, apps may have other code that must run when the app begins. Such code is typically placed in *Program.cs* or registered as an `IHostedService`, which will be started by the [generic host](/aspnet/core/fundamentals/host/generic-host) when the app starts.

The `IHostedService` interface just exposes two methods, `StartAsync` and `StopAsync`. You register the interface when configuring the app's services and the host does the rest, calling the `StartAsync` method before the app starts up.

## Porting considerations

Teams looking to migrate their apps from ASP.NET MVC to ASP.NET Core need to identify what code is being run when their app starts up and determine the appropriate location for such code in their ASP.NET Core app. For custom code needed to run when the app starts up, especially async code, the recommended approach is typically to put such code into `IHostedService` implementations.

## References

- [ASP.NET Application Life Cycle Overview for IIS 7](/previous-versions/aspnet/bb470252(v=vs.100))
- [ASP.NET Application Life Cycle Overview for IIS 5 and 6](/previous-versions/aspnet/ms178473(v=vs.100))
- [Getting Started with OWIN and Katana](/aspnet/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana)
- [WebActivator](https://github.com/davidebbo/WebActivator)
- [App Startup in ASP.NET Core](/aspnet/core/fundamentals/startup)
- [.NET Generic Host in ASP.NET Core](/aspnet/core/fundamentals/host/generic-host)
- [IHostedService](../microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice.md)

>[!div class="step-by-step"]
>[Previous](architectural-differences.md)
>[Next](hosting-differences.md)
