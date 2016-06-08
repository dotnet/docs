.NET Standard Library
=====================

The .NET Standard Library is a formal specification of .NET APIs that are intended to be available on all .NET runtimes. The motivation behind the Standard Library is establishing greater uniformity in the .NET ecosystem. [ECMA 335](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) continues to establish uniformity for .NET runtime behavior, but there is no similar spec for the .NET Base Class Libraries (BCL) for .NET library implementations. 

The .NET Standard Library is a standardized BCL, enabling two key scenarios: 

- Provide a baseline set of BCL APIs on all .NET platforms, independent of workload.
- Enable developers to produce portable libraries that are usable across .NET runtimes, using this same set of APIs.

The second scenario is the same as PCL. .NET Standard Library can be thought of as the next generation of [Portable Class Libraries (PCL)](https://msdn.microsoft.com/library/gg597391.aspx). The .NET Standard Library improves on the experience of creating portable libraries by curating a standard BCL and establishing greater uniformity across .NET runtimes as a result. 

The spec is called "The .NET Standard Library". The more general ecosystem that builds on top of the spec is referred to as ".NET Standard" or coloquially as "NETStandard". A Library that targets the spec is called "a .NET Standard library (NSL)" or coloquially as "a NETStandard library" or as "an NSL" (analogue of "PCL").

Specification
=============

The .NET Standard Library spec is a standardized set of APIs. A given .NET runtime will implement and advertise support for a particular version of the .NET Standard Library. That runtime is then able to support source and binaries that target that and previous versions of the spec.

The spec is maintained by .NET runtime implementors, specifically Microsoft (includes .NET Framework, .NET Core and Mono) and Unity. A public feedback process is used as part of establishing new .NET Standard Library versions.

Official Artifacts
------------------

The official spec is a set of .cs files that define the APIs that are part of the standard. The [ref directory](https://github.com/dotnet/corefx/tree/master/src/System.Runtime/ref) for each [component](https://github.com/dotnet/corefx/tree/master/src) defines the .NET Standard Library APIs. While the ref artifacts reside in the [CoreFX repo](https://github.com/dotnet/corefx), they are not .NET Core specific.

The [NETStandard.Library](https://github.com/dotnet/corefx/blob/master/pkg/NETStandard.Library/NETStandard.Library.packages.targets) metapackage describes the set of libraries that define (in part) one or more .NET Standard Library versions.

Derivative artifacts are provided to enable more convenient reading and to enable certain developer scenarios (for example, using a compiler).

- API list in markdown (TBD)
- Reference assemblies, distributed as [NuGet packages](../core-concepts/packages.md) and referenced by the [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library/) metapackage.

Package Representation
----------------------

The primary distribution vehicle for the .NET Standard Library reference assemblies is [NuGet packages](../core-concepts/packages.md). Implementations will be delivered in a variety of ways, appropriate for each .NET runtime.

NuGet packages target one of more frameworks. The .NET Standard Library packages target the ".NET Standard" framework, which is represented by the the `netstandard` Target Framework Moniker (TFM). The framework is ".NET Standard" instead of ".NET Standard Library", since ".NET Standard" includes both the .NET Standard Library packages and the larger ecosystem of libraries that are built on top of it. Libraries that are intended to run on multiple runtimes should use this target. 

The `NETStandard.Library` metapackage references the complete set of NuGet packages that define the .NET Standard Library.  The most common way to target `netstandard` is by referencing this metapackage. It describes and provides access to the ~40 .NET  libraries and associated APIs that define the .NET Standard Library. You can reference additional packages that target `netstandard` to get access to additional APIs. 

The `NETStandard.Library` metapackage doesn't define a framework of its own, but exposes the set of frameworks defined by the packages it references, including `netstandard`. Similarly, the `netstandard` framework does not expose any APIs on its own, but relies on packages that expose `netstandard` assets to define the framework. The definition of the `netstandard` framework is not limited to the .NET Standard Library.

Note: `netstandard` isn't actually a framework, but a prototype for one. It is used as a short-hand. For example, `netstandard1.2' is an actual framework.

Versioning
----------

The spec is not singular, but an incrementally growing and linearly versioned set of APIs. The first version of the standard establishes a baseline set of APIs. Subsequent versions add APIs and inherit APIs defined by previous versions. There is no established provision for removing APIs from the standard.

The .NET Standard Library is not specific to any one .NET runtime, nor does it match the versioning scheme of any of those runtimes.

APIs added to any of the runtimes (such as, .NET Framework, .NET Core and Mono) can be considered as candidates to add to the specification. New [versions of the .NET Standard Library](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#list-of-net-corefx-apis-and-their-associated-net-platform-standard-version) are created for one of two reasons:

- APIs are added to a .NET runtime (for example, .NET Core) that are considered fundamental. They are added to the .NET Standard Library, requiring other .NET runtimes to implement these new APIs in order to satisfy the new standard version.
- APIs are implemented across a set of .NET runtimes (for example, .NET Framework, .NET Core and Mono) at the same time, making the APIs candidates for the standard.

PCL Compatibility
-----------------

The .NET Standard Library is compatible with a subset of PCL profiles. .NET Standard Library 1.0, 1.1 and 1.2 each overlap with a set of PCL profiles. This overlap was created for two reasons:

- Enable NSLs to reference PCLs.
- Enable PCLs to be packaged as NSLs.

PCL compatibility is provided by the [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) NuGet package. This dependency is required when referencing NuGet packages that contain PCLs.

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

.NET Platforms Support
======================

The various .NET runtimes implement specific versions of the .NET Standard Libary. Each .NET runtime version advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. For example, the .NET Framework 4.6 implements the .NET Standard Library 1.3, which means that it exposes all APIs defined in .NET Standard Library versions 1.0 through 1.3. Similarly, the .NET Framework 4.6.2 implements .NET Standard Library 1.5, while .NET Core 1.0 implements the .NET Standard Library 1.6.

You can see the complete set of .NET runtimes that support the .NET Standard Library.

| Target Platform Name | Alias |  |  |  |  |  | | |
| :---------- | :--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |
|.NET Platform Standard | netstandard | 1.0 | 1.1 | 1.2 | 1.3 | 1.4 | 1.5 | 1.6 |
|.NET Core|netcoreapp|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|1.0|
|.NET Framework|net|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|4.6.3|
|||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|4.6.2|
|||&rarr;|&rarr;|&rarr;|&rarr;|4.6.1|||
|||&rarr;|&rarr;|&rarr;|4.6||||
|||&rarr;|&rarr;|4.5.2|||||
|||&rarr;|&rarr;|4.5.1|||||
|||&rarr;|4.5||||||
|Universal Windows Platform|uap|&rarr;|&rarr;|&rarr;|&rarr;|10.0|||
|Windows|win|&rarr;|&rarr;|8.1|||||
|||&rarr;|8.0||||||
|Windows Phone|wpa|&rarr;|&rarr;|8.1|||||
|Windows Phone Silverlight|wp|8.1|||||||
|||8.0|||||||
|Mono/Xamarin Platforms||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|*|
|Mono||&rarr;|&rarr;|*||||||

Comparison to Portable Class Libraries
======================================

The .NET Standard Library and PCLs were created for similar purposes but also differ in key ways.

Similarities:

- Defines APIs that can be used for binary code sharing.

Differences:

- The .NET Standard Library is a curated set of APIs, while PCL is defined by intersections of existing platforms.
- The .NET Standard Library and .NET Standard linearly version, while PCL is defined as a disjoint set of profiles.
- PCL represents Microsoft platforms while the .NET Standard Library is agnostic to platform.

Targeting .NET Standard Library
===============================

You can [build .NET Standard Libraries](../core-concepts/libraries/libraries-with-cli.md) using a combination of the `netstandard` framework and the NETStandard.Library metapackage. You can see examples of [targeting the .NET Standard Library with .NET Core tools](../core-concepts/packages.md).
