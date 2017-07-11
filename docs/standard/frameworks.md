---
title: Target frameworks | Microsoft Docs
description: Information surrounding target frameworks for .NET Core applications and libraries.
keywords: .NET, .NET Core, framework, TFM
author: richlander
ms.author: mairaw
ms.date: 07/10/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6ef56a2e-593d-497b-925a-1e25bb6df2e6
---

# Target frameworks

Application Programming Interfaces (APIs) are contracts between software systems describing how their objects and methods can interact. Frameworks are made up of collections of APIs. When you target one or more frameworks in an app or library, you're specifying the sets and versions of APIs you'd like the app or library to use.

An app or library can target a version of [.NET Standard](~/docs/standard/net-standard.md). .NET Standard versions aren't frameworks but represent standardized sets of APIs across all .NET frameworks. For example, a library can target .NET Standard 1.6 and gain access to APIs that function across several .NET implementations all at once.

An app or library can also target a specific .NET implementation to gain access to implementation-specific APIs. For example, an app that targets Xamarin.iOS gets access to Xamarin-provided iOS API wrappers.

For some target frameworks (for example, the .NET Framework), the APIs are defined by the assemblies that the framework installs on a system and may include app model APIs (for example, ASP.NET).

For NuGet package-based target frameworks that aren't preinstalled on a system (for example, .NET Standard and .NET Core), the APIs are defined by the packages listed in the app or library. A *metapackage* is a NuGet package that has no content of its own but is a list of dependencies (other packages). A NuGet package-based target framework implicitly specifies a metapackage that references all the packages that together make up the framework.

## Latest target framework versions

The following table defines the set of target frameworks that you can use, how they're referenced, and which version of the [.NET Standard](~/docs/standard/net-standard.md) they implement. These target framework versions are the latest stable versions. Pre-release versions aren't shown. A Target Framework Moniker (TFM) is a standardized token format for specifying the target framework of a .NET app or library. Target frameworks are referenced by a TFM (long name, such as .NETFramework,Version=4.7) or Compact TFM (short name, such as net47). 

| Target Framework      | Latest Version | Target Framework Moniker (TFM) | Compact Target Framework Moniker (TFM) | .NET Standard Version | Metapackage |
| :-------------------: | :------------: | :----------------------------: | :------------------------------------: | :-------------------: | :---------: |
| .NET Standard         | 1.6.1          | .NETStandard,Version=1.6       | netstandard1.6                         | N/A                   | [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) |
| .NET Core Application | 1.1.2          | .NETCoreApp,Version=1.1        | netcoreapp1.1                          | 1.6                   | [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) |
| .NET Framework        | 4.7            | .NETFramework,Version=4.7      | net47                                  | 1.5                   | N/A |

## Supported target frameworks

A target framework is typically referenced by a compact TFM. A TFM value can represent one or multiple target frameworks. The following table shows the target frameworks supported by the .NET Core SDK and the NuGet client. Equivalents are shown within brackets (`[]`).

| Name                       | Abbreviation | Compact TFM                                  |
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

## How to specify target frameworks

Target frameworks are specified in your *csproj* project file. When a single target framework is specified, use the **\<TargetFramework>** element. The following console app project file demonstrates how to target the `netcoreapp1.0` TFM:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.0</TargetFramework>
  </PropertyGroup>

</Project>
```

The following library project file targets newer APIs of .NET Standard (`netstandard1.4`) and older APIs of the .NET Framework (`net40` and `net45`). When targeting more than one target framework, use the plural **\<TargetFrameworks>** element. Note how the use of `Condition` attributes includes implementation-specific package references when the library is compiled for the two .NET Framework TFMs:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard1.4;net40;net45</TargetFrameworks>
  </PropertyGroup>

  <!-- Conditionally obtain references for the .NET Framework 4.0 target -->
  <ItemGroup Condition=" '$(TargetFramework)' == 'net40' ">
    <Reference Include="System.Net" />
  </ItemGroup>

  <!-- Conditionally obtain references for the .NET Framework 4.5 target -->
  <ItemGroup Condition=" '$(TargetFramework)' == 'net45' ">
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Threading.Tasks" />
  </ItemGroup>

</Project>
```

## Deprecated target frameworks

The following target frameworks are deprecated. Packages targeting these frameworks should migrate to the indicated replacements.

| Deprecated TFM       | Replacement |
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

## See also

[Packages, Metapackages and Frameworks](~/docs/core/packages.md)   
[Developing Libraries with Cross Platform Tools](~/docs/core/tutorials/libraries.md)   
[.NET Standard](~/docs/standard/net-standard.md) topic   
[dotnet/standard GitHub repository](https://github.com/dotnet/standard)   
[NuGet Tools GitHub Repository](https://github.com/joelverhagen/NuGetTools)   
[Framework Profiles in .NET](http://blog.stephencleary.com/2012/05/framework-profiles-in-net.html)
