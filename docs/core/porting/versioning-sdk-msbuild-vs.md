---
title: .NET SDK, MSBuild, and Visual Studio versioning
description: Learn about the versioning relationship between the .NET SDK and MSBuild/VS.
author: StephenBonikowsky
ms.author: stebon
ms.custom: updateeachrelease
ms.date: 11/06/2024
ms.topic: article
---
# .NET SDK, MSBuild, and Visual Studio versioning

The versioning of the .NET SDK and how it relates to Visual Studio and MSBuild can be confusing. MSBuild versions with Visual Studio, but is also included in the .NET SDK. The SDK has a minimum version of MSBuild and Visual Studio that it works with, and it won't load in a version of Visual Studio that's older than that minimum version.

## Versioning

The first part of the .NET SDK version matches the .NET version that it includes, runs on, and targets by default. The feature band starts at 1 and increases for each quarterly Visual Studio minor release. The patch version increments with each month's servicing updates.

For example, version 7.0.203 ships with .NET 7, is the second minor Visual Studio release since 7.0.100 first came out, and is the third patch since 7.0.200 released.

An installation of Visual Studio includes a single matching copy of the .NET SDK. If you update your Visual Studio instance, the .NET SDK installed by Visual Studio is also updated, including across .NET SDK feature bands and major bands. If you want to use a different .NET SDK than what's installed by Visual Studio, you can install it from the [.NET download page](https://aka.ms/dotnet/download), and Visual Studio upgrade won't touch that version. You're responsible for updating that copy of the .NET SDK from then on.

> [!NOTE]
The .NET SDK supports targeting down-level versions of .NET, so we recommend always updating your .NET SDK along with your Visual Studio version.

## Lifecycle

The support timeframe for the SDK typically matches that of the Visual Studio version it's included in.

<!-- markdownlint-disable MD033 -->
<details>
<summary>Expand to see out-of-support .NET versions</summary>

| SDK version | MSBuild/Visual Studio version | Ship date | Lifecycle |
|-------------|-------------------------------|-----------|-----------|
| 2.1.5xx     | 15.9                          | Nov '18   | Aug '21   |
| 2.1.8xx     | 16.2 (No VS)                  | July '19  | Aug '21   |
| 3.1.1xx     | 16.4                          | Dec '19   | Oct '21   |
| 3.1.4xx     | 16.7                          | Aug '20   | Dec '22   |
| 5.0.1xx     | 16.8                          | Nov '20   | Mar '21   |
| 5.0.2xx     | 16.9                          | March '21 | May '22   |
| 5.0.3xx     | 16.10                         | May '21   | Aug '21   |
| 5.0.4xx     | 16.11                         | Aug '21   | May '22   |
| 6.0.1xx     | 17.0                          | Nov '21   | Nov '24   |
| 6.0.2xx     | 17.1                          | Feb '22   | May '22   |
| 6.0.3xx     | 17.2<sup>3</sup>              | May '22   | Oct '23   |
| 6.0.4xx     | 17.3                          | Aug '22   | Nov '24   |
| 7.0.1xx     | 17.4                          | Nov '22   | May '24   |
| 7.0.2xx     | 17.5<sup>3</sup>              | Feb '23   | May '23   |
| 7.0.3xx     | 17.6                          | May '23   | May '24   |
| 7.0.4xx     | 17.7                          | Aug '23   | May '24   |

</details>
<!-- markdownlint-enable MD033 -->

### Supported .NET versions

| SDK version | MSBuild/Visual Studio version | Ship date | Lifecycle           |
|-------------|-------------------------------|-----------|---------------------|
| 8.0.1xx     | 17.8                          | Nov '23   | Nov '26<sup>1</sup> |
| 8.0.2xx     | 17.9                          | Feb '24   | May '24             |
| 8.0.3xx     | 17.10                         | May '24   | Jan '26                 |
| 8.0.4xx     | 17.11                         | Aug '24   | Nov '26<sup>2</sup> |
| 9.0.1xx     | 17.12                         | Nov '24   | May '26             |
| 9.0.2xx     | 17.13                         | Feb '25   | May '25             |
| 9.0.3xx     | 17.14                         | May '25   | May '26             |

> [!NOTE]
> <sup>1</sup> .1xx .NET SDK feature bands are supported throughout the lifecycle of major .NET versions. During the extended support period, support is limited to security fixes and minimal high-priority non-security fixes for Linux only. To learn more about the reasoning for this extended support, see [Source-build support](https://github.com/dotnet/source-build#support).
>
> <sup>2</sup> .4xx .NET SDK feature bands are supported for the life of the matching runtime as stand-alone installs.
>
> [Visual Studio 2019 Lifecycle](/lifecycle/products/visual-studio-2019)
>
> [Visual Studio 2022 Lifecycle](/lifecycle/products/visual-studio-2022)

## Targeting and support rules

A the following policy dictates which versions of MSBuild and Visual Studio a given version of the .NET SDK will run in:

- Each new TargetFramework **requires** a new Visual Studio version or a new `dotnet` version.
- The first version of Visual Studio that supports a new TargetFramework becomes a floor for the feature bands of that SDK for Roslyn API surface, MSBuild targets, source generators, analyzers, and so on.
- The first version of a new .NET SDK that supports a new TargetFramework can still be used with the prior version of Visual Studio to allow one quarter for tooling and infrastructure (for example, actions and pipelines) to migrate.

| SDK | Visual Studio version<br/>the SDK ships with | Minimum Visual Studio version | Max TargetFramework in<br/>minimum Visual Studio version | Max TargetFramework in `dotnet` |
|---------|-------|------------------|--------|--------|
| 8.0.100 | 17.8  | 17.7             | Net7.0 | Net8.0 |
| 8.0.200 | 17.9  | 17.8             | Net8.0 | Net8.0 |
| 8.0.300 | 17.10 | 17.8             | Net8.0 | Net8.0 |
| 8.0.400 | 17.11 | 17.8             | Net8.0 | Net8.0 |
| 9.0.100 | 17.12 | 17.11            | Net8.0 | Net9.0 |
| 9.0.200 | 17.13 | 17.12            | Net9.0 | Net9.0 |
| 9.0.300 | 17.14 | 17.12            | Net9.0 | Net9.0 |

> [!NOTE]
> The table depicts how these versioning rules are applied, starting with .NET SDK 7.0.100 and .NET SDK 6.0.300. It also depicts how the policy would have applied to previously shipped versions of the .NET SDK, had it been in place then. However, the requirements for previous versions of the SDK don't change&mdash;that is, the minimum required version of Visual Studio for .NET SDK 6.0.100 or 6.0.200 remains 16.10.
>
> Targeting `net8.0` is officially supported in Visual Studio 17.8+ only.
>
> Targeting `net9.0` is officially supported in Visual Studio 17.12+ only.

To ensure consistent tooling, you should use `dotnet build` rather than `msbuild` to build your application when possible.

## Preview versioning

Major versions of the .NET SDK are typically released within a few days of a Visual Studio preview version. While there might be other combinations that work, only the latest preview released is tested and officially supported. The following table shows which version of Visual Studio each .NET preview version was tested with prior to release.

| SDK preview version | Visual Studio version |
|---------------------|-----------------------|
| 9.0.100 RC 1        | 17.12 Preview 2       |
| 9.0.100 RC 2        | 17.12 Preview 3       |
| 9.0.100 GA          | 17.12 GA              |
| 10.0.100 Preview 1  | 17.14 Preview 1       |
| 10.0.100 Preview 2  | 17.14 Preview 2       |
| 10.0.100 Preview 3  | 17.14 Preview 3       |

## Reference

- [Overview of how .NET is versioned](../versions/index.md)
- [.NET and .NET Core official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)
- [Microsoft .NET and .NET Core](/lifecycle/products/microsoft-net-and-net-core)
- [.NET Downloads (Windows, Linux, and macOS)](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio 2019 Product Lifecycle and Servicing](/visualstudio/releases/2019/servicing-vs2019)
