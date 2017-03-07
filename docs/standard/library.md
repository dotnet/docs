---
title: .NET Standard Library
description: .NET Standard Library
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c044882c-af15-45f2-96d1-534557a5ee9b
---

# .NET Standard Library

The .NET Standard Library is a formal specification of .NET APIs that are intended to be available on all .NET runtimes. The motivation behind the Standard Library is establishing greater uniformity in the .NET ecosystem. [ECMA 335](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) continues to establish uniformity for .NET runtime behavior, but there is no similar spec for the .NET Base Class Libraries (BCL) for .NET library implementations. 

The .NET Standard Library enables the following key scenarios: 

- Defines uniform set of BCL APIs for all .NET platforms to implement, independent of workload.
- Enables developers to produce portable libraries that are usable across .NET runtimes, using this same set of APIs.
- Reduces and hopefully eliminates conditional compilation of shared source due to .NET APIs, only for OS APIs.

The various .NET runtimes implement specific versions of the .NET Standard Library. Each .NET runtime version advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. For example, the .NET Framework 4.6 implements the .NET Standard Library 1.3, which means that it exposes all APIs defined in .NET Standard Library versions 1.0 through 1.3. Similarly, the .NET Framework 4.6.2 implements .NET Standard Library 1.5, while .NET Core 1.0 implements the .NET Standard Library 1.6.

## .NET Platforms Support

You can see the complete set of .NET runtimes that support the .NET Standard Library.

| Platform Name | Alias |  |  |  |  |  | | | |
| :---------- | :--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |
|.NET Standard | netstandard | 1.0 | 1.1 | 1.2 | 1.3 | 1.4 | 1.5 | 1.6 | 2.0 |
|.NET Core|netcoreapp|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|1.0|2.0|
|.NET Framework|net|&rarr;|4.5|4.5.1|4.6|4.6.1|4.6.2|vNext|4.6.1|
|Mono/Xamarin Platforms||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|vNext|
|Universal Windows Platform|uap|&rarr;|&rarr;|&rarr;|&rarr;|10.0|&rarr;|&rarr;|vNext|
|Windows|win|&rarr;|8.0|8.1||||||
|Windows Phone|wpa|&rarr;|&rarr;|8.1||||||
|Windows Phone Silverlight|wp|8.0||||||||

## Comparison to Portable Class Libraries

.NET Standard Library can be thought of as the next generation of [Portable Class Libraries (PCL)](https://msdn.microsoft.com/library/gg597391.aspx). The .NET Standard Library improves on the experience of creating portable libraries by curating a standard BCL and establishing greater uniformity across .NET runtimes as a result. A library that targets the .NET Standard Library is a PCL or a ".NET Standard-based PCL". Existing PCLs are "profile-based PCLs".

The .NET Standard Library and PCL profiles were created for similar purposes but also differ in key ways.

Similarities:

- Defines APIs that can be used for binary code sharing.

Differences:

- The .NET Standard Library is a curated set of APIs, while PCL profiles are defined by intersections of existing platforms.
- The .NET Standard Library linearly versions, while PCL profiles do not.
- PCL profiles represents Microsoft platforms while the .NET Standard Library is agnostic to platform.

## Specification

The .NET Standard Library spec is a standardized set of APIs. The spec is maintained by .NET runtime implementors, specifically Microsoft (includes .NET Framework, .NET Core and Mono) and Unity. A public feedback process is used as part of establishing new .NET Standard Library versions.

### Official Artifacts

The official spec is a set of .cs files that define the APIs that are part of the standard. The [ref directory](https://github.com/dotnet/corefx/tree/master/src/System.Runtime/ref) for each [component](https://github.com/dotnet/corefx/tree/master/src) defines the .NET Standard Library APIs. While the ref artifacts reside in the [CoreFX repo](https://github.com/dotnet/corefx), they are not .NET Core specific.

The [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) metapackage ([source](https://github.com/dotnet/corefx/blob/master/pkg/NETStandard.Library/NETStandard.Library.packages.targets)) describes the set of libraries that define (in part) one or more .NET Standard Library versions.

A given component, like System.Runtime, describes:

- Part of .NET Standard Library (just its scope).
- Multiple versions of .NET Standard Library, for that scope.

Derivative artifacts are provided to enable more convenient reading and to enable certain developer scenarios (for example, using a compiler).

- API list in markdown (TBD)
- Reference assemblies, distributed as [NuGet packages](../core/packages.md) and referenced by the [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/) metapackage.

### Package Representation

The primary distribution vehicle for the .NET Standard Library reference assemblies is [NuGet packages](../core/packages.md). Implementations will be delivered in a variety of ways, appropriate for each .NET runtime.

NuGet packages target one or more [frameworks](frameworks.md). The .NET Standard Library packages target the ".NET Standard" framework. You can target the .NET Standard Framework using the `netstandard` [compact TFM](frameworks.md) (for example, `netstandard1.4`). Libraries that are intended to run on multiple runtimes should target this framework. 

The `NETStandard.Library` metapackage references the complete set of NuGet packages that define the .NET Standard Library.  The most common way to target `netstandard` is by referencing this metapackage. It describes and provides access to the ~40 .NET  libraries and associated APIs that define the .NET Standard Library. You can reference additional packages that target `netstandard` to get access to additional APIs. 

### Versioning

The spec is not singular, but an incrementally growing and linearly versioned set of APIs. The first version of the standard establishes a baseline set of APIs. Subsequent versions add APIs and inherit APIs defined by previous versions. There is no established provision for removing APIs from the standard.

The .NET Standard Library is not specific to any one .NET runtime, nor does it match the versioning scheme of any of those runtimes.

APIs added to any of the runtimes (such as, .NET Framework, .NET Core and Mono) can be considered as candidates to add to the specification, particularly if they are thought to be fundamental in nature. New [versions of the .NET Standard Library](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#list-of-net-corefx-apis-and-their-associated-net-platform-standard-version) are created based on .NET runtime releases, enabling you to target new APIs from a .NET Standard PCL. The versioning mechanics are described in more detail in [.NET Core Versioning](../core/versions/index.md).

.NET Standard Library versioning is important for usage. Given a .NET Standard Library version, you can use libraries that target that same or lower version. The following approach describes the workflow for using .NET Standard Library PCLs, specific to .NET Standard Library targeting.

- Select a .NET Standard Library version to use for your PCL.
- Use libraries that depend on the same .NET Standard Library version or lower.
- If you find a library that depends on a higher .NET Standard Library version, you either need to adopt that same version or decide not to use that library.

### PCL Compatibility

The .NET Standard Library is compatible with a subset of PCL profiles. .NET Standard Library 1.0, 1.1 and 1.2 each overlap with a set of PCL profiles. This overlap was created for two reasons:

- Enable .NET Standard-based PCLs to reference profile-based PCLs.
- Enable profile-based PCLs to be packaged as .NET Standard-based PCLs.

Profile-based PCL compatibility is provided by the [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) NuGet package. This dependency is required when referencing NuGet packages that contain profile-based PCLs.

Profile-based PCLs packaged as `netstandard` are easier to consume than typically packaged profile-based PCLs. `netstandard` packaging is compatible with existing users.

You can see the set of PCL profiles that are compatible with the .NET Standard: 

| Profile | .NET Platform Standard version |
| ---------| --------------- |
| Profile7  .NET Portable Subset (.NET Framework 4.5, Windows 8) | 1.1 |
| Profile31 .NET Portable Subset (Windows 8.1, Windows Phone Silverlight 8.1)| 1.0 |
| Profile32 .NET Portable Subset (Windows 8.1, Windows Phone 8.1) | 1.2 |
| Profile44 .NET Portable Subset (.NET Framework 4.5.1, Windows 8.1) | 1.2 |
| Profile49 .NET Portable Subset (.NET Framework 4.5, Windows Phone Silverlight 8) | 1.0 |
| Profile78 .NET Portable Subset (.NET Framework 4.5, Windows 8, Windows Phone Silverlight 8) | 1.0 |
| Profile84 .NET Portable Subset (Windows Phone 8.1, Windows Phone Silverlight 8.1) | 1.0 |
| Profile111 .NET Portable Subset (.NET Framework 4.5, Windows 8, Windows Phone 8.1) | 1.1 |
| Profile151 .NET Portable Subset (.NET Framework 4.5.1, Windows 8.1, Windows Phone 8.1) | 1.2 |
| Profile157 .NET Portable Subset (Windows 8.1, Windows Phone 8.1, Windows Phone Silverlight 8.1) | 1.0 |
| Profile259 .NET Portable Subset (.NET Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8) | 1.0 |

## Targeting .NET Standard Library

You can [build .NET Standard Libraries](../core/tutorials/libraries.md) using a combination of the `netstandard` framework and the NETStandard.Library metapackage. You can see examples of [targeting the .NET Standard Library with .NET Core tools](../core/packages.md).
