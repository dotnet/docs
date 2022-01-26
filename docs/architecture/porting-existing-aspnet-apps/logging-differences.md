---
title: Logging differences between ASP.NET MVC and ASP.NET Core
description: How is logging different between ASP.NET MVC and Web API apps and ASP.NET Core apps?
author: ardalis
ms.date: 12/10/2021
---

# Logging differences between ASP.NET MVC and ASP.NET Core

Application logging provides important diagnostic information, especially for apps running in production. ASP.NET Core introduces a new system for adding standardized logging to any app. Existing ASP.NET MVC and Web API apps most likely use third-party logging solutions, which likely continue to be supported on ASP.NET Core.

## ASP.NET MVC logging

There's no built-in logging solution in ASP.NET MVC and Web API apps. Instead, most apps use third-party logging solutions like [log4net](https://www.nuget.org/packages/log4net/), [NLog](https://www.nuget.org/packages/NLog/), or [Serilog](https://www.nuget.org/packages/Serilog). Many teams also choose to roll their own logging solution. Logging frameworks typically support multiple "sinks" (or targets or appenders) for log output, such as text files, databases, or even emails. They use configuration to determine which levels of log messages from which parts of the system are routed to different sinks. When considering how to migrate an app's logging to .NET Core, review how logging is performed and [configured](configuration-differences.md) in the app.

## ASP.NET Core logging

In ASP.NET Core, [logging is a built-in feature](/aspnet/core/fundamentals/logging/) that can be configured and extended when the app starts up. Third-party loggers, including those mentioned above, can be integrated with ASP.NET Core to enhance its functionality.

ASP.NET Core logging uses categories and levels to control what is logged and how. Classes typically use instances of the `ILogger<T>` interface, with the class's type used as the generic `T` type. In this scenario, the class's fully qualified name is used as the category. Loggers can also be created with a custom category using an `ILoggerFactory`. Log levels range from the most detailed, `Trace`, to the most important, `Critical`. Using configuration, apps can specify what minimum level of logging should be included on a per-category (with wildcards) basis.

A typical logging configuration could log `Information` and above information by default, but only `Warning` or above from `Microsoft`-prefixed categories:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

Support for logging in ASP.NET Core is extensive and flexible. For more detailed information, [refer to the docs](/aspnet/core/fundamentals/logging/).

## Migrate logging

How you migrate your .NET Framework app's logging to .NET Core depends on how the app is logging now. If it's using a third-party NuGet package, refer to the upgrade documentation for that package. Most likely the upgrade path will be fairly straightforward. If you're using your own logging solution, take one of the following actions:

1. Migrate the logging solution yourself
1. Migrate to a third-party logging solution
1. Use the built-in logging support in ASP.NET Core

You can reference the `Microsoft.Extensions.Logging` package from .NET Framework apps as long as they're using NuGet 4.3 or later and are on .NET Framework 4.6.1 or later. Once your app has referenced this package, you can convert your logging statements to use the new extensions before migrating the app to .NET Core. This can provide a stepping stone toward full migration, since the app can continue running on .NET Framework while logging using the newer extensions package.

## References

- [Logging in .NET Core and ASP.NET Core](/aspnet/core/fundamentals/logging/)
- [Microsoft.Extensions.Logging NuGet Package](https://www.nuget.org/packages/microsoft.extensions.logging/)

>[!div class="step-by-step"]
>[Previous](routing-differences.md)
>[Next](comparing-razor-pages-aspnet-mvc.md)
