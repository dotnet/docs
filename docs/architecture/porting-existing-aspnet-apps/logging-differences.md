---
title: Logging differences between ASP.NET MVC and ASP.NET Core
description: How is logging different between ASP.NET MVC and Web API apps and ASP.NET Core apps?
author: ardalis
ms.date: 11/13/2020
---

# Logging differences between ASP.NET MVC and ASP.NET Core

Application logging provides important diagnostic information, especially for apps running in production. ASP.NET Core introduces a new system for adding standardized logging to any app. Existing ASP.NET MVC and Web API apps most likely will be using third-party logging solutions, which likely continue to be supported on ASP.NET Core.

## ASP.NET MVC logging

There is no built-in logging solution in ASP.NET MVC and Web API apps. Instead, most apps use third-party logging solutions like [log4net](https://www.nuget.org/packages/log4net/), [NLog](https://www.nuget.org/packages/NLog/), or [Serilog](https://www.nuget.org/packages/Serilog). Many teams also choose to roll their own logging solution. Logging frameworks typically support multiple "sinks" (or targets or appenders) for log output, such as text files, databases, or even emails. They use configuration to determine which levels of log messages from which parts of the system are routed to different sinks. Teams should review how logging is performed within the app as well as how logging is [configured](configuration-differences.md) when considering how to migrate their app's logging to .NET Core.

## ASP.NET Core logging

In ASP.NET Core, [logging is a built-in feature](https://docs.microsoft.com/aspnet/core/fundamentals/logging/) that can be configured and extended when the app starts up. Third-party loggers, including all of the ones mentioned above, can be hooked into ASP.NET Core to enhance its functionality.

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

Support for logging in ASP.NET Core is extensive and flexible. [Refer to the docs](https://docs.microsoft.com/aspnet/core/fundamentals/logging/) for more detailed information.

## Migrate logging

How you migrate your .NET Framework app's logging to .NET Core will largely depend on how the app is logging now. If it's using a third-party NuGet package, refer to the upgrade documentation for that package. Most likely the upgrade path will be fairly straightforward. If you're using your own logging solution, you'll need to migrate it yourself, or consider this an opportunity to migrate to a third-party solution or the built-in support in ASP.NET Core.

You can reference the `Microsoft.Extensions.Logging` package from .NET Framework apps as long as they are using NuGet 4.3 or later and are on .NET Framework 4.6.1 or later. Once your app has referenced this package, you can convert your logging statements to use the new extensions prior to migrating the app to .NET Core. This can provide a stepping stone toward full migration, since the app can continue running on .NET Framework while logging using the newer extensions package.

## References

- [Logging in .NET Core and ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/logging/)
- [Microsoft.Extensions.Logging NuGet Package](https://www.nuget.org/packages/microsoft.extensions.logging/)

>[!div class="step-by-step"]
>[Previous](middleware-modules-handlers.md)
>[Next](routing-differences.md)
