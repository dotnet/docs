.NET Standard Library
=====================

It can be thought of as the next generation of [Portable Class Libraries](https://msdn.microsoft.com/library/gg597391.aspx), although is architecturally different. You can learn more 

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