---
title: .NET SDK, MSBuild, and Visual Studio versioning
description: Learn about the versioning relationship between the .NET SDK and MSBuild/VS.
author: StephenBonikowsky
ms.author: stebon
ms.date: 06/10/2021
---
# Overview of .NET, MSBuild, and Visual Studio versioning

Understanding the versioning of the .NET SDK and how it relates to Visual Studio and MSBuild can be confusing. MSBuild versions with Visual Studio, but is also included in the .NET SDK. The SDK has a minimum version of MSBuild and Visual Studio that it works with, and it won't load in a version of Visual Studio that's older than that minimum version.

## Versioning

The first part of the .NET SDK version matches the .NET version that it includes, runs on, and targets by default.  The feature band starts at 1 and increases for each quarterly Visual Studio minor release.  The patch version increments with each month's servicing updates.

For example, version 5.0.203 ships with .NET 5, is the second minor Visual Studio release since 5.0.100 first came out, and is the third patch since 5.0.200 released.

## Lifecycle

The support timeframe for the SDK typically matches that of the Visual Studio version it's included in.

| SDK Version      | MSBuild/VS version | Ship date    | Lifecycle |
|------------------|--------------------|--------------|-----------|
| 2.1.5xx          | 15.9               | Nov '18      | Aug '21*  |
| 2.1.8xx          | 16.2 (No VS)       | July '19     | Aug '21   |
| 3.1.1xx          | 16.4               | Dec '19      | Oct '21   |
| 3.1.4xx          | 16.7               | Aug '20      | Dec '22   |
| 5.0.1xx          | 16.8               | November '20 | Mar '21   |
| 5.0.2xx          | 16.9               | March '21    | Aug '22   |
| 5.0.3xx          | 16.10              | May '21      | Aug '21   |
| 5.0.4xx          | 16.11              | Aug '21      | Feb '22*  |
| 6.0.100-rc1      | 17.0-preview 4     | September    | N/A       |
| 6.0.100          | 17.0**             | Nov. '21     |           |

> [!NOTE]
> Targeting `net6.0` is officially supported in Visual Studio 17.0+ only.

> \* MSbuild/Visual Studio supported for longer
>
> \*\* When .NET 6 releases, the goal is for the .NET SDK to be functional in version 16.11 for **downlevel** targeting. This means that you're not forced to update your SDK and Visual Studio versions simultaneously. However, you won't be able to target .NET 6 because of limitations in 6.0 features and C#10 features in version 16.11. This compatibility is specifically for targeting 5.0 and below.

Expect breaking changes that require a new MSBuild and Visual Studio version at least once a year, for each major SDK release. All versions of 5.0.Nxx SDK will load on all versions of Visual Studio and MSBuild from 16.8 - 16.11, as no breaking changes were made during that time. There shouldn't be breaking changes in SDK feature (patch) updates.

## Reference

- [Overview of how .NET is versioned](../versions/index.md)
- [.NET and .NET Core official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)
- [Microsoft .NET and .NET Core](/lifecycle/products/microsoft-net-and-net-core)
- [.NET Downloads (Windows, Linux, and macOS)](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio 2019 Product Lifecycle and Servicing](/visualstudio/releases/2019/servicing-vs2019)
