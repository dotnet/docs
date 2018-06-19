
### Shipping a patch release

After shipping a major release of .NET Core, such as version 2.0.0, patch-level changes are made to .NET Core libraries to fix bugs and improve performance and reliability. That means that no new APIs are introduced. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates (`MAJOR.MINOR.PATCH`). Target frameworks are never updated as part of patch releases. A new .NET Core distribution is released with a version number that matches that of the `Microsoft.NETCore.App` metapackage.

### Shipping a minor release

After shipping a .NET Core version with an incremented `MAJOR` version number, new APIs are added to .NET Core libraries to enable new scenarios. The various metapackages are updated to reference the updated .NET Core library packages. The metapackages are versioned as patch updates with `MAJOR` and `MINOR` version numbers matching the new framework version. New target framework names with the new `MAJOR.MINOR` version are added to describe the new APIs (for example, `netcoreapp2.1`). A new .NET Core distribution is released with a matching version number to the `Microsoft.NETCore.App` metapackage.

### Shipping a major release

Every time a new major version of .NET Core ships, the `MAJOR` version number gets incremented, and the `MINOR` version number gets reset to zero. The new major version contains at least all the APIs that were added by minor releases after the previous major version. A new major version should enable important new scenarios, and it may also drop support for an older platform.

The various metapackages are updated to reference the updated .NET Core library packages. The [`Microsoft.NETCore.App`](https://www.nuget.org/packages/Microsoft.NETCore.App) metapackage and the `netcore` target framework are versioned as a major update matching the `MAJOR` version number of the new release.
