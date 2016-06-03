.NET Standard Library
=====================

The .NET Standard Library is a formal specification of .NET APIs that are intended to be available on all .NET runtimes. The motivation behind the Standard Library is establishing greater uniformity in the .NET ecosystem. [ECMA 335](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) continues to establish uniformity for .NET runtime behavior, but there is no similar spec for the .NET Base Class Libraries (BCL) for .NET library implementations. The .NET Standard Library is a standardized BCL, enabling developers to produce libraries that are usable across .NET app models and supported operating systems while having access to all the APIs they expect to use. 

Developers use the .NET Standard Library in order to build libraries that are portable across .NET runtimes and operating systems. It can be thought of as the next generation of Portable Class Libraries (PCL). 

The spec is called "The .NET Standard Library" or can be referred to as ".NET Standard" as a short form. A Library that targets the spec can be called "a .NET Standard Library" or an NSL, similar to PCL.

Specification
=============

The .NET Standard Library spec is a standardized set of APIs, contained and described by packages. The spec is not singular, but an incrementally growing and linearly versioned set of APIs. The first version of the standard establishes a baseline of APIs. Subsequent versions add APIs. There is no established provision for removing APIs from the standard.

The spec is maintained by .NET runtime implementors, specifically Microsoft (includes .NET Framework, .NET Core and Mono) and Unity. A public feedback process is used as part of establishing new .NET Standard Library versions.

Official Artifacts
------------------

The official spec is a set of .cs files that describe the shape of the standard. Additional derivative artifacts are provided to enable more convenient reading and to enable certain developer scenarios (for example, using a compiler).

- [.cs files](https://github.com/dotnet/corefx/tree/master/src)
- Reference assemblies (currently only distributed by NuGet)
- [NuGet packages](https://www.nuget.org/packages/NETStandard.Library)
- Markdown API list (TBD)

Compatibility
-------------

The .NET Standard Library is compatible with various existing API specs, specifically various PCL profiles. PCL compatibility enables .NET Standard Libraries to reference PCL libraries.

You can see the set of [PCL profiles that are compatible with the .NET Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#portable-profiles), per version.

The PCL compatibility layer is defined:

- [NuGet packages](https://www.nuget.org/packages/Microsoft.NETCore.Compatibility)
- Other places?

Standard Versions
-----------------

The .NET Standard is not specific to any one .NET runtime, nor does it match the versioning scheme of any of those runtimes. APIs added to any of the runtimes (such as, Mono, .NET Framework, and .NET Core) can be considered as candidates to add to the specification. New [versions of the .NET Standard Library](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#list-of-net-corefx-apis-and-their-associated-net-platform-standard-version) are created for one of two reasons:

- One or more new APIs are added to a .NET runtime (for example, .NET Core) that are considered fundamental. Other .NET runtimes are required to implement this new API in order to satisfy the new standard version.
- One or more APIs are deterimed to be implemented across a quorum of .NET runtimes (for example, .NET Framework, .NET Core and Mono), making these APIs candidates for the standard.

Each standard version defines a set of APIs and inherits the APIs defined by previous versions. Some versions add a large set of APIs and others very few. This is in large part because of the reasons listed above, on the reasons why APIs get added to the standard.

The .NET Standard Library was published as multiple versions at its inception (versions 1.0 through 1.5). The creation of multiple versions enabled .NET Standard and PCLs to overlap. This overlap was created for two reasons:

- Enable NSLs to reference PCLs.
- Enable PCLs to be packaged as NSLs.

Informative Specification
-------------------------

The standard defines the APIs that are available, per version. The set of APIs is the normative content of the spec. There is other important related information that is informative, extrinsic to the spec. Key informative information:

- [.NET platforms support](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#mapping-the-net-platform-standard-to-platforms) per .NET Standard Library version.

Targeting .NET Standard Library
===============================




The standard is specified by a set of [NuGet packages](../core-concepts/packages.md). You can compile libraries with these same NuGet packages in order to build libraries that are portable, across .NET Standard compliant runtimes.

It can be thought of as the next generation of [Portable Class Libraries](https://msdn.microsoft.com/library/gg597391.aspx), although is architecturally different. You can learn more 


The Target Framework Moniker (TFM) for .NET Standard is `netstandard`. At the release of .NET Core 1.0, there will be several `netstandard` versions, not just a 1.0 version. There was a strong desire to create a bridge between Portable Class Libraries (PCL) and .NET Standard.  To establish the compatibility bridge, .NET Standard was pre-versioned to overlap with existing .NET platforms in a compatible way with PCL. .NET Standard versions 1.0 through 1.4 represent the overlap. The .NET Core 1.0 platform implements all .NET Standard versions up to and including 1.5.




- **The ".NET Standard Library"** - This is the API spec that describes the API evolution of .NET and that .NET Core implements. While many of the additions to the Standard Library will come from API additions to .NET Core, some will come from other platforms, such as the .NET Framework and Mono.
- **System.* packages** - These packages provide the ".NET Core" implementation but contain assets for other platforms, such as the .NET Framework and Mono.


### netstandard

.NET Standard is a new concept that came out of the .NET Core project, but is logically separate. It is a a new framework that describes the API evolution of .NET for the lower-most APIs. One could consider it a standardized Base Class Library (BCL) for all .NET implementations. .NET Core implements this spec and is ".NET Standard compliant" at a particular version level. The .NET Standard will be updated regularly, based on new APIs being adding in .NET Standard compliant .NET implementations, such as .NET Core, .NET Framework and Mono. The version number of .NET Standard will not match any of the implementations.

The Target Framework Moniker (TFM) for .NET Standard is `netstandard`. At the release of .NET Core 1.0, there will be several `netstandard` versions, not just a 1.0 version. There was a strong desire to create a bridge between Portable Class Libraries (PCL) and .NET Standard.  To establish the compatibility bridge, .NET Standard was pre-versioned to overlap with existing .NET platforms in a compatible way with PCL. .NET Standard versions 1.0 through 1.4 represent the overlap. The .NET Core 1.0 platform implements all .NET Standard versions up to and including 1.5.

PCL and .NET Standard both enable binary sharing but define the applicable APIs in different ways. .NET Standard is the new binary code sharing mechanism going forward.




.NET Core and .NET Standard Versioning
======================================

The .NET Standard will not adopt the version numbers of .NET Core. They are logically separate. There are three major scenarios to consider.

The following sections discuss API additions. It assumes that the additions are to libraries that are referenced by `NETStandard.Library` metapackage.

Adding APIs to .NET Core
------------------------

When APIs are added to .NET Core, they will typicall be added .NET Standard. Both .NET Core and .NET Standard will version. The APIs might be added to other .NET implementations at the same time, such as the .NET Framework. 

Adding APIs to another .NET Implementation
------------------------------------------

When APIs are added to the .NET Framework (for example), but not .NET Core, the .NET Standard will version, but .NET Core will not.

The next time .NET Core ships, it will likely add those new APIs such that it now supports that higher .NET Standard version. It can also add additional APIs at the same time, which could create a new .NET Standard version.

.NET Core ships a Major Version
-------------------------------

When .NET Core ships a 2.0 version, the .NET Standard will be updated (assuming new APIs were added), but will stay with is 1.x versioning scheme. 

We intend to move to a 2.0 version of .NET Standard only for very significant changes. We have defined a non-exhaustive set of cases where we would move to `netstandard2.0`, none of which we intend to do:

- Drop APIs.
- Add a major new feature that is potentially breaking for existing runtimes (for example, array slices).
- Update the CLR metadata/assembly format.


Everytime there is a new major or minor release of the NetStandard.Library meta-package, there will be a subset of the underlying packages that include a new netstandard folder. That's the change that creates the new netstandard versions. Packages that don't expose new APIs will not include these new folders, unless they take an implementation dependency on a new package that does add new APIs.

In most cases, higher-level packages, from Microsoft or 3rd parties, will not need to support multiple netstandard versions, but will target the lowest netstandard version that satisfies their API dependency and platform breadth needs. If you need to get access to newer APIs in later netstandard versions but want to maintain their platform support, you can target multiple netstandard versions, but can continue to offer the same API (where possible) for developers to consume. Many existing NuGet packages already do this, across net20, net46 and PCL, for example.

Most .NET Core packages will use the new ".NET Standard" (netstandard) framework, which is intended to be supported on all modern .NET platforms. They may also support other frameworks.

Target Frameworks
-----------------




Other .NET platforms could support this framework, but are not expected to.


The [NETStandard.Library version](versioning.md) matches the highest `netstandard` version it supports. The framework reference in project.json is used to select the correct assets from the underlying packages. In this case, `netstandard1.5` assets are required, as opposed to `netstandard1.4` or `net46`, for example. The framework and metapackage references in project.json do not need to match. For example, the following project.json is also valid.

```json
{
  "dependencies": {
    "NETStandard.Library": "1.5.0"
  },
  "frameworks": {
    "netstandard1.3": {}
  }
}
```

It may seem strange to target `netstandard1.3` but use the 1.5.0 version of `NETStandard.Library`. It is a valid use-case, since the metapackage maintains support for older `netstandard` versions. It could be the case you've standardized on the 1.5.0 version of the metapackage and use it for all your libraries, which target a variety of `netstandard` versions. With this approach, you only need to restore `NETStandard.Library` 1.5.0 and not earlier versions. The reverse would not be valid. You cannot use `netstandard1.5` assets with the 1.3.0 version of NETStandard.Library. 
