---
title: Comparing ASP.NET Web API 2 and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Comparing ASP.NET Web API 2 and ASP.NET Core

ASP.NET Core offers iterative improvements to ASP.NET Web API 2, but should feel very familiar to developers who have used Web API 2. ASP.NET Web API 2 was developed and shipped side by side with ASP.NET MVC, which meant that the two approaches had similar-but-different approaches to things like attribute routing and dependency injection. In ASP.NET Core, there is no longer any distinction between MVC and Web APIs. There is only ASP.NET MVC, which includes support for view-based scenarios, API endpoints, and Razor Pages (as well as other variations like health checks and SignalR).

In addition to being consistent and unified within ASP.NET Core, APIs built in .NET Core are much easier to test than those built on ASP.NET Web API 2. We'll cover [testing differences](testing-differences.md) in more detail in a moment, but the built-in support for hosting ASP.NET Core apps in a test host which can create an `HttpClient` that makes in-memory requests to the app is a huge benefit when it comes to automated testing.

When migrating from ASP.NET Web API 2 to ASP.NET Core, the transition should be pretty straightforward. If you have controllers that are bloated and larger then you'd like, one approach you may consider to break them up is the use of the [Ardalis.ApiEndpoints](https://www.nuget.org/packages/Ardalis.ApiEndpoints/) NuGet packages. This package breaks up each endpoint into its own specific class, with associated request and response types as appropriate. This approach yields many of [the same benefits as Razor Pages offer over view-based code organization](comparing-razor-pages-aspnet-mvc.md).

## References

- [Migrate from ASP.NET Web API to ASP.NET Core](https://docs.microsoft.com/aspnet/core/migration/webapi)
- [ApiEndpoints NuGet Package](https://www.nuget.org/packages/Ardalis.ApiEndpoints/)

>[!div class="step-by-step"]
>[Previous](comparing-razor-pages-aspnet-mvc.md)
>[Next](authentication-differences.md)
