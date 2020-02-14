
Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019, and distributed with Developer ID, must be notarized. This requirement applies to the .NET Core runtime, .NET Core SDK, and software created with .NET Core.

The installers for .NET Core (both runtime and SDK) versions 3.1, 3.0, and 2.1, have been notarized by Apple since February 19, 2020. Prior released versions aren't notarized. If you run a non-notarized app, you'll see an error similar to the following image:

![macOS Catalina notarization alert](media/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET Core (and your .NET Core apps), see [Working with macOS Catalina Notarization](../macos-notarization-issues.md).
