# Launching .NET Apps

This document covers recommendations for launching .NET applications. There are two main form factors for .NET app deployment:

* Self-contained
* Framework-dependent

Self-contained apps are the simplest. They have a platform-native entry executable and contain all files needed for their execution. They match the native platform standard for launching executables. They do not support configuration beyond the native platform convention.

Framework-dependent apps do not contain a runtime themselves and instead need a separate runtime located somewhere on the machine. This is the most complicated scenario with the most configuration options.

## Framework-dependent apps

There are two ways to run framework-dependent apps: through the "apphost" launcher and via `dotnet app.dll`. Whenever possible, it's recommended to use the apphost. There are a number of advantages to using the apphost:

* Executables appear like standard native platform executables.
* Executable names are preserved in the process names, meaning apps can be easily recognized based on their names.
* Because the apphost is a native binary, native assets like manifests can be attached to them.
* Apphost has available [low-level security mitigations](https://github.com/dotnet/designs/blob/main/accepted/2021/runtime-security-mitigations.md) applied by default that makes it more secure. Mitigations applied to `dotnet` are the lowest common denominator of all supported runtimes.

The apphost will generally use a global install of the .NET runtime, where install locations are defined by [install locations](https://github.com/dotnet/designs/blob/main/accepted/2021/install-location-per-architecture.md).

The .NET runtime path can also be customized on a per-execution basis. The DOTNET_ROOT environment variable can be used to point to the custom location. Details for all DOTNET_ROOT configuration can also be found in [install locations](https://github.com/dotnet/designs/blob/main/accepted/2021/install-location-per-architecture.md).

In general, the best practice for using `DOTNET_ROOT` to set the runtime location for an app is to:

1. Clear DOTNET_ROOT environment variables first, meaning all environment variables that start with the text `DOTNET_ROOT`.
2. Set `DOTNET_ROOT`, and only `DOTNET_ROOT`, to the target path.
3. Execute the target apphost.