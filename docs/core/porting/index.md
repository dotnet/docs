---
title: Port from .NET Framework to .NET 6
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET 6.
author: adegeo
ms.date: 05/04/2021
no-loc: ["package.config", PackageReference]
---
# Overview of porting from .NET Framework to .NET

The announcement of .NET Core 1.0 signaled the biggest transformation of .NET since its inception. .NET (formerly named .NET Core), is open sourced and cross platform and is where all innovation and on-going feature work will be happening going forward. The last planned major release of .NET Framework is 4.8, support for the .NET Framework is based on the [Microsoft Lifecycle Policy](https://docs.microsoft.com/en-us/lifecycle/policies/fixed) of the underlying OS for each version which can be seen at [Microsoft .NET Framework - Microsoft Lifecycle | Microsoft Docs](https://docs.microsoft.com/en-us/lifecycle/products/microsoft-net-framework). Support is limited to critical security and reliability fixes which are evaluated on a case-by-case basis.

- To learn more about .NET in general start with [.NET | Free. Cross-platform. Open Source.](https://dotnet.microsoft.com/en-us/).
- To learn more about .NET specifics start with [.NET documentation | Microsoft Docs.](https://docs.microsoft.com/en-us/dotnet/?WT.mc_id=dotnet-35129-website).

This guide is focused on the process of porting an existing application or service built and running on the .NET Framework to .NET. While for some simpler projects where the app model is available in .NET (such as libraries, console apps, and desktop apps) migrating can be relatively straightforward. More complex projects that require a new app model, such as moving to ASP.NET Core from ASP.NET, or projects using Windows based technologies will find it more challenging.
The following four stages encapsulate the process we recommend you follow.

## Planning Stage

The planning stage has as its goal to evaluate your application’s portability to .NET by identifying the scope of the work and the challenges involved. Some of the areas to explore in this stage are.

- Build pipeline
- .NET Framework version
- Project format
- NuGet packages
- API portability
- Dependency portability
- Migration approach
- Create a plan

## Pre-Migration Stage

In this stage you will make necessary changes and updates identified in the previous stage before needing to target .NET and touch source code.

- Update tools such as VS and MSBuild to support building .NET
- Update .NET Framework version
- Update projects to the SDK style format
- Update projects to use PackageReference format
- Update package dependencies

## Migration Stage

Here you begin porting code based on the plan you created previously. It is recommended that you set up a test framework that supports .NET and port and run tests incrementally together with your product code.
Migration plans will necessarily be very different due to complexity, technologies used, dependencies and scale of any given application. In most cases the following guidance applies and should be considered.

- Test as you go
- Make simple changes first
- Rewrite code to replace unavailable technologies
- Migrate major features with programming model changes
- Producing well-formed NuGet packages

## Post-Migration Stage

Once you are code complete you will need to have a process and systems in place to keep your service or application up to date.

- Updating to latest releases
- Service deployment process for monthly updates
- Packaging strategies

## See also

- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [ASP.NET to ASP.NET Core migration](/aspnet/core/migration/proper-to-2x)
- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework?view=netdesktop-6.0&preserve-view=true)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/?view=netdesktop-6.0&preserve-view=true)
- [.NET 5 vs. .NET Framework for server apps](../../standard/choosing-core-framework-server.md)
