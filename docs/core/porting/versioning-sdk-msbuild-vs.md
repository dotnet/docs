---
title: .NET SDK, MSBuild, and Visual Studio versioning
description: Learn about the versioning relationship between the .NET SDK and MSBuild/VS.
author: StephenBonikowsky
ms.author: stebon
ms.date: 06/10/2021
---
# Overview of .NET, MSBuild, and Visual Studio versioning

Understanding the versioning of the SDK and how it relates to Visual Studio and MSBuild can frequently be confusing. MSBuild versions with VS but is also included in the SDK. The SDK has a minimum version of MSBuild that it works with and it won't load in a VS that is older than it supports.

## Versioning

The first part of the SDK matches the .NET version that it includes, runs on, and targets by default.  The feature band starts at 1 and increases for each quarterly VS minor release.  The patch version increments with each month's servicing updates.

For example, 5.0.203 ships with .NET 5.0, is the second minor VS release since 5.0.100 first came out, and is the third patch since 5.0.200 released.

## Lifecycle

The support timeframe for the SDK typically matches the VS it's included in.

| SDK Version      | MSBuild/VS version | Minimum required MSBuild/VS Version | Ship date    | Lifecycle |
|------------------|--------------------|-------------------------------------|--------------|-----------|
| 2.1.5xx          | 15.9               | 15.3                                | Nov '18      | Aug '21*  |
| 2.1.8xx          | 16.2 (No VS)       | 16.0                                | July '19     | Aug '21   |
| 3.1.1xx          | 16.4               | 16.3                                | Dec '19      | Dec '22   |
| 3.1.4xx          | 16.7               | 16.7                                | Aug '20      | Dec '22   |
| 5.0.1xx          | 16.8               | 16.8                                | November '20 | Mar '21   |
| 5.0.2xx          | 16.9               | 16.8                                | March '21    | Aug '22   |
| 5.0.3xx          | 16.10              | 16.8                                | May '21      | Aug '21   |
| 5.0.4xx          | 16.11              | 16.8                                | Aug '21      | Feb '22*  |
| 6.0.100-preview4 | 16.10 (No VS)      | 16.10-preview3                      | May '21      | N/A       |
| 6.0.100-preview5 | 17.0-preview 1     | 16.10                               | June '21     | N/A       |
| 6.0.100-preview6 | 17.0-preview 2     | 16.10                               | July         | N/A       |
| 6.0.100-preview7 | 17.0-preview 3     | 16.10                               | August       | N/A       |
| 6.0.100-rc1      | 17.0-preview 4     | 16.10                               | September    | N/A       |
| 6.0.100          | 17.0               | 16.10**                             | Nov. '21     |           |

> [!NOTE]
> The Minimum version is what's required to load the SDK but doesn't cover what's supported. Targeting net6.0 is officially supported in 17.0+ only.

> \* MSbuild/VS supported for longer
>
> \*\* You won't have to upgrade to 17.0 on the day .NET 6 releases. This is the current version and will likely be 16.11 at release. This version supports downlevel targeting, such as .NET 5 and below, but doesn't allow targeting .NET 6 for the purpose of using .NET 6 or C# 10 features.

Expect breaking changes that require a new MSBuild and VS version at least once a year, for each major SDK release. There shouldn't be breaking changes in SDK feature (patch) updates.

## Reference

- [Overview of how .NET is versioned](../versions/index.md)
- [.NET and .NET Core official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)
- [Microsoft .NET and .NET Core](/lifecycle/products/microsoft-net-and-net-core)
- [.NET Downloads (Windows, Linux, and macOS)](https://dotnet.microsoft.com/download/dotnet)
