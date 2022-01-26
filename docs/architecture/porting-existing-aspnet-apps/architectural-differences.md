---
title: Architectural differences between ASP.NET MVC and ASP.NET Core
description: Review the architectural differences between ASP.NET and ASP.NET Core.
author: ardalis
ms.date: 12/10/2021
---

# Architectural differences between ASP.NET MVC and ASP.NET Core

There are many architectural differences between ASP.NET MVC on .NET Framework and ASP.NET Core. It's important to have a broad understanding of these differences as teams evaluate the work involved in porting their ASP.NET MVC apps to ASP.NET Core. This chapter looks at each of the ways in which ASP.NET Core differs substantially from ASP.NET MVC.

## Breaking changes

.NET Core is a cross-platform rewrite of .NET Framework. There are many [breaking changes between the two frameworks](../../core/compatibility/fx-core.md). The following sections identify specific differences between how ASP.NET MVC and ASP.NET Core apps are designed and developed. Take care to also examine the documentation to determine which framework libraries you're using that may need to change. In many cases, a replacement NuGet package exists to fill in any gaps left between .NET Framework and .NET Core. In rare cases, you may need to find a third-party solution or implement new custom code to address incompatibilities.

>[!div class="step-by-step"]
>[Previous](additional-migration-resources.md)
>[Next](app-startup-differences.md)
