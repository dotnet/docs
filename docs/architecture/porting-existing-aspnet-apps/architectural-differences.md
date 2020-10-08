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

>[!div class="step-by-step"]
>[Previous](additional-migration-resources.md)
>[Next](app-startup-differences.md)
