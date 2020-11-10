---
title: Architectural differences between ASP.NET MVC and ASP.NET Core
description: Review the architectural differences between ASP.NET and ASP.NET Core.
author: ardalis
ms.date: 11/13/2020
---

# Architectural differences between ASP.NET MVC and ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

There are many architectural differences between ASP.NET MVC on .NET Framework and ASP.NET Core. It's important to have a broad understanding of these differences as teams evaluate the work involved in porting their ASP.NET MVC apps to ASP.NET Core. This chapter looks at each of the ways in which ASP.NET Core differs substantially from ASP.NET MVC.

## Breaking changes

Because .NET Core is a complete rewrite of .NET, designed from the ground up to be cross-platform, there are many [breaking changes between the two frameworks](https://docs.microsoft.com/dotnet/core/compatibility/fx-core). The following sections identify specific differences between how ASP.NET MVC and ASP.NET Core apps are designed and developed, but take care also to examine the documentation to determine which framework libraries you're using that may need to be changed. In many cases, a replacement NuGet package exists to fill in any gaps left between .NET and .NET Core. In rare cases, you may need to find a third party solution or implement new custom code to address incompatibilities.

>[!div class="step-by-step"]
>[Previous](additional-migration-resources.md)
>[Next](app-startup-differences.md)
