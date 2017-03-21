---
title: Target frameworks | Microsoft Docs
description: Explains the concepts of target frameworks when writing .NET code.
keywords: .NET, .NET Core, framework, TFM
author: richlander
ms.author: mairaw
ms.date: 03/20/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6ef56a2e-593d-497b-925a-1e25bb6df2e6
---

# Target frameworks

The .NET ecosystem has a concept of *target frameworks*. Frameworks define the API that you can use to target a particular platform. For example, the .NET Framework 4.6 is a platform that you can target. Visual Studio and other IDEs and editors use frameworks to provide you with the correct set of APIs. NuGet also uses them to ensure that you produce and consume appropriate NuGet packages and underlying assets for the framework you're targeting.

Reference | Name
--- | ---
Product | .NET Framework 4.6.2 or .NET 4.6.2
Framework | `.NETFramework,Version=4.6.2` or `net462`
Family | `.NETFramework` or `net`

## Latest framework versions

The following table defines the set of frameworks that you can use, how they're referenced, and which version of the [.NET Standard Library](library.md) they implement. These framework versions are the latest stable versions. Pre-release versions aren't shown.

Framework | Latest Version | Target Framework Moniker (TFM) | Compact Target Framework Moniker (TFM) | .NET Standard Version | Metapackage
:--------: | :--: | :--: | :--: | :--: | :--: | :--:
.NET Standard | 1.6.1 | .NETStandard,Version=1.6 | netstandard1.6 | N/A | [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library)
.NET Core Application | 1.1.1 | .NETCoreApp,Version=1.1 | netcoreapp1.1 | 1.6 | [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App)
.NET Framework | 4.6.2 | .NETFramework,Version=4.6.2 | net462 | 1.5 | N/A

## Supported frameworks

A framework is typically referenced by a short target framework moniker or *TFM*. In .NET Standard, this is also generalized to *TxM* to allow a single reference to multiple frameworks. The NuGet clients support the following frameworks. Equivalents are shown within brackets (`[]`).

| Name | Abbreviation | TFMs/TxMs |
| --- | --- | --- |
| .NET Standard | netstandard | netstandard1.0 |
| | | netstandard1.1 |
| | | netstandard1.2 |
| | | netstandard1.3 |
| | | netstandard1.4 |
| | | netstandard1.5 |
| | | netstandard1.6 |
| .NET Core App | netcoreapp | netcoreapp1.0 |
| | | netcoreapp1.1 |
| .NET Framework | net | net11 |
| | | net20 |
| | | net35 |
| | | net40 |
| | | net403 |
| | | net45 |
| | | net451 |
| | | net452 |
| | | net46 |
| | | net461 |
| | | net462 |
| .NET Core | netcore | netcore [netcore45] |
| | | netcore45 [win, win8] |
| | | netcore451 [win81] |
| | | netcore50 |
| .NET MicroFramework | netmf | netmf |
| Windows | win | win [win8, netcore45] |
| | | win8 [netcore45, win] |
| | | win81 [netcore451] |
| | | win10 (not supported by Windows 10 platform) |
| Silverlight | sl | sl4 |
| | | sl5 |
| Windows Phone | wp | wp [wp7] |
| | | wp7 |
| | | wp75 |
| | | wp8 |
| | | wp81 |
| | | wpa81 |
| Universal Windows Platform | uap | uap [uap10.0] |
| | | uap10.0 |

## Deprecated frameworks

The following frameworks are deprecated. Packages targeting these frameworks should migrate to the indicated replacements.

Deprecated framework | Replacement
--- | ---
aspnet50 | netcoreapp
aspnetcore50 | 
dnxcore50 | 
dnx | 
dnx45 | 
dnx451 | 
dnx452 | 
dotnet | netstandard
dotnet50 | 
dotnet51 | 
dotnet52 | 
dotnet53 | 
dotnet54 | 
dotnet55 | 
dotnet56 | 
winrt | win

## Precedence

A number of frameworks are related to and compatible with one another but not necessarily equivalent:

Framework | Can use
--- | ---
uap (Universal Windows Platform) | win81
| | wpa81
| | netcore50
win (Windows Store) | winrt
| | winrt45

## .NET Standard

The [.NET Standard](https://github.com/dotnet/standard) simplifies references between binary-compatible frameworks, allowing a single target framework to reference a combination of others. For background, see the [.NET Standard Library](library.md).

The [NuGet Tools Get Nearest Framework Tool](https://aka.ms/s2m3th) simulates the NuGet logic used for the selection of one framework from many available framework assets in a package based on the project's framework. To use the tool, enter one project framework and one or more package frameworks. Click the **Submit** button. The tool indicates if the package frameworks you list are compatible with the project framework you provide.

For NuGet 3.3 and earlier, use the `dotnet` series of monikers. For NuGet 3.4 and later, use the `netstandard` moniker syntax.

## Portable Class Libraries

For information on Portable Class Libraries, see the [Portable Class Libraries](https://docs.microsoft.com/nuget/schema/target-frameworks#portable-class-libraries) section of the *Target Framework* topic in the NuGet documentation.

 Name | Description | .NET Standard
 --- | --- | ---
 monoandroid | Mono Support for Android OS | netstandard1.4
 monotouch | Mono Support for iOS | netstandard1.4
 monomac | Mono Support for OSX | netstandard1.4
 xamarinios | Support for Xamarin for iOS | netstandard1.4
 xamarinmac | Supports for Xamarin for Mac | netstandard1.4
 xamarinpsthree | Support for Xamarin on Playstation 3 | netstandard1.4
 xamarinpsfour | Support for Xamarin on Playstation 4 | netstandard1.4
 xamarinpsvita | Support for Xamarin on PS Vita | netstandard1.4
 xamarinwatchos | Xamarin for Watch OS | netstandard1.4
 xamarintvos | Xamarin for TV OS | netstandard1.4
 xamarinxboxthreesixty | Xamarin for XBox 360 | netstandard1.4
 xamarinxboxone | Xamarin for XBox One | netstandard1.4

> [!Note]
> Stephen Cleary created a tool that lists the supported PCLs. For more information, see [Framework Profiles in .NET](http://blog.stephencleary.com/2012/05/framework-profiles-in-net.html).
