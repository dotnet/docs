---
title: Target frameworks
description: Explains the concepts of target frameworks when writing .NET code.
keywords: .NET, .NET Core, framework, tfm
author: guardrex
ms.author: mairaw
ms.date: 03/10/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6ef56a2e-593d-497b-925a-1e25bb6df2e6
---

# Target frameworks

*Frameworks* define the objects, methods, protocols, and tools that you use to build and run applications, services, and libraries for *platforms*, such as Windows, Mac OS, and Linux. For example, the .NET Framework is used to create applications primarily for Windows platforms. .NET Core is a framework that allows you to build cross-platform applications that can run on a variety of platforms.

Taken together, the objects, methods, protocols, and tools are called Application Programming Interfaces (APIs). Framework APIs are used in [Visual Studio](https://www.visualstudio.com/), [Visual Studio Code](https://code.visualstudio.com/), and other Integrated Development Environments (IDEs) and editors to provide you with the correct set of objects, methods, protocols, and tools for development. Frameworks are also used by [NuGet](https://www.nuget.org/) for the production and consumption of NuGet packages to ensure that you produce and use appropriate packages for the frameworks that you target in your app, service, or library.

When you *target a framework*, you've decided which set of APIs and which versions of those APIs you would like to use. Frameworks are referenced in several ways: by product name, by long- or short-form framework names, and by family.

Refernece | Name
--- | ---
Product | .NET Framework 4.6.2 or .NET 4.6.2
Framework | `.NETFramework,Version=4.6.2` or `net462`
Family | `.NETFramework` or `net`

## Lastest framework versions

The table below defines the set of frameworks that you can use, how they're referenced, and which version of the [.NET Standard Library](library.md) they implement. These framework versions are the latest stable versions. Pre-release versions aren't described by this table.

| Framework | Latest Version | Target Framework Moniker (TFM) | Compact Target Framework Moniker (TFM) | .NET Standard Version | Metapackage |
| :--------: | :--: | :--: | :--: | :--: | :--: | :--: |
| .NET Standard | 1.6 | .NETStandard,Version=1.6 | netstandard1.6 | N/A | [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library)|
| .NET Core Application | 1.1.1 | .NETCoreApp,Version=1.1 | netcoreapp1.1 | 1.6 | [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App)|
| .NET Framework | 4.6.2 | .NETFramework,Version=4.6.2 | net462 | 1.5 | N/A |

## Supported frameworks

A framework is typically referenced by a short target framework moniker or TFM. In .NET Standard this is also is generalized to *TxM* to allow a single reference to multiple frameworks.

The NuGet clients support the following frameworks. Equivalents are shown within brackets [].

Name | Abbreviation | TFMs/TxMs |
--- | --- | ---
.NET Framework | net | net11
 | | net20
 | | net35
 | | net40
 | | net403
 | | net45
 | | net451
 | | net452
 | | net46
 | | net461
 | | net462
.NET Core | netcore | netcore [netcore45]
 | | netcore45 [win, win8]
 | | netcore451 [win81]
 | | netcore50
.NET MicroFramework | netmf | netmf
Windows | win | win [win8, netcore45]
 | | win8 [netcore45, win]
 | | win81 [netcore451]
 | | win10 (not supported by Windows 10 platform)
Silverlight | sl | sl4
 | | sl5
Windows Phone | wp | wp [wp7]
 | | wp7
 | | wp75
 | | wp8
 | | wp81
 | | wpa81
Universal Windows Platform | uap | uap [uap10.0]
 | | uap10.0
.NET Standard | netstandard | netstandard1.0
 | | netstandard1.1
 | | netstandard1.2
 | | netstandard1.3
 | | netstandard1.4
 | | netstandard1.5
 | | netstandard1.6
.NET Core App | netcoreapp | netcoreapp1.0

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

A number of frameworks are related to and compatible with one another, but not necessarily equivalent:

Framework | Can use
--- | ---
uap (Universal Windows Platform) | win81
| | wpa81
| | netcore50
win (Windows Store) | winrt
| | winrt45

## NET Platform Standard

The [.NET  Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md) simplifies references between binary-compatible frameworks, allowing a single target framework to reference a combination of others. (For background, see the [.NET Primer](https://docs.microsoft.com/en-us/dotnet/articles/standard/index).)

The [NuGet Get Nearest Framework Tool](https://aka.ms/s2m3th) simulates what NuGet uses to select one framework from many available framework assets in a package based on the project's framework.

The `dotnet` series of monikers should be used in NuGet 3.3 an earlier; the `netstandard` moniker syntax should be used in v3.4 and later.

## Portable Class Libraries

> [!Warning]
> **PCLs are not recommended**
>
> Although PCLs are supported, package authors should support netstandard instead. The .NET Platform Standard is an evolution of PCLs and represents binary portability across platforms using a single moniker that isn't tied to a static like like *portable-a+b+c* monikers.

To define a target framework that refers to multiple child-target-frameworks, the `portable` keyword use used to prefix the list of referenced frameworks. Avoid artificially including extra frameworks that are not directly compiled against because it can lead to unintended side-effects in those frameworks.

Additional frameworks defined by third parties provide compatibility with other environments that are accessible in this manner. Additionally, there are shorthand profile numbers that are available to reference these combinations of related frameworks as `Profile#`, but this is not a recommended practice to use these numbers as it reduces the readability of the folders and nuspec.

Profile # | Frameworks | Full name | .NET Standard
 --- | --- | --- | ---
 Profile2 | .NETFramework 4.0 | portable-net40+win8+sl4+wp7 | 
 | Windows 8.0 | | 
 | Silverlight 4.0 | | 
 | WindowsPhone 7.0| | 
 Profile3 | .NETFramework 4.0 | portable-net40+sl4 | 
 | Silverlight 4.0 | | 
 Profile4 | .NETFramework 4.5 | portable-net45+sl4+win8+wp7 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 7.0 | | 
 Profile5 | .NETFramework 4.0 | portable-net40+win8 | 
 | Windows 8.0 | | 
 Profile6 | .NETFramework 4.0.3 | portable-net403+win8 | 
 | Windows 8.0 | | 
 Profile7 | .NETFramework 4.5 | portable-net45+win8 | netstandard1.1
 | Windows 8.0 | | 
 Profile14 | .NETFramework 4.0 | portable-net40+sl5 | 
 | Silverlight 5.0 | | 
 Profile18 | .NETFramework 4.0.3 | portable-net403+sl4 | 
 | Silverlight 4.0 | | 
 Profile19 | .NETFramework 4.0.3 | portable-net403+sl5 | 
 | Silverlight 5.0 | | 
 Profile23 | .NETFramework 4.5 | portable-net45+sl4 | 
 | Silverlight 4.0 | | 
 Profile24 | .NETFramework 4.5 | portable-net45+sl5 | 
 | Silverlight 5.0 | | 
 Profile31 | Windows 8.1 | portable-win81+wp81 | netstandard1.0
 | WindowsPhone 8.1 |
 Profile32 | Windows 8.1 | portable-win81+wpa81 | netstandard1.2
 | WindowsPhone 8.1 | | 
 Profile36 | .NETFramework 4.0 | portable-net40+sl4+win8+wp8 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | |
 Profile37 | .NETFramework 4.0 | portable-net40+sl5+win8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 Profile41 | .NETFramework 4.0.3 | portable-net403+sl4+win8 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 Profile42 | .NETFramework 4.0.3 | portable-net403+sl5+win8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 Profile44 | .NETFramework 4.5.1 | portable-net451+win81 | netstandard1.2
 | Windows 8.1 | | 
 Profile46 | .NETFramework 4.5 | portable-net45+sl4+win8 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 Profile47 | .NETFramework 4.5 | portable-net45+sl5+win8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 Profile49 | .NETFramework 4.5 | portable-net45+wp8 | netstandard1.0
 | WindowsPhone 8.0 | | 
 Profile78 | .NETFramework 4.5 | portable-net45+win8+wp8 | netstandard1.0
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile84 | WindowsPhone 8.1 | portable-wp81+wpa81 | netstandard1.0
 | WindowsPhone 8.1 | | 
 Profile88 | .NETFramework 4.0 | portable-net40+sl4+win8+wp75 | 
 | Silverlight 4.0 | |
 | Windows 8.0 | | 
 | WindowsPhone 7.5 | | 
 Profile92 | .NETFramework 4.0 | portable-net40+win8+wpa81 | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile95 | .NETFramework 4.0.3 | portable-net403+sl4+win8+wp7 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 7.0 | | 
 Profile96 | .NETFramework 4.0.3 | portable-net403+sl4+win8+wp75 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 7.5 | | 
 | Profile102 | .NETFramework 4.0.3 | portable-net403+win8+wpa81 | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile104 | .NETFramework 4.5 | portable-net45+sl4+win8+wp75 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 7.5 | | 
 Profile111 | .NETFramework 4.5 | portable-net45+win8+wpa81 | netstandard1.1
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile136 | .NETFramework 4.0 | portable-net40+sl5+win8+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile143 | .NETFramework 4.0.3 | portable-net403+sl4+win8+wp8 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile147 | .NETFramework 4.0.3 | portable-net403+sl5+win8+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile151 | NETFramework 4.5.1 | portable-net451+win81+wpa81 | netstandard1.2
 | Windows 8.1 | | 
 | WindowsPhone 8.1 | | 
 Profile154 | .NETFramework 4.5 | portable-net45+sl4+win8+wp8 | 
 | Silverlight 4.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile157 | Windows 8.1 | portable-win81+wp81+wpa81 | netstandard1.0
 | WindowsPhone 8.1 | | 
 | WindowsPhone 8.1 | | 
 Profile158 | .NETFramework 4.5 | portable-net45+sl5+win8+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.0 | | 
 Profile225 | .NETFramework 4.0 | portable-net40+sl5+win8+wpa81 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile240 | .NETFramework 4.0.3 | portable-net403+sl5+win8+wpa8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile255 | .NETFramework 4.5 | portable-net45+sl5+win8+wpa81 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 Profile259 | .NETFramework 4.5 | portable-net45+win8+wpa81+wp8 | netstandard1.0
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 | WindowsPhone 8.0 | | 
 Profile328 | .NETFramework 4.0 | portable-net40+sl5+win8+wpa81+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 | WindowsPhone 8.0 | | 
 Profile336 | .NETFramework 4.0.3 | portable-net403+sl5+win8+wpa81+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 | WindowsPhone 8.1 | | 
 Profile344 | .NETFramework 4.5 | portable-net45+sl5+win8+wpa81+wp8 | 
 | Silverlight 5.0 | | 
 | Windows 8.0 | | 
 | WindowsPhone 8.1 | | 
 | WindowsPhone 8.0 | | 

Additionally, NuGet packages targeting Xamarin can use additional Xamarin-defined frameworks. See [Creating NuGet packages for Xamarin](https://developer.xamarin.com/guides/cross-platform/advanced/nuget/).

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
> Stephen Cleary has created a tool that lists the supported PCLs, which you can find on his post, [Framework profiles in .NET](http://blog.stephencleary.com/2012/05/framework-profiles-in-net.html).
