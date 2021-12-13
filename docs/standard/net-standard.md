---
title: .NET Standard
description: Learn about .NET Standard, its versions, and the .NET implementations that support it.
ms.date: 11/22/2021
ms.prod: dotnet
ms.technology: dotnet-standard
ms.custom: "updateeachrelease"
ms.assetid: c044882c-af15-45f2-96d1-534557a5ee9b
---
# .NET Standard

[.NET Standard](https://github.com/dotnet/standard) is a formal specification of .NET APIs that are available on multiple .NET implementations. The motivation behind .NET Standard was to establish greater uniformity in the .NET ecosystem. If you want to share code between .NET Framework and any other .NET implementation, such as .NET Core, your library should target .NET Standard 2.0.

.NET 5 and later versions adopt a different approach to establishing uniformity that eliminates the need for .NET Standard in many scenarios. For more information, see [.NET 5+ and .NET Standard](#net-5-and-net-standard) later in this article.

## .NET implementation support

The various .NET implementations target specific versions of .NET Standard. Each .NET implementation version advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. For example, .NET Framework 4.6 implements .NET Standard 1.3, which means that it exposes all APIs defined in .NET Standard versions 1.0 through 1.3. Similarly, .NET Framework 4.6.1 implements .NET Standard 1.4, while .NET 5 implements .NET Standard 2.1.

The following table lists the **minimum** implementation versions that support each .NET Standard version. That means that later versions of a listed implementation also support the corresponding .NET Standard version. For example, .NET Core 2.1 and later versions support .NET Standard 2.0 and earlier versions.

[!INCLUDE [net-standard-table](../../includes/net-standard-table.md)]

To find the highest version of .NET Standard that you can target, do the following steps:

1. Find the row that indicates the .NET implementation you want to run on.
1. Find the column in that row that indicates your version starting from right to left.
1. The column header indicates the .NET Standard version that your target supports. You may also target any lower .NET Standard version. Higher .NET Standard versions will also support your implementation.
1. Repeat this process for each platform you want to target. If you have more than one target platform, you should pick the smaller version among them. For example, if you want to run on .NET Framework 4.8 and .NET 5, the highest .NET Standard version you can use is .NET Standard 2.0.

### Which .NET Standard version to target

We recommend you target .NET Standard 2.0, unless you need to support an earlier version. Most general-purpose libraries should not need APIs outside of .NET Standard 2.0. .NET Standard 2.0 is supported by all modern platforms and is the recommended way to support multiple platforms with one target.

If you need to support .NET Standard 1.x, we recommend that you *also* target .NET Standard 2.0. .NET Standard 1.x is distributed as a granular set of NuGet packages, which creates a large package dependency graph and results in developers downloading a lot of packages when building. For more information, see [Cross-platform targeting](library-guidance/cross-platform-targeting.md) and [.NET 5+ and .NET Standard](#net-5-and-net-standard) later in this article.

### .NET Standard versioning rules

There are two primary versioning rules:

- Additive: .NET Standard versions are logically concentric circles: higher versions incorporate all APIs from previous versions. There are no breaking changes between versions.
- Immutable: Once shipped, .NET Standard versions are frozen.

There will be no new .NET Standard versions after 2.1. For more information, see [.NET 5+ and .NET Standard](#net-5-and-net-standard) later in this article.

## Specification

The .NET Standard specification is a standardized set of APIs. The specification is maintained by .NET implementers, specifically Microsoft (includes .NET Framework, .NET Core, and Mono) and Unity.

### Official artifacts

The official specification is a set of *.cs* files that define the APIs that are part of the standard. The [ref directory](https://github.com/dotnet/standard/tree/master/src/netstandard/ref) in the [dotnet/standard repository](https://github.com/dotnet/standard) defines the .NET Standard APIs.

The [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) metapackage ([source](https://github.com/dotnet/standard/blob/master/src/netstandard/pkg/NETStandard.Library.dependencies.props)) describes the set of libraries that define (in part) one or more .NET Standard versions.

A given component, like `System.Runtime`, describes:

- Part of .NET Standard (just its scope).
- Multiple versions of .NET Standard, for that scope.

Derivative artifacts are provided to enable more convenient reading and to enable certain developer scenarios (for example, using a compiler).

- [API list in markdown](https://github.com/dotnet/standard/tree/master/docs/versions).
- Reference assemblies, distributed as NuGet packages and referenced by the [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/) metapackage.

### Package representation

The primary distribution vehicle for the .NET Standard reference assemblies is NuGet packages. Implementations are delivered in a variety of ways, appropriate for each .NET implementation.

NuGet packages target one or more [frameworks](frameworks.md). .NET Standard packages target the ".NET Standard" framework. You can target the .NET Standard framework using the `netstandard` [compact TFM](frameworks.md) (for example, `netstandard1.4`). Libraries that are intended to run on multiple implementations of .NET should target this framework. For the broadest set of APIs, target `netstandard2.0` since the number of available APIs more than doubled between .NET Standard 1.6 and 2.0.

The [`NETStandard.Library`](https://www.nuget.org/packages/NETStandard.Library/) metapackage references the complete set of NuGet packages that define .NET Standard.  The most common way to target `netstandard` is by referencing this metapackage. It describes and provides access to the ~40 .NET libraries and associated APIs that define .NET Standard. You can reference additional packages that target `netstandard` to get access to additional APIs.

### Versioning

The specification is not singular, but a linearly versioned set of APIs. The first version of the standard establishes a baseline set of APIs. Subsequent versions add APIs and inherit APIs defined by previous versions. There is no established provision for removing APIs from the Standard.

.NET Standard is not specific to any one .NET implementation, nor does it match the versioning scheme of any of those implementations.

As noted earlier, there will be no new .NET Standard versions after 2.1.

## Target .NET Standard

You can [build .NET Standard Libraries](../core/tutorials/libraries.md) using a combination of the `netstandard` framework and the `NETStandard.Library` metapackage.

## .NET Framework compatibility mode

Starting with .NET Standard 2.0, the .NET Framework compatibility mode was introduced. This compatibility mode allows .NET Standard projects to reference .NET Framework libraries as if they were compiled for .NET Standard. Referencing .NET Framework libraries doesn't work for all projects, such as libraries that use Windows Presentation Foundation (WPF) APIs.

For more information, see [.NET Framework compatibility mode](../core/porting/third-party-deps.md#net-framework-compatibility-mode).

## .NET Standard libraries and Visual Studio

In order to build .NET Standard libraries in Visual Studio, make sure you have [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022), [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019), or Visual Studio 2017 version 15.3 or later installed on Windows, or [Visual Studio for Mac version 7.1](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link) or later installed on macOS.

If you only need to consume .NET Standard 2.0 libraries in your projects, you can also do that in Visual Studio 2015. However, you need NuGet client 3.6 or higher installed. You can download the NuGet client for Visual Studio 2015 from the [NuGet downloads](https://www.nuget.org/downloads) page.

## .NET 5+ and .NET Standard

.NET 5 and .NET 6 are single products with a uniform set of capabilities and APIs that can be used for Windows desktop apps and cross-platform console apps, cloud services, and websites. The .NET 5 [TFMs](frameworks.md) reflect this broad range of scenarios:

* `net5.0`

  This TFM is for code that runs everywhere. With a few exceptions, it includes only technologies that work cross-platform. For .NET 5 code, `net5.0` replaces both `netcoreapp` and `netstandard` TFMs.

* `net5.0-windows`

  This is an example of an [OS-specific TFM](frameworks.md#net-5-os-specific-tfms) that add OS-specific functionality to everything that `net5.0` refers to.

### When to target net5.0 or net6.0 vs. netstandard

For existing code that targets `netstandard`, there's no need to change the TFM to `net5.0` or `net6.0`. .NET 5 and .NET 6 implement .NET Standard 2.1 and earlier. The only reason to retarget from .NET Standard to .NET 5+ would be to gain access to more runtime features, language features, or APIs. For example, in order to use C# 9, you need to target .NET 5 or a later version. You can multitarget .NET 5 or .NET 6 and .NET Standard to get access to newer features and still have your library available to other .NET implementations.

Here are some guidelines for new code for .NET 5+:

* App components

  If you're using libraries to break down an application into several components, we recommend you target `net5.0` or `net6.0`. For simplicity, it's best to keep all projects that make up your application on the same version of .NET. Then you can assume the same BCL features everywhere.

* Reusable libraries

  If you're building reusable libraries that you plan to ship on NuGet, consider the trade-off between reach and available feature set. .NET Standard 2.0 is the latest version that's supported by .NET Framework, so it gives good reach with a fairly large feature set. We don't recommend targeting .NET Standard 1.x, as you'd limit the available feature set for a minimal increase in reach.

  If you don't need to support .NET Framework, you could go with .NET Standard 2.1 or .NET 5/6. We recommend you skip .NET Standard 2.1 and go straight to .NET 6. Most widely used libraries will multi-target for both .NET Standard 2.0 and .NET 5+. Supporting .NET Standard 2.0 gives you the most reach, while supporting .NET 5+ ensures you can leverage the latest platform features for customers that are already on .NET 5+.

### .NET Standard problems

Here are some problems with .NET Standard that help explain why .NET 5 and later versions are the better way to share code across platforms and workloads:

- Slowness to add new APIs

  .NET Standard was created as an API set that all .NET implementations would have to support, so there was a review process for proposals to add new APIs. The goal was to standardize only APIs that could be implemented in all current and future .NET platforms. The result was that if a feature missed a particular release, you might have to wait for a couple of years before it got added to a version of the Standard. Then you'd wait even longer for the new version of .NET Standard to be widely supported.

  **Solution in .NET 5+:** When a feature is implemented, it's already available for every .NET 5+ app and library because the code base is shared. And since there's no difference between the API specification and its implementation, you're able to take advantage of new features much quicker than with .NET Standard.

- Complex versioning

  The separation of the API specification from its implementations results in complex mapping between API specification versions and implementation versions. This complexity is evident in the table shown earlier in this article and the instructions for how to interpret it.

  **Solution in .NET 5+:** There's no separation between a .NET 5+ API specification and its implementation. The result is a simplified TFM scheme. There's one TFM prefix for all workloads: `net5.0` or `net6.0` is used for libraries, console apps, and web apps. The only variation is a [suffix that specifies platform-specific APIs](frameworks.md#net-5-os-specific-tfms) for a particular platform, such as `net5.0-windows` or `net6.0-windows`. Thanks to this TFM naming convention, you can easily tell whether a given app can use a given library. No version number equivalents table, like the one for .NET Standard, is needed.

- Platform-unsupported exceptions at run time

  .NET Standard exposes platform-specific APIs. Your code might compile without errors and appear to be portable to any platform even if it isn't portable. When it runs on a platform that doesn't have an implementation for a given API, you get run-time errors.

  **Solution in .NET 5+:** The .NET 5+ SDKs include code analyzers that are enabled by default. The platform compatibility analyzer detects unintentional use of APIs that aren't supported on the platforms you intend to run on. For more information, see [Platform compatibility analyzer](analyzers/platform-compat-analyzer.md).

### .NET Standard not deprecated

.NET Standard is still needed for libraries that can be used by multiple .NET implementations. We recommend you target .NET Standard in the following scenarios:

* Use `netstandard2.0` to share code between .NET Framework and all other implementations of .NET.
* Use `netstandard2.1` to share code between Mono, Xamarin, and .NET Core 3.x.

## See also

- [.NET Standard versions (source)](https://github.com/dotnet/standard/blob/master/docs/versions.md)
- [.NET Standard versions (interactive UI)](https://dotnet.microsoft.com/platform/dotnet-standard#versions)
- [Build a .NET Standard library](../core/tutorials/library-with-visual-studio.md)
- [Cross-platform targeting](./library-guidance/cross-platform-targeting.md)
