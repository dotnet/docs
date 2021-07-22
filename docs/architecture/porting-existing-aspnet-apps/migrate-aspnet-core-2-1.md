---
title: Migrate to ASP.NET Core 2.1
description: As the last .NET Core version to support .NET Framework runtime targeting, does migrating to .NET Core 2.1 make sense as an intermediate step in some app migration plans?
author: ardalis
ms.date: 11/13/2020
---

# Migrate to ASP.NET Core 2.1

ASP.NET Core 2.1 is an interesting release because it's the only currently supported .NET Core release to support both .NET Core and .NET Framework runtimes. As such, it may offer an easier upgrade path for some apps when compared to upgrading all parts of the app to .NET Core at once. As an LTS release, support for .NET Core 2.1 will continue through August 2021. Support for ASP.NET Core 2.1 running on .NET Framework will continue for as long as its underlying .NET Framework is supported.

## Should apps run on .NET Framework with ASP.NET Core 2.1?

ASP.NET Core 2.2 and earlier supported both .NET Core and .NET Framework runtimes. Does it make sense to migrate some or all of an app to ASP.NET Core 2.1 as a stepping stone, before porting over completely to .NET Core? Apps, or subsets of apps, could see their front-end ASP.NET logic ported to use ASP.NET Core, while still consuming .NET Framework libraries for business logic and infrastructure consumption. This approach may make sense when there's a relatively thin UI layer without much business logic, and a much larger set of functionality in class libraries.

The main benefit of porting just the front-end web layer to ASP.NET Core 2.1 is that the existing .NET class libraries can remain as is during the initial migration. They may be in continued use by other .NET apps or simply don't need to be in scope for the first iteration of a planned full migration to .NET Core. Reducing the scope of the initial migration for large apps helps provide incremental goals that act as stepping stones toward the desired end state, which is often a complete port to .NET Core.

If you have an existing app that may use this strategy, some things you can do today to help prepare for the process are to move as much business logic, data access, and other non-UI logic out of the ASP.NET projects and into separate class libraries as possible. It will also help if you have automated test coverage of your system, so that you can verify behavior remains consistent before and after the migration.

If your app is so large that you can't migrate the entire web app at once, and you need to be able to deploy the new ASP.NET Core app side-by-side with the existing ASP.NET app, there are deployment strategies that can be used to achieve this. These are covered in [Chapter 5: Deployment Scenarios](deployment-scenarios.md).

Keep in mind that ASP.NET Core 2.1 is the last LTS release of .NET Core that supports running on .NET Framework and consuming .NET Framework libraries. This release will soon be unsupported, but ASP.NET Core 2.1 on .NET Framework will be supported as long as the .NET Framework (even after .NET Core 2.1 support ends). For more information, see [ASP.NET Core 2.1 on .NET Framework](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## References

[Migrating from ASP.NET to ASP.NET Core 2.1](/aspnet/core/migration/proper-to-2x/?preserve-view=true&view=aspnetcore-2.1)

>[!div class="step-by-step"]
>[Previous](migration-considerations.md)
>[Next](choose-net-core-version.md)