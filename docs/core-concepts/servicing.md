# .NET Core Servicing
.NET Core is made up of a number of different components.

1. .NET Runtime Host
 - Distributed as a NuGet package.
2. .NET Core Shared framework
 - Contains the .NET Core host, runtime, and framework.
 - Composition of NuGet packages resolved for the specific OS platform.
 - Distributed in platforms specific installers, and zips/tar-balls.
3. .NET Core SDK
 - Contains the shared framework package and the dotnet CLI.
 - Distributed in platforms specific installers, and zips/tar-balls.
4. Other NuGet packages
 - Distributed as NuGet packages

## Major releases
Major releases are broad releases including all components of .NET Core.  Major releases include new functionality, API, and bugfixes.  These releases will be represented by either an incremented major or minor version, EG: 1.0 > 1.1 or 1.0 > 2.0.
Major releases are independently targetable and will be shipped as an in-place update to the .NET Core SDK and a new side-by-side version of the .NET Core shared framework.
These can be aqcuired in a *pull* fashion by downloading a platform specific installer or zip/tar-ball.  The SDK will also be published to the VS Extensions gallery and appear as an update to Visual Studio.  New versions of NuGet packages will also be published to NuGet.org and will be backwards compatible with existing platforms.  Sometimes new packages may require new versions of the NuGet client (as is the case for .NET Core 1.0).

## Hotfixes
Hotfixes are small releases to individual components of .NET Core.  These updates address issues like reliability, performance, or missing functionality.  These will be published as packages to NuGet.org.  Applications can depend on an updated package, even if it is part of the shared framework, and the referenced package will take precedence.
These updates will occuasionally be rolled-up into new installers/zips of the shared framework and SDK.  Updates to the SDK are in-place, whereas the shared-framework are side-by-side (TODO: Lee/Senthil please confirm).


## Security updates
Security updates are small precision fixes to individual components to fix security issues.  These updates are delivered as new packages on NuGet.org, new installers, and new zips/tar-balls of the shared framework and SDK (TODO: Lee please confirm).  These can be acquired in a *pull* fashion by downloading and installing the updated components.  These installers will behave as in-place updates.
On Windows packages will also be published to Microsoft Update to push updated binaries to all affected machines.  These binaries will take precedence over the binaries in the shared framework and .NET Core application by default.  Applications can opt out of this behavior if they happen to be broken by an update.
