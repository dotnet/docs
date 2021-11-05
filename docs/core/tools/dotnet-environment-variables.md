---
title: Environment variables used by .NET SDK, .NET CLI, and .NET runtime
description: Learn about the environment variables that you can use to configure the .NET SDK, .NET CLI, and .NET runtime.
ms.date: 11/05/2021
---

# Environment variables used by .NET SDK, .NET CLI, and .NET runtime

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

Use the following environment variables to configure the .NET SDK, .NET CLI, and .NET runtime.

## .NET runtime environment variables

### `DOTNET_USE_POLLING_FILE_WATCHER`

The <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider> uses the `DOTNET_USE_POLLING_FILE_WATCHER` to determine whether to the <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider.Watch%2A?displayProperty=nameWithType> will rely on the <xref:Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken>.

### `DOTNET_SYSTEM_NET_HTTP_*`

There are several global HTTP environment variable settings:

- `DOTNET_SYSTEM_NET_HTTP_ENABLEACTIVITYPROPAGATION`
  - A value indicating whether or not to enable activity propagation of the diagnostic handler for global HTTP settings.
- `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT`
  - When set to `false` or `0`, overrides the default allowance of HTTP/2.
- `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP3SUPPORT`
  - When set to `true` or `1`, overrides the default disallowance of HTTP/3.
- `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2FLOWCONTROL_DISABLEDYNAMICWINDOWSIZING`
  - When set to `false` or `0`, overrides the default and disables the HTTP/2 dynamic window scaling algorithm.
- `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_MAXSTREAMWINDOWSIZE`
  - Defaults to 16 MB, when overridden the maximum size of the HTTP/2 stream receive window cannot be less than 65,535.
- `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_STREAMWINDOWSCALETHRESHOLDMULTIPLIER`
  - Defaults to 1.0, when overridden higher values result in a shorter window, but slower downloads but they cannot be less than 0.

### System globalization settings

- `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT`: See [set invariant mode](#global-invariant).
- `DOTNET_SYSTEM_GLOBALIZATION_PREDEFINED_CULTURES_ONLY`: Specifies whether to load only predefined cultures.
- `DOTNET_SYSTEM_GLOBALIZATION_APPLOCALICU`: A value indicating whether to use the app-local International Components of Unicode (ICU). For more information, see [App-local ICU](../extensions/globalization-icu.md#app-local-icu).

#### <p id="global-invariant">Set invariant mode</p>

Applications can enable the invariant mode by either of the following:

1. In project file:

    ```xml
    <PropertyGroup>
        <InvariantGlobalization>true</InvariantGlobalization>
    </PropertyGroup>
    ```

1. In _runtimeconfig.json_ file:

    ```json
    {
        "runtimeOptions": {
            "configProperties": {
                "System.Globalization.Invariant": true
            }
        }
    }
    ```

1. Setting environment variable value `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT` to `true` or `1`.

> [!IMPORTANT]
> A value set in the project file or _runtimeconfig.json_ has a higher priority than the environment variable.

For more information, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

#### Globalization mode on Windows

For Globalization to use the National Language Support (NLS), set `DOTNET_SYSTEM_GLOBALIZATION_USENLS` to either `true` or `1`. To not use it, set `DOTNET_SYSTEM_GLOBALIZATION_USENLS` to either `false` or `0`.

### System socket settings

This section focuses on two `System.Net.Sockets` environment variables:

- `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS`
- `DOTNET_SYSTEM_NET_SOCKETS_THREAD_COUNT`

Socket continuations are dispatched to the <xref:System.Threading.ThreadPool?displayProperty=fullName> from the event thread. This avoids continuations blocking the event handling. To allow continuations to run directly on the event thread, set `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` to `1`. It's disabled by default.

> [!NOTE]
> This setting can make performance worse if there is expensive work that will end up holding onto the IO thread for longer than needed. Test to make sure this setting helps performance.

Using TechEmpower benchmarks that generate a lot of small socket reads and writes under a very high load, it was observed that a single socket engine is capable of keeping busy up to thirty x64 and eight ARM64 CPU Cores. The vast majority of real-life scenarios will never generate such a huge load (hundreds of thousands of requests per second)
and having a single producer should be almost always enough. However, to be sure that extreme loads can be handled the `DOTNET_SYSTEM_NET_SOCKETS_THREAD_COUNT` can be used to override the calculated value. When not overridden, the following value is used:

- When `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` is `1`, the <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> value is used.
- When `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` is not `1`, <xref:System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture?displayProperty=nameWithType> is evaluated:
  - When ARM or ARM64 the cores per engine is `8`, otherwise `30`.
- Using the determined cores per engine, the maximum value of either `1` or <xref:System.Environment.ProcessorCount?displayProperty=nameWithType over the cores per engine.

#### Socket protocol support

The `DOTNET_SYSTEM_NET_DISABLEIPV6` environment variable is used to help determine whether or not Internet Protocol version 6 (IPv6) is disabled. When `DOTNET_SYSTEM_NET_DISABLEIPV6` is set to either `true` or `1`, IPv6 is disabled unless otherwise specified in the <xref:System.AppContext?displayProperty=nameWithType>.

#### Networking performance

You can use one of the following mechanisms to configure a process to use the older `HttpClientHandler`:

From code, use the `AppContext` class:

```csharp
AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
```

The `AppContext` switch can also be set by config file.

The same can be achieved via the environment variable `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER`. To opt out, set the value to either `false` or `0`.

### Just-In-Time (JIT) and Garbage Collection (GC) settings

There are two stressing related features for the JIT and JIT generated GC info — JIT Stress and GC Hole Stress. These features provide a way during development to discover edge cases and more "real world" scenarios without having to develop complex applications. The following environment variables are available:

- `DOTNET_JitStress`
- `DOTNET_JitStressModeNamesOnly`
- `DOTNET_GCStress`

#### JIT stress

Enabling JIT Stress can be done in several ways. Setting `DOTNET_JitStress` to a non-zero integer value that will generate varying levels of JIT optimizations based on a hash of the method's name or set to a value of two. To apply all optimizations set, `DOTNET_JitStress=2` for example. Another way to enable JIT Stress is by setting `DOTNET_JitStressModeNamesOnly=1` and then requesting the stress modes, space delimited, in the `DOTNET_JitStressModeNames` variable. As an example consider, `DOTNET_JitStressModeNames=STRESS_USE_CMOV STRESS_64RSLT_MUL STRESS_LCL_FLDS`.

#### GC Hole stress

Enabling GC Hole Stress causes GCs to always occur in specific locations and that helps to track down GC holes. GC Hole Stress can be enabled using the `DOTNET_GCStress` environment variable.

For more information, see [Investigating JIT and GC Hole stress](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/jit/investigate-stress.md).

#### JIT memory barriers

The code generator for ARM64 allows all `MemoryBarriers` instructions can be removed by setting `DOTNET_JitNoMemoryBarriers` to `1`.

### Container variables

The official .NET images (Windows and Linux) set the well-known environment variables:

- `DOTNET_RUNNING_IN_CONTAINER`
- `DOTNET_RUNNING_IN_CONTAINERS`

These values are used to determine when your ASP.NET Core workloads are running in the context of a container.

## .NET SDK and CLI environment variables

### `DOTNET_ROOT`, `DOTNET_ROOT(x86)`

Specifies the location of the .NET runtimes, if they are not installed in the default location. The default location on Windows is `C:\Program Files\dotnet`. The default location on Linux and macOS is `/usr/share/dotnet`. This environment variable is used only when running apps via generated executables (apphosts). `DOTNET_ROOT(x86)` is used instead when running a 32-bit executable on a 64-bit OS.

### `NUGET_PACKAGES`

The global packages folder. If not set, it defaults to `~/.nuget/packages` on Unix or `%userprofile%\.nuget\packages` on Windows.

### `DOTNET_SERVICING`

Specifies the location of the servicing index to use by the shared host when loading the runtime.

### `DOTNET_NOLOGO`

Specifies whether .NET welcome and telemetry messages are displayed on the first run. Set to `true` to mute these messages (values `true`, `1`, or `yes` accepted) or set to `false` to allow (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the messages will be displayed on the first run. This flag does not affect telemetry (see `DOTNET_CLI_TELEMETRY_OPTOUT` for opting out of sending telemetry).

### `DOTNET_CLI_TELEMETRY_OPTOUT`

Specifies whether data about the .NET tools usage is collected and sent to Microsoft. Set to `true` to opt-out of the telemetry feature (values `true`, `1`, or `yes` accepted). Otherwise, set to `false` to opt into the telemetry features (values `false`, `0`, or `no` accepted). If not set, the default is `false` and the telemetry feature is active.

### `DOTNET_SKIP_FIRST_TIME_EXPERIENCE`

If `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` is set to `true`, the `NuGetFallbackFolder` won't be expanded to disk and a shorter welcome message and telemetry notice will be shown.

### `DOTNET_MULTILEVEL_LOOKUP`

Specifies whether .NET runtime, shared framework, or SDK are resolved from the global location. If not set, it defaults to 1 (logical `true`). Set to 0 (logical `false`) to not resolve from the global location and have isolated .NET installations. For more information about multi-level lookup, see [Multi-level SharedFX Lookup](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/multilevel-sharedfx-lookup.md).

### `DOTNET_ROLL_FORWARD`

Determines roll forward behavior. For more information, see the `--roll-forward` option earlier in this article.  **Available starting with .NET Core 3.x.**

### `DOTNET_ROLL_FORWARD_TO_PRERELEASE`

If set to `1` (enabled), enables rolling forward to a pre-release version from a release version. By default (`0` - disabled), when a release version of .NET runtime is requested, roll-forward will only consider installed release versions. **Available starting with .NET Core 3.x.**

For more information, see [Roll forward](../whats-new/dotnet-core-3-0.md#major-version-runtime-roll-forward).

### `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX`

Disables minor version roll forward, if set to `0`. For more information, see [Roll forward](../whats-new/dotnet-core-2-1.md#roll-forward).

This setting is superseded in .NET Core 3.0 by `DOTNET_ROLL_FORWARD`. The new settings should be used instead.

### `DOTNET_CLI_UI_LANGUAGE`

Sets the language of the CLI UI using a locale value such as `en-us`. The supported values are the same as for Visual Studio. For more information, see the section on changing the installer language in the [Visual Studio installation documentation](/visualstudio/install/install-visual-studio). The .NET resource manager rules apply, so you don't have to pick an exact match&mdash;you can also pick descendants in the `CultureInfo` tree. For example, if you set it to `fr-CA`, the CLI will find and use the `fr` translations. If you set it to a language that is not supported, the CLI falls back to English.

### `DOTNET_DISABLE_GUI_ERRORS`

For GUI-enabled generated executables - disables dialog popup, which normally shows for certain classes of errors. It only writes to `stderr` and exits in those cases.

### `DOTNET_ADDITIONAL_DEPS`

Equivalent to CLI option `--additional-deps`.

### `DOTNET_RUNTIME_ID`

Overrides the detected RID.

### `DOTNET_SHARED_STORE`

Location of the "shared store" which assembly resolution falls back to in some cases.

### `DOTNET_STARTUP_HOOKS`

List of assemblies to load and execute startup hooks from.

### `DOTNET_BUNDLE_EXTRACT_BASE_DIR`

Specifies a directory to which a single-file application is extracted before it is executed. **Available starting with .NET Core 3.x.**

For more information, see [Single-file executables](../whats-new/dotnet-core-3-0.md#single-file-executables).

### `DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE`

Disables background download of advertising manifests for workloads. Default is `false` - not disabled. If set to `true`, downloading is disabled. For more information, see [Advertising manifests](dotnet-workload-install.md#advertising-manifests).

### `DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_INTERVAL_HOURS`

Specifies the minimum number of hours between background downloads of advertising manifests for workloads. Default is `24` - no more frequently than once a day. For more information, see [Advertising manifests](dotnet-workload-install.md#advertising-manifests).

### `COREHOST_TRACE`

Controls diagnostics tracing from the hosting components, such as `dotnet.exe`, `hostfxr`, and `hostpolicy`.

* `COREHOST_TRACE=[0/1]` - default is `0` - tracing disabled. If set to `1`, diagnostics tracing is enabled.
* `COREHOST_TRACEFILE=<file path>` - only has effect if tracing is enabled via `COREHOST_TRACE=1`. When set, the tracing information is written to the specified file, otherwise, the tracing information is written to `stderr`. **Available starting with .NET Core 3.x.**
* `COREHOST_TRACE_VERBOSITY=[1/2/3/4]` - default is `4`. The setting is used only when tracing is enabled via `COREHOST_TRACE=1`. **Available starting with .NET Core 3.x.**

  * `4` - all tracing information is written
  * `3` - only informational, warning, and error messages are written
  * `2` - only warning and error messages are written
  * `1` - only error messages are written

The typical way to get detailed trace information about application startup is to set `COREHOST_TRACE=1` and`COREHOST_TRACEFILE=host_trace.txt` and then run the application. A new file `host_trace.txt` will be created in the current directory with the detailed information.

### `SuppressNETCoreSdkPreviewMessage`

If set to `true`, invoking `dotnet` won't produce a warning when a preview SDK is being used.

### `DOTNET_WATCH_*`

The following .NET watch settings are available as environment variables:

- `DOTNET_WATCH_SUPPRESS_STATIC_FILE_HANDLING`
- `DOTNET_WATCH_SUPPRESS_MSBUILD_INCREMENTALISM`
- `DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER`
- `DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH`

These options are enabled when they're set to either `true` or `1`.

## See also

- [dotnet command](dotnet.md)
- [Runtime Configuration Files](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md)
- [.NET runtime configuration settings](../run-time-config/index.md)
