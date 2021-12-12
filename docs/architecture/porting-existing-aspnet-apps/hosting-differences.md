---
title: Hosting differences between ASP.NET MVC and ASP.NET Core
description: An overview of the differences between how ASP.NET MVC apps are hosted versus ASP.NET Core apps.
author: ardalis
ms.date: 12/10/2021
---

# Hosting differences between ASP.NET MVC and ASP.NET Core

ASP.NET MVC apps are hosted in IIS, and may rely on IIS configuration for their behavior. This often includes [IIS modules](/iis/get-started/introduction-to-iis/iis-modules-overview). As part of reviewing an app to prepare to port it from ASP.NET MVC to ASP.NET Core, teams should identify which modules, if any, they're using from the list of IIS Modules installed on their server.

[ASP.NET Core apps can run on a number of different servers](/aspnet/core/fundamentals/servers/). The default cross platform server, Kestrel, is a good default choice. Apps running in Kestrel can be hosted by IIS, running in a separate process. On Windows, apps can also run in process on IIS or using HTTP.sys. Kestrel is generally recommended for best performance. HTTP.sys can be used in scenarios where the app is exposed to the Internet and required capabilities are supported by HTTP.sys but not Kestrel.

Kestrel does not have an equivalent to IIS modules (though apps hosted in IIS can still take advantage of IIS modules). To achieve equivalent behavior, [middleware](/aspnet/core/fundamentals/middleware/) configured in the ASP.NET Core app itself is typically used.

## References

- [IIS Modules](/iis/get-started/introduction-to-iis/iis-modules-overview)
- [ASP.NET Core Middleware](/aspnet/core/fundamentals/middleware/)
- [ASP.NET Core Servers](/aspnet/core/fundamentals/servers/)

>[!div class="step-by-step"]
>[Previous](app-startup-differences.md)
>[Next](serving-static-files.md)
