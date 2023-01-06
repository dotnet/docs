---
title: .NET SDK, MSBuild, and Visual Studio versioning
description: Learn about the versioning relationship between the .NET SDK and MSBuild/VS.
author: StephenBonikowsky
ms.author: stebon
ms.custom: updateeachrelease
ms.date: 06/10/2021
---
# Overview of .NET, MSBuild, and Visual Studio versioning

Understanding the versioning of the .NET SDK and how it relates to Visual Studio and MSBuild can be confusing. MSBuild versions with Visual Studio, but is also included in the .NET SDK. The SDK has a minimum version of MSBuild and Visual Studio that it works with, and it won't load in a version of Visual Studio that's older than that minimum version.

## Versioning

The first part of the .NET SDK version matches the .NET version that it includes, runs on, and targets by default.  The feature band starts at 1 and increases for each quarterly Visual Studio minor release.  The patch version increments with each month's servicing updates.

For example, version 5.0.203 ships with .NET 5, is the second minor Visual Studio release since 5.0.100 first came out, and is the third patch since 5.0.200 released.

## Lifecycle

The support timeframe for the SDK typically matches that of the Visual Studio version it's included in.

| SDK Version      | MSBuild/Visual Studio version | Ship date    | Lifecycle |
|------------------|--------------------|--------------|-----------|
| 2.1.5xx          | 15.9               | Nov '18      | Aug '21   |
| 2.1.8xx          | 16.2 (No VS)       | July '19     | Aug '21   |
| 3.1.1xx          | 16.4               | Dec '19      | Oct '21   |
| 3.1.4xx          | 16.7               | Aug '20      | Dec '22   |
| 5.0.1xx          | 16.8               | Nov '20      | Mar '21   |
| 5.0.2xx          | 16.9               | March '21    | May '22<sup>1</sup>  |
| 5.0.3xx          | 16.10              | May '21      | Aug '21   |
| 5.0.4xx          | 16.11              | Aug '21      | May '22<sup>1</sup>  |
| 6.0.100          | 17.0<sup>3</sup>   | Nov '21      | Jul '23   |
| 6.0.200          | 17.1               | Feb '22      | May '22   |
| 6.0.300          | 17.2<sup>3</sup>   | May '22      | Oct '23   |
| 6.0.400          | 17.3               | Aug '22      | Nov '24<sup>2</sup>   |
| 7.0.100          | 17.4               | Nov '22      | Jul '23   |
| 7.0.200          | 17.5<sup>5</sup>   | Feb '23      | May '23   |
| 7.0.300          | 17.6               | May '23      | TBD       |

> [!NOTE]
> Targeting `net6.0` is officially supported in Visual Studio 17.0+ only.

> <sup>1</sup> The .NET 5 SDK will be supported in Visual Studio scenarios until December 2022 when 3.1 goes out of support. MSBuild/Visual Studio supported for longer.
>
> <sup>2</sup> Visual Studio 17.3 will be in support until 17.4 ships
>
> [Visual Studio 2019 Lifecycle](/lifecycle/products/visual-studio-2019)
>
> [Visual Studio 2022 Lifecycle](/lifecycle/products/visual-studio-2022)

> <sup>3</sup> With .NET 6, the.NET 6.0.100 SDK can be used in version 16.11 for **downlevel** targeting. This means that you're not forced to update your SDK and Visual Studio versions simultaneously. However, you won't be able to target .NET 6 because of limitations in 6.0 features and C# 10 features in version 16.11. This compatibility is specifically for targeting 5.0 and below.
>
> <sup>4</sup> 6.0.300 and newer SDKs require a minimum Visual Studio version of 17.0.
>
> <sup>5</sup> 7.0.200 and newer SDKs require a minimum Visual Studio version of 17.4.

## Targeting and support rules

Starting with .NET SDK 7.0.100 and .NET SDK 6.0.300, a policy has been put into place regarding which versions of MSBuild and Visual Studio a given version of the .NET SDK will run in. The policy is:

- Each new TargetFramework **requires** a new Visual Studio version or a new `dotnet` version.
- The first version of Visual Studio that supports a new TargetFramework becomes a floor for the feature bands of that SDK for Roslyn API surface, msbuild targets, source generators, analyzers, and so on.
- The first version of a new .NET SDK that supports a new TargetFramework can still be used with the prior version of Visual Studio to allow one quarter for tooling and infrastructure (for example, actions and pipelines) to migrate.

| SDK | Visual Studio version<br/>the SDK ships with | Minimum Visual Studio version | Max TargetFramework in<br/>minimum Visual Studio version | Max TargetFramework in `dotnet` |
|-|-|-|-|-|
| 6.0.100 | 17.0 | 16.11 | Net5.0 | Net6.0 |
| 6.0.200 | 17.1 | 17.0 | Net6.0 | Net6.0 |
| 6.0.300 | 17.2 | 17.0 | Net6.0 | Net6.0 |
| 6.0.400 | 17.3 | 17.0 | Net6.0 | Net6.0 |
| 7.0.100 | 17.4 | 17.3 | Net6.0 | Net7.0 |
| 7.0.200 | 17.5 | 17.4 | Net7.0 | Net7.0 |
| 7.0.300 | 17.6 | 17.4 | Net7.0 | Net7.0 |
| 7.0.400 | 17.7 | 17.4 | Net7.0 | Net7.0 |

> [!NOTE]
> The table depicts how these versioning rules will be applied going forward, starting with .NET SDK 7.0.100 and .NET SDK 6.0.300. It also depicts how the policy would have applied to previously shipped versions of the .NET SDK, had it been in place then. However, the requirements for previous versions of the SDK don't change &mdash; that is, the minimum required version of Visual Studio for .NET SDK 6.0.100 or 6.0.200 remains 16.10.

To ensure consistent tooling, you should use `dotnet build` rather than `msbuild` to build your application when possible.

## Preview versioning

Major versions of the .NET SDK are typically released within a few days of a Visual Studio preview version. While there may be other combinations that work, only the latest preview released is tested and officially supported. The following table shows which version of Visual Studio each .NET 7 preview version was tested with prior to release.

| SDK preview version | Visual Studio version |
|-|-|
| Preview 1 | 17.2 Preview 1 |
| Preview 2 | 17.2 Preview 2 |
| Preview 3 | 17.2 Preview 3 |
| Preview 4 | 17.3 Preview 1 |
| Preview 5 | 17.3 Preview 2 |
| Preview 6 | 17.3 Preview 3 |
| Preview 7 | 17.4 Preview 1 |
| RC 1 | 17.4 Preview 2 |
| RC 2 | 17.4 Preview 3 |
| 7.0.100 | 17.4.0 |
| 8.0.100 Preview 1 | 17.6 Preview 1 |

## Reference

- [Overview of how .NET is versioned](../versions/index.md)
- [.NET and .NET Core official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)
- [Microsoft .NET and .NET Core](/lifecycle/products/microsoft-net-and-net-core)
- [.NET Downloads (Windows, Linux, and macOS)](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio 2019 Product Lifecycle and Servicing](/visualstudio/releases/2019/servicing-vs2019)
