#### Minimum package set

* `dotnet-runtime-[major].[minor]`: a runtime with the specified version (only the latest patch version for a given major+minor combination should be available in the package manager). New patch versions update the package, but new minor or major versions are separate packages.

  **Dependencies**: `dotnet-host`

* `dotnet-sdk`: the latest SDK. `update` rolls forward major, minor, and patch versions.

  **Dependencies**: the latest `dotnet-sdk-[major].[minor]`.

* `dotnet-sdk-[major].[minor]`: the SDK with the specified version. The version specified is the highest included version of included shared frameworks, so that users can easily relate an SDK to a shared framework. New patch versions update the package, but new minor or major versions are separate packages.

  **Dependencies**: `dotnet-host`, one or more `dotnet-runtime-[major].[minor]` (one of those is used by the SDK code itself, the others are here for users to build and run against).

* `dotnet-host`: the latest host.

##### Preview versions

Package maintainers may decide to include preview versions of the runtime and SDK. Don't include those preview versions in the unversioned `dotnet-sdk` package, but you can release them as versioned packages with an additional preview marker appended to the major and minor version sections of the name. For example, there may be a `dotnet-sdk-2.0-preview1-final` package.
