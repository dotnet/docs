---
title: Strategies for migrating incrementally
description: What strategies can teams adopt that will allow them to migrate large applications from ASP.NET MVC to .NET Core in an incremental fashion?
author: ardalis
ms.date: 11/13/2020
---

# Strategies for migrating incrementally

The biggest challenge with migrating any large application is figuring out how to break the very large process up into smaller pieces. There are several strategies that can be applied for this purpose, including breaking up the app into horizontal layers such as UI, data access, business logic, or breaking up the app into separate, smaller apps. Another strategy that can help in this regard is to upgrade some or all of the application to different framework versions on the way to a recent .NET Core release.

Consider the challenge of migrating a large ASP.NET 4.5 application. One approach would be to migrate directly from .NET 4.5 to .NET Core 3.1. However, this approach would need to account for every breaking change between these two frameworks and versions, which are substantial.

One recent addition to the .NET ecosystem that helps with interoperability between different .NET frameworks is [.NET Standard](https://dotnet.microsoft.com/platform/dotnet-standard). The 2.0 .NET Standard release is notable because covers the vast majority of base class library functionality used by most .NET and .NET Core applications. Unfortunately, the earliest version of .NET with support for .NET Standard 2.0 is .NET 4.6.1.

Thus, one approach to incrementally upgrade a .NET 4.5 system would be to first update its class libraries to .NET 4.6.1 and then to modify these libraries to be .NET Standard class libraries (using multi-targeting and conditional compilation, if required). Such libraries can be consumed by ASP.NET Core 2.1 apps, so the next step would be to migrate some or all of the web functionality of the app to ASP.NET Core 2.1 (as described in the [previous chapter](choose-net-core-version.md)).

Once the app is running on ASP.NET Core 2.1, migrating it to ASP.NET Core 3.1 in isolation is relatively straightforward. The most likely challenge that will occur during this step will be updating any incompatible dependencies to support .NET Core and possibly higher versions of .NET Standard.

By the time the application is running on .NET Core 3.1, migrating to the current .NET 5 release should be relatively painless. The process primarily involves updating the target framework of your project files and their associated NuGet package dependencies. While there are a number of [breaking changes to consider](https://docs.microsoft.com/dotnet/core/compatibility/3.1-5.0), most applications should not require substantial modification to move from .NET Core 3.1 to .NET 5.

## References

- [What is .NET Standard?](https://dotnet.microsoft.com/platform/dotnet-standard)
- [Introducing .NET 5](https://devblogs.microsoft.com/dotnet/introducing-net-5/)
- [Migrate from ASP.NET Core 3.1 to 5.0](https://docs.microsoft.com/aspnet/core/migration/31-to-50)

>[!div class="step-by-step"]
>[Previous](choose-net-core-version.md)
>[Next](migrating-web-forms.md)
