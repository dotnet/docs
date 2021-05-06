---
title: Strategies for migrating incrementally
description: What strategies can teams adopt that will allow them to migrate large apps from ASP.NET MVC to .NET Core in an incremental fashion?
author: ardalis
ms.date: 11/13/2020
---

# Strategies for migrating incrementally

The biggest challenge with migrating any large app is determining how to break the process into smaller tasks. There are several strategies that can be applied for this purpose, including breaking the app into horizontal layers such as UI, data access, business logic, or breaking up the app into separate, smaller apps. Another strategy is to upgrade some or all of the app to different framework versions on the way to a recent .NET Core release.

Consider the challenge of migrating a large ASP.NET 4.5 app. One approach is to migrate directly from .NET Framework 4.5 to .NET Core 3.1. However, this approach needs to account for every breaking change between the two frameworks and versions, which are substantial.

One recent addition to the .NET ecosystem that helps with interoperability between different .NET frameworks is [.NET Standard](https://dotnet.microsoft.com/platform/dotnet-standard). .NET Standard allows libraries to build against the agreed upon set of common APIs, ensuring they can be used in any .NET app. .NET Standard 2.0 is notable because it covers most base class library functionality used by most .NET Framework and .NET Core apps. Unfortunately, the earliest version of .NET with support for .NET Standard 2.0 is .NET Framework 4.6.1, and there are a number of updates in .NET Framework 4.8 that make it a compelling choice for initial upgrades.

One approach to incrementally upgrade a .NET Framework 4.5 system is to first update its class libraries to .NET Framework 4.8. Then, modify these libraries to be .NET Standard class libraries. Use multi-targeting and conditional compilation, if necessary. This step can be helpful in scenarios where app dependencies require .NET Framework and cannot easily be ported directly to use .NET Standard and .NET Core. Since .NET Framework libraries can be consumed by ASP.NET Core 2.1 apps, the next step is to migrate some or all of the web functionality of the app to ASP.NET Core 2.1 (as described in the [previous chapter](choose-net-core-version.md)).

Once the app is running on ASP.NET Core 2.1, migrating it to ASP.NET Core 3.1 in isolation is relatively straightforward. The most likely challenge during this step is updating incompatible dependencies to support .NET Core and possibly higher versions of .NET Standard. For apps that don't have problematic dependencies on .NET Framework-only libraries, there's little reason to upgrade to ASP.NET Core 2.1. Porting directly to ASP.NET Core 3.1 makes more sense and requires less effort.

By the time the app is running on .NET Core 3.1, migrating to the current .NET 5.0 release is relatively painless. The process primarily involves updating the target framework of your project files and their associated NuGet package dependencies. While there are several [breaking changes to consider](../../core/compatibility/5.0.md), most apps don't require significant modifications to move from .NET Core 3.1 to .NET 5.0. The primary deciding factor in [choosing between .NET Core 3.1 and .NET 5.0 is likely to be support](choose-net-core-version.md).

## References

- [What is .NET Standard?](https://dotnet.microsoft.com/platform/dotnet-standard)
- [Introducing .NET 5](https://devblogs.microsoft.com/dotnet/introducing-net-5/)
- [Migrate from ASP.NET Core 3.1 to 5.0](/aspnet/core/migration/31-to-50)

>[!div class="step-by-step"]
>[Previous](choose-net-core-version.md)
>[Next](migrate-web-forms.md)