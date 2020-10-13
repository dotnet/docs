---
title: Architectural differences between ASP.NET MVC and ASP.NET Core
description: Although at a high level ASP.NET MVC and ASP.NET Core share many concepts, there are many differences between them architecturally. Knowing these differences will help teams make informed decisions about how the will migrate their applications to .NET Core.
author: ardalis
ms.date: 11/13/2020
---

# Architectural differences between ASP.NET MVC and ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

*Notes*
This will be a high level comparison between the architectures of the two different types of apps which can link to existing documentation for more details (as opposed to Chapter 4, which is an example of applying the changes to eShop).

Topics:

- Startup
- Hosting
- Static files / wwwroot
- Dependency injection
- Middleware
- Configuration
- Routing
- Razor Pages
  - Compilation of Razor Pages
- Web API differences
  - HttpResponseMessage
  - Content negotiation
  - Model binding
- Auth
- Identity
- Controller base class differences
- SignalR
- Integration tests

## Breaking changes

Because .NET Core is a complete rewrite of .NET, designed from the ground up to be cross-platform, there are many [breaking changes between the two frameworks](https://docs.microsoft.com/dotnet/core/compatibility/fx-core). The following sections identify specific differences between how ASP.NET MVC and ASP.NET Core apps are designed and developed, but take care also to examine the documentation to determine which framework libraries you're using that may need to be changed. In many cases, a replacement NuGet package exists to fill in any gaps left between .NET and .NET Core. In rare cases, you may need to find a third party solution or implement new custom code to address incompatibilities.

>[!div class="step-by-step"]
>[Previous](additional-migration-resources.md)
>[Next](app-startup-differences.md)
