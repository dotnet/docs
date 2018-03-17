---
title: .NET Standard
description: Learn about .NET Standard, its versions and the .NET implementations that support it.
keywords: .NET Standard, PCL, .NET
author: mairaw
ms.author: mairaw
ms.date: 08/13/2017
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c044882c-af15-45f2-96d1-534557a5ee9b
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# .NET Standard

The [.NET Standard](https://github.com/dotnet/standard) is a formal specification of .NET APIs that are intended to be available on all .NET implementations. The motivation behind the .NET Standard is establishing greater uniformity in the .NET ecosystem. [ECMA 335](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) continues to establish uniformity for .NET implementation behavior, but there is no similar spec for the .NET Base Class Libraries (BCL) for .NET library implementations. 

The .NET Standard enables the following key scenarios: 

- Defines uniform set of BCL APIs for all .NET implementations to implement, independent of workload.
- Enables developers to produce portable libraries that are usable across .NET implementations, using this same set of APIs.
- Reduces or even eliminates conditional compilation of shared source due to .NET APIs, only for OS APIs.

The various .NET implementations target specific versions of .NET Standard. Each .NET implementation version advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. For example, the .NET Framework 4.6 implements .NET Standard 1.3, which means that it exposes all APIs defined in .NET Standard versions 1.0 through 1.3. Similarly, the .NET Framework 4.6.1 implements .NET Standard 1.4, while .NET Core 1.0 implements .NET Standard 1.6.

## .NET implementation support

The following table lists all versions of .NET Standard and the platforms supported:

[!INCLUDE [net-standard-table](~/includes/net-standard-table.md)]

To find the highest version of .NET Standard that you can target, do the following:
1. Find the row that indicates the .NET implementation you want to run on.
2. Find the column in that row that indicates your version starting from right to left.
3. The column header indicates the .NET Standard version that your target supports (and any lower .NET Standard versions will also support it).
4. Repeat this process for each platform you want to target. If you have more than one target platform, you should pick the smaller version among them. For example, if you want to run on .NET Framework 4.5 and .NET Core 1.0, the highest .NET Standard version you can use is .NET Standard 1.1.

### Which .NET Standard version to target

When choosing a .NET Standard version, you should consider this trade-off:

- The higher the version, the more APIs are available to you.
- The lower the version, the more platforms implement it.

In general, we recommend you to target the *lowest* version of .NET Standard possible. So, after you find the highest .NET Standard version you can target, follow these steps:
1. Target the next lower version of .NET Standard and build your project.
2. If your project builds successfully, repeat step 1. Otherwise, retarget to the next higher version and that's the version you should use.

### .NET Standard versioning rules

There are two primary versioning rules:

- Additive: .NET Standard versions are logically concentric circles: higher versions incorporate all APIs from previous versions. There are no breaking changes between versions.
- Immutable. Once shipped, .NET Standard versions are frozen. New APIs will first become available in specific .NET implementations, such as .NET Core. If the .NET Standard review board believes the new APIs should be made available everywhere, they'll be added in a new .NET Standard version.

## Comparison to Portable Class Libraries

.NET Standard is the replacement for [Portable Class Libraries (PCL)](./cross-platform/cross-platform-development-with-the-portable-class-library.md). The .NET Standard improves on the experience of creating portable libraries by curating a standard BCL and establishing greater uniformity across .NET implementations as a result. A library that targets .NET Standard is a PCL or a ".NET Standard-based PCL". Existing PCLs are "profile-based PCLs".

.NET Standard and PCL profiles were created for similar purposes but also differ in key ways.

Similarities:

- Defines APIs that can be used for binary code sharing.

Differences:

- .NET Standard is a curated set of APIs, while PCL profiles are defined by intersections of existing platforms.
- .NET Standard linearly versions, while PCL profiles do not.
- PCL profiles represents Microsoft platforms while the .NET Standard is agnostic to platform.

## Specification

The .NET Standard specification is a standardized set of APIs. The specification is maintained by .NET implementors, specifically Microsoft (includes .NET Framework, .NET Core and Mono) and Unity. A public feedback process is used as part of establishing new .NET Standard versions through [GitHub](https://github.com/dotnet/standard).

### Official artifacts

The official specification is a set of .cs files that define the APIs that are part of the standard. The [ref directory](https://github.com/dotnet/standard/tree/master/netstandard/ref) in the [dotnet/standard repository](https://github.com/dotnet/standard) defines the .NET Standard APIs.

The [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) metapackage ([source](https://github.com/dotnet/standard/blob/master/netstandard/pkg/NETStandard.Library.dependencies.props)) describes the set of libraries that define (in part) one or more .NET Standard versions.

A given component, like System.Runtime, describes:

- Part of .NET Standard (just its scope).
- Multiple versions of .NET Standard, for that scope.

Derivative artifacts are provided to enable more convenient reading and to enable certain developer scenarios (for example, using a compiler).

- [API list in markdown](https://github.com/dotnet/standard/tree/master/docs/versions)
- Reference assemblies, distributed as [NuGet packages](../core/packages.md) and referenced by the [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/) metapackage.

### Package representation

The primary distribution vehicle for the .NET Standard reference assemblies is [NuGet packages](../core/packages.md). Implementations will be delivered in a variety of ways, appropriate for each .NET implementation.

NuGet packages target one or more [frameworks](frameworks.md). The .NET Standard packages target the ".NET Standard" framework. You can target the .NET Standard Framework using the `netstandard` [compact TFM](frameworks.md) (for example, `netstandard1.4`). Libraries that are intended to run on multiple runtimes should target this framework. 

The `NETStandard.Library` metapackage references the complete set of NuGet packages that define .NET Standard.  The most common way to target `netstandard` is by referencing this metapackage. It describes and provides access to the ~40 .NET libraries and associated APIs that define .NET Standard. You can reference additional packages that target `netstandard` to get access to additional APIs. 

### Versioning

The specification is not singular, but an incrementally growing and linearly versioned set of APIs. The first version of the standard establishes a baseline set of APIs. Subsequent versions add APIs and inherit APIs defined by previous versions. There is no established provision for removing APIs from the standard.

.NET Standard is not specific to any one .NET implementation, nor does it match the versioning scheme of any of those runtimes.

APIs added to any of the implementations (such as, .NET Framework, .NET Core and Mono) can be considered as candidates to add to the specification, particularly if they are thought to be fundamental in nature. New [versions of .NET Standard](https://github.com/dotnet/standard/blob/master/docs/versions.md) are created based on .NET implementation releases, enabling you to target new APIs from a .NET Standard PCL. The versioning mechanics are described in more detail in [.NET Core Versioning](../core/versions/index.md).

.NET Standard versioning is important for usage. Given a .NET Standard version, you can use libraries that target that same or lower version. The following approach describes the workflow for using .NET Standard PCLs, specific to .NET Standard targeting.

- Select a .NET Standard version to use for your PCL.
- Use libraries that depend on the same .NET Standard version or lower.
- If you find a library that depends on a higher .NET Standard version, you either need to adopt that same version or decide not to use that library.

### PCL compatibility

.NET Standard is compatible with a subset of PCL profiles. .NET Standard 1.0, 1.1 and 1.2 each overlap with a set of PCL profiles. This overlap was created for two reasons:

- Enable .NET Standard-based PCLs to reference profile-based PCLs.
- Enable profile-based PCLs to be packaged as .NET Standard-based PCLs.

Profile-based PCL compatibility is provided by the [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) NuGet package. This dependency is required when referencing NuGet packages that contain profile-based PCLs.

Profile-based PCLs packaged as `netstandard` are easier to consume than typically packaged profile-based PCLs. `netstandard` packaging is compatible with existing users.

You can see the set of PCL profiles that are compatible with the .NET Standard: 

| PCL Profile | .NET Standard | PCL Platforms
|:-----------:|:-------------:|------------------------------------------------------------------------------
| Profile7    | 1.1           | .NET Framework 4.5, Windows 8
| Profile31   | 1.0           | Windows 8.1, Windows Phone Silverlight 8.1
| Profile32   | 1.2           | Windows 8.1, Windows Phone 8.1
| Profile44   | 1.2           | .NET Framework 4.5.1, Windows 8.1
| Profile49   | 1.0           | .NET Framework 4.5, Windows Phone Silverlight 8
| Profile78   | 1.0           | .NET Framework 4.5, Windows 8, Windows Phone Silverlight 8
| Profile84   | 1.0           | Windows Phone 8.1, Windows Phone Silverlight 8.1
| Profile111  | 1.1           | .NET Framework 4.5, Windows 8, Windows Phone 8.1
| Profile151  | 1.2           | .NET Framework 4.5.1, Windows 8.1, Windows Phone 8.1
| Profile157  | 1.0           | Windows 8.1, Windows Phone 8.1, Windows Phone Silverlight 8.1
| Profile259  | 1.0           | .NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8


## Targeting .NET Standard

You can [build .NET Standard Libraries](../core/tutorials/libraries.md) using a combination of the `netstandard` framework and the NETStandard.Library metapackage. You can see examples of [targeting the .NET Standard with .NET Core tools](../core/packages.md).

## See also
[.NET Standard Versions](https://github.com/dotnet/standard/blob/master/docs/versions.md)
