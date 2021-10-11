---
title: Environment variables used by .NET SDK, .NET CLI, and .NET runtime
description: Learn about the environment variables that you can use to configure the .NET SDK, .NET CLI, and .NET runtime.
ms.date: 07/20/2021
---
# Environment variables used by .NET SDK, .NET CLI, and .NET runtime

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

Use the following environment variables to configure the .NET SDK, .NET CLI, and .NET runtime.

## `DOTNET_ROOT`, `DOTNET_ROOT(x86)`

Specifies the location of the .NET runtimes, if they are not installed in the default location. The default location on Windows is `C:\Program Files\dotnet`. The default location on Linux and macOS is `/usr/share/dotnet`. This environment variable is used only when running apps via generated executables (apphosts). `DOTNET_ROOT(x86)` is used instead when running a 32-bit executable on a 64-bit OS.

## `NUGET_PACKAGES`

The global packages folder. If not set, it defaults to `~/.nuget/packages` on Unix or `%userprofile%\.nuget\packages` on Windows.

## `DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

## `DOTNET_NOLOGO`

Specifies whether .NET welcome and telemetry messages are displayed on first run. Set to `true` to mute these messages (values `true`, `1`, or `yes` accepted) or set to `false` to allow (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the messages will be displayed on first run. This flag has no effect on telemetry (see `DOTNET_CLI_TELEMETRY_OPTOUT` for opting out of sending telemetry).

## `DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted). Otherwise, set to `false` to opt into the telemetry features (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the telemetry feature is active.

## `DOTNET_MULTILEVEL_LOOKUP`

Specifies whether .NET runtime, shared framework, or SDK are resolved from the global location. If not set, it defaults to 1 (logical `true`). Set to 0 (logical `false`) to not resolve from the global location and have isolated .NET installations. For more information about multi-level lookup, see [Multi-level SharedFX Lookup](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/multilevel-sharedfx-lookup.md).

## `DOTNET_ROLL_FORWARD`

Determines roll forward behavior. For more information, see the `--roll-forward` option earlier in this article.  **Available starting with .NET Core 3.x.**

## `DOTNET_ROLL_FORWARD_TO_PRERELEASE`

If set to `1` (enabled), enables rolling forward to a pre-release version from a release version. By default (`0` - disabled), when a release version of .NET runtime is requested, roll-forward will only consider installed release versions. **Available starting with .NET Core 3.x.**

For more information, see [Roll forward](../whats-new/dotnet-core-3-0.md#major-version-runtime-roll-forward).

## `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX`

Disables minor version roll forward, if set to `0`. For more information, see [Roll forward](../whats-new/dotnet-core-2-1.md#roll-forward).

This setting is superseded in .NET Core 3.0 by `DOTNET_ROLL_FORWARD`. The new settings should be used instead.

## `DOTNET_CLI_UI_LANGUAGE`

Sets the language of the CLI UI using a locale value such as `en-us`. The supported values are the same as for Visual Studio. For more information, see the section on changing the installer language in the [Visual Studio installation documentation](/visualstudio/install/install-visual-studio). The .NET resource manager rules apply, so you don't have to pick an exact match&mdash;you can also pick descendants in the `CultureInfo` tree. For example, if you set it to `fr-CA`, the CLI will find and use the `fr` translations. If you set it to a language that is not supported, the CLI falls back to English.

## `DOTNET_DISABLE_GUI_ERRORS`

For GUI-enabled generated executables - disables dialog popup, which normally shows for certain classes of errors. It only writes to `stderr` and exits in those cases.

## `DOTNET_ADDITIONAL_DEPS`

Equivalent to CLI option `--additional-deps`.

## `DOTNET_RUNTIME_ID`

Overrides the detected RID.

## `DOTNET_SHARED_STORE`

Location of the "shared store" which assembly resolution falls back to in some cases.

## `DOTNET_STARTUP_HOOKS`

List of assemblies to load and execute startup hooks from.

## `DOTNET_BUNDLE_EXTRACT_BASE_DIR`

Specifies a directory to which a single-file application is extracted before it is executed. **Available starting with .NET Core 3.x.**

For more information, see [Single-file executables](../whats-new/dotnet-core-3-0.md#single-file-executables).

## `COREHOST_TRACE`

Controls diagnostics tracing from the hosting components, such as `dotnet.exe`, `hostfxr`, and `hostpolicy`.

* `COREHOST_TRACE=[0/1]` - default is `0` - tracing disabled. If set to `1`, diagnostics tracing is enabled.
* `COREHOST_TRACEFILE=<file path>` - only has effect if tracing is enabled via `COREHOST_TRACE=1`. When set, the tracing information is written to the specified file, otherwise the tracing information is written to `stderr`. **Available starting with .NET Core 3.x.**
* `COREHOST_TRACE_VERBOSITY=[1/2/3/4]` - default is `4`. The setting is used only when tracing is enabled via `COREHOST_TRACE=1`. **Available starting with .NET Core 3.x.**

  * `4` - all tracing information is written
  * `3` - only informational, warning and error messages are written
  * `2` - only warning and error messages are written
  * `1` - only error messages are written

The typical way to get detailed trace information about application startup is to set `COREHOST_TRACE=1` and`COREHOST_TRACEFILE=host_trace.txt` and then run the application. A new file `host_trace.txt` will be created in the current directory with the detailed information.

## `DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE`

Disables background download of advertising manifests for workloads. Default is `false` - not disabled. If set to `true`, downloading is disabled. For more information, see [Advertising manifests](dotnet-workload-install.md#advertising-manifests).

## `DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_INTERVAL_HOURS`

Specifies the minimum number of hours between background downloads of advertising manifests for workloads. Default is `24` - no more frequently than once a day. For more information, see [Advertising manifests](dotnet-workload-install.md#advertising-manifests).

## See also

- [dotnet command](dotnet.md)
- [Runtime Configuration Files](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md)
- [.NET runtime configuration settings](../run-time-config/index.md)
