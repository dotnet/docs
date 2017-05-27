---
title: Target frameworks | Microsoft Docs
description: Information surrounding target frameworks for .NET Core applications and libraries.
keywords: .NET, .NET Core, framework, TFM
author: richlander
ms.author: mairaw
ms.date: 05/23/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6ef56a2e-593d-497b-925a-1e25bb6df2e6
---

# Target frameworks

*Frameworks* define the objects, methods, and tools that you use to create apps and libraries. The .NET Framework is used to create apps and libraries primarily for execution on systems running a Windows operating system. .NET Core includes a framework that allows you to build apps and libraries that run on a variety of operating systems.

The terms *framework* and *platform* are sometimes confusing given how they're used in phrases and their context. For example, you'll see .NET Core described as a framework in the context of building apps and libraries and also described as a platform in the context of where app and library code is executed. A *computing platform* describes *where and how* an application is run. Since .NET Core executes code with the [.NET Core Common Language Runtime (CoreCLR)](https://github.com/dotnet/coreclr), it's also a platform. The same is true of the .NET Framework, which has the [Common Language Runtime (CLR)](clr.md) to execute app and library code that was developed with the .NET Framework's framework objects, methods, and tools.

The objects and methods of frameworks are called Application Programming Interfaces (APIs). Framework APIs are used in [Visual Studio](https://www.visualstudio.com/), [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/), [Visual Studio Code](https://code.visualstudio.com/), and other Integrated Development Environments (IDEs) and editors to provide you with the correct set of objects and methods for development. Frameworks are also used by [NuGet](https://www.nuget.org/) for the production and consumption of NuGet packages to ensure that you produce and use appropriate packages for the frameworks that you target in your app or library.

When you *target a framework* or target several of them, you've decided which sets of APIs and which versions of those APIs you'd like to use. Frameworks are referenced in several ways: by product name, by long or short-form framework names, and by family.

## Referring to frameworks

There are several ways to refer to frameworks, most of which are used throughout the .NET Core documentation. Using .NET Framework 4.6.2 as an example, the following formats are used:

**Referring to a product**

You can refer to a .NET platform or runtime. Both are equally valid.

* .NET Framework 4.6.2
* .NET 4.6.2

**Referring to a framework**

You can refer to a framework or targeting of a framework using long- or short-forms of the Target Framework Moniker (TFM). Both are equally valid.

* `.NETFramework,Version=4.6.2`
* `net462`

**Referring to a family of frameworks**

You can refer to a family of frameworks using long or short-forms of the framework ID. Both are equally valid.

* `.NETFramework`
* `net`

## Latest framework versions

The following table defines the set of frameworks that you can use, how they're referenced, and which version of the [.NET Standard](library.md) they implement. These framework versions are the latest stable versions. Pre-release versions aren't shown.

| Framework             | Latest Version | Target Framework Moniker (TFM) | Compact Target Framework Moniker (TFM) | .NET Standard Version | Metapackage |
| :-------------------: | :------------: | :----------------------------: | :------------------------------------: | :-------------------: | :---------: |
| .NET Standard         | 1.6.1          | .NETStandard,Version=1.6       | netstandard1.6                         | N/A                   | [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) |
| .NET Core Application | 1.1.1          | .NETCoreApp,Version=1.1        | netcoreapp1.1                          | 1.6                   | [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) |
| .NET Framework        | 4.7            | .NETFramework,Version=4.7      | net47                                  | 1.5                   | N/A |

## Supported frameworks

A framework is typically referenced by a short TFM. A TFM value can represent one or multiple frameworks. The following table shows the frameworks supported by the .NET Core SDK and the NuGet client. Equivalents are shown within brackets (`[]`).

| Name                       | Abbreviation | TFM                                          |
| -------------------------- | ------------ | -------------------------------------------- |
| .NET Standard              | netstandard  | netstandard1.0                               |
|                            |              | netstandard1.1                               |
|                            |              | netstandard1.2                               |
|                            |              | netstandard1.3                               |
|                            |              | netstandard1.4                               |
|                            |              | netstandard1.5                               |
|                            |              | netstandard1.6                               |
|                            |              | netstandard2.0                               |
| .NET Core                  | netcoreapp   | netcoreapp1.0                                |
|                            |              | netcoreapp1.1                                |
|                            |              | netcoreapp2.0                                |
| .NET Framework             | net          | net11                                        |
|                            |              | net20                                        |
|                            |              | net35                                        |
|                            |              | net40                                        |
|                            |              | net403                                       |
|                            |              | net45                                        |
|                            |              | net451                                       |
|                            |              | net452                                       |
|                            |              | net46                                        |
|                            |              | net461                                       |
|                            |              | net462                                       |
|                            |              | net47                                        |
| Windows Store              | netcore      | netcore [netcore45]                          |
|                            |              | netcore45 [win, win8]                        |
|                            |              | netcore451 [win81]                           |
| .NET Micro Framework       | netmf        | netmf                                        |
| Silverlight                | sl           | sl4                                          |
|                            |              | sl5                                          |
| Windows Phone              | wp           | wp [wp7]                                     |
|                            |              | wp7                                          |
|                            |              | wp75                                         |
|                            |              | wp8                                          |
|                            |              | wp81                                         |
|                            |              | wpa81                                        |
| Universal Windows Platform | uap          | uap [uap10.0]                                |
|                            |              | uap10.0 [win10] [netcore50]                  |

## Deprecated frameworks

The following frameworks are deprecated. Packages targeting these frameworks should migrate to the indicated replacements.

| Deprecated framework | Replacement |
| -------------------- | ----------- |
| aspnet50             | netcoreapp  |
| aspnetcore50         |             |
| dnxcore50            |             |
| dnx                  |             |
| dnx45                |             |
| dnx451               |             |
| dnx452               |             |
| dotnet               | netstandard |
| dotnet50             |             |
| dotnet51             |             |
| dotnet52             |             |
| dotnet53             |             |
| dotnet54             |             |
| dotnet55             |             |
| dotnet56             |             |
| netcore50            | uap10.0     |
| win                  | netcore45   |
| win8                 | netcore45   |
| win81                | netcore451  |
| win10                | uap10.0     |
| winrt                | netcore45   |

## Precedence

A number of frameworks are related to and compatible with one another but not necessarily equivalent:

| Framework                        | Can use   |
| -------------------------------- | --------- |
| uap (Universal Windows Platform) | win81     |
|                                  | wpa81     |
|                                  | netcore50 |
| win (Windows Store)              | winrt     |
|                                  | winrt45   |

## .NET Standard

The [.NET Standard](https://github.com/dotnet/standard) simplifies references between binary-compatible frameworks, allowing a single target framework to reference a combination of others. For more information, see the [.NET Standard Library](library.md) topic.

The [NuGet Tools Get Nearest Framework Tool](http://nugettoolsdev.azurewebsites.net/) simulates the NuGet logic used for the selection of one framework from many available framework assets in a package based on the project's framework. To use the tool, enter one project framework and one or more package frameworks. Select the **Submit** button. The tool indicates if the package frameworks you list are compatible with the project framework you provide.

## Portable Class Libraries

For information on Portable Class Libraries, see the [Portable Class Libraries](https://docs.microsoft.com/nuget/schema/target-frameworks#portable-class-libraries) section of the *Target Framework* topic in the NuGet documentation. Stephen Cleary created a tool that lists the supported PCLs. For more information, see [Framework Profiles in .NET](http://blog.stephencleary.com/2012/05/framework-profiles-in-net.html).
