---
title: Strategies for migrating incrementally
description: What strategies can teams adopt that will allow them to migrate large apps from ASP.NET MVC to .NET Core in an incremental fashion?
author: ardalis
ms.date: 12/10/2021
---

# Strategies for migrating incrementally

The biggest challenge with migrating any large app is determining how to break the process into smaller tasks. There are several strategies that can be applied for this purpose, including breaking the app into horizontal layers such as UI, data access, business logic, or breaking up the app into separate, smaller apps. Another strategy is to upgrade some or all of the app to different framework versions on the way to a recent .NET Core release. One approach you could use is to migrate [vertical slices](https://deviq.com/practices/vertical-slices) of the app, rather than attempting to migrate one horizontal layer at a time. Let's consider each of these different approaches.

## Migrating slice by slice

One successful approach to migrating is to identify vertical slices of functionality and migrate them to the target platform one by one. The first step is to create a new ASP.NET Core 3.1 or 6 app. Next, identify the individual page or API endpoint that will be migrated first. Build out just the necessary functionality to support this one route in the ASP.NET Core app. Then use HTTP rewriting and/or a reverse proxy to start sending requests for these pages or endpoints to the new app rather than the ASP.NET app. This approach is well-suited to API projects, but can also work for many MVC apps.

When migrating slice by slice, the entire stack of the individual API endpoint or requested route is recreated in the new project or solution. The very first such slice typically requires the most effort, since it will typically need several projects to be created and decisions to be made about data access and solution organization. Once the first slice's functionality mirrors the existing app's, it can be deployed and the existing app can redirect to it or simply be removed. This approach is then repeated until the entire app has been ported to the new structure.

Some specific guidance on how to follow this strategy using IIS is covered in [Chapter 5, Deployment Scenarios](deployment-scenarios.md).

## Migrating layer by layer

Consider the challenge of migrating a large ASP.NET 4.5 app. One approach is to migrate the entire app directly from .NET Framework 4.5 to .NET Core 3.1. However, this approach needs to account for every breaking change between the two frameworks and versions, which are substantial. Performing this work on one project at a time provides a set of stepping stones so that the entire solution doesn't need to be moved at once.

One recent addition to the .NET ecosystem that helps with interoperability between different .NET frameworks is [.NET Standard](https://dotnet.microsoft.com/platform/dotnet-standard). .NET Standard allows libraries to build against the agreed upon set of common APIs, ensuring they can be used in any .NET app. .NET Standard 2.0 is notable because it covers most base class library functionality used by most .NET Framework and .NET Core apps. Unfortunately, the earliest version of .NET with support for .NET Standard 2.0 is .NET Framework 4.6.1, and there are a number of updates in .NET Framework 4.8 that make it a compelling choice for initial upgrades.

One approach to incrementally upgrade a .NET Framework 4.5 system layer-by-layer is to first update its class library dependencies to .NET Framework 4.8. Then, modify these libraries to be .NET Standard class libraries. Use multi-targeting and conditional compilation, if necessary. This step can be helpful in scenarios where app dependencies require .NET Framework and cannot easily be ported directly to use .NET Standard and .NET Core. Since .NET Framework libraries can be consumed by ASP.NET Core 2.1 apps, the next step is to migrate some or all of the web functionality of the app to ASP.NET Core 2.1 (as described in the [previous chapter](choose-net-core-version.md)). This is a "bottom up" approach, starting with low level class library dependencies and working up to the web app entry point.

Once the app is running on ASP.NET Core 2.1, migrating it to ASP.NET Core 3.1 in isolation is relatively straightforward. The most likely challenge during this step is updating incompatible dependencies to support .NET Core and possibly higher versions of .NET Standard. For apps that don't have problematic dependencies on .NET Framework-only libraries, there's little reason to upgrade to ASP.NET Core 2.1. Porting directly to ASP.NET Core 3.1 makes more sense and requires less effort.

By the time the app is running on .NET Core 3.1, migrating to the latest .NET release is relatively painless. The process primarily involves updating the target framework of your project files and their associated NuGet package dependencies. While there are several [breaking changes to consider when moving to .NET 5](../../core/compatibility/5.0.md) and [.NET 6](../../core/compatibility/6.0.md), most apps don't require significant modifications to move from .NET Core 3.1 to .NET 5 or .NET 6. The primary deciding factor in [choosing between .NET Core 3.1 and .NET 5 is likely to be support](choose-net-core-version.md). Now that .NET 6 is available and will be supported through November 2024, many teams will choose to upgrade from .NET Core 3.1 to .NET 6 once the initial migration is complete.

Instead of a "bottom up" approach, another alternative is to start with the web app (or even the entire solution) and use an automated tool to assist with the upgrade. The [.NET Upgrade Assistant tool](https://aka.ms/dotnet-upgrade-assistant) can be used to help upgrade .NET Framework apps to .NET Core / .NET 6. It automates many of the common tasks related to upgrading apps, such as modifying project file format, setting appropriate target frameworks, updating NuGet dependencies, and more.

## References

- [What is .NET Standard?](https://dotnet.microsoft.com/platform/dotnet-standard)
- [Announcing .NET 6 - The Fastest .NET Yet](https://devblogs.microsoft.com/dotnet/announcing-net-6/)
- [Introducing .NET 5](https://devblogs.microsoft.com/dotnet/introducing-net-5/)
- [Migrate from ASP.NET Core 3.1 to 5.0](/aspnet/core/migration/31-to-50)
- [.NET Upgrade Assistant tool](https://aka.ms/dotnet-upgrade-assistant)

>[!div class="step-by-step"]
>[Previous](choose-net-core-version.md)
>[Next](migrate-web-forms.md)
