---
title: Well-known .NET environment variables
description: Learn about the well-known .NET environment variables, and how they're used.
author: IEvangelist
ms.author: dapine
ms.date: 11/05/2021
ms.topic: reference
---

# Well-known .NET environment variables

In this article, you'll learn about the well-known .NET environment variables. There are environment variables used as part of the .NET installer, the .NET SDK, the .NET CLI, the .NET runtime and even ASP.NET Core .NET workloads.

## .NET runtime environment variables

### `DOTNET_USE_POLLING_FILE_WATCHER`

The <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider> uses the `DOTNET_USE_POLLING_FILE_WATCHER` to determine whether to the <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider.Watch%2A?displayProperty=nameWithType> will rely on the <xref:Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken>.

### `DOTNET_SYSTEM_NET_HTTP_*` Global HTTP settings

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
- `DOTNET_SYSTEM_GLOBALIZATION_APPLOCALICU`: A value indicating whether to use the app-local International Components of Unicode (ICU).

#### <a id="global-invariant">Set invariant mode</a>

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

> [!CAUTION]
> This setting can make performance worse if there is expensive work that will end up holding onto the IO thread for longer than needed. Test to make sure this setting helps performance.

Using TechEmpower benchmarks that generate a lot of small socket reads and writes under a very high load, it was observed that a single socket engine is capable of keeping busy up to thirty x64 and eight ARM64 CPU Cores. The vast majority of real-life scenarios will never generate such a huge load (hundreds of thousands of requests per second)
and having a single producer should be almost always enough. However, to be sure that extreme loads can be handled the `DOTNET_SYSTEM_NET_SOCKETS_THREAD_COUNT` can be used to override the calculated value. When not overridden, the following value is used:

- When `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` is `1`, the <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> value is used.
- When `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` is not `1`, <xref:System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture?displayProperty=nameWithType> is evaluated:
  - When ARM or ARM64 the cores per engine is `8`, otherwise `30`.
- Using the determined cores per engine, the maximum value of either `1` or <xref:System.Environment.ProcessorCount?displayProperty=nameWithType over the cores per engine.

### Console

// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Console/src/System/ConsolePal.Unix.cs

- `DOTNET_SYSTEM_CONSOLE_ALLOW_ANSI_COLOR_REDIRECTION`

// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Diagnostics.DiagnosticSource/src/System/Diagnostics/LocalAppContextSwitches.cs
`DOTNET_SYSTEM_DIAGNOSTICS_DEFAULTACTIVITYIDFORMATISHIERARCHIAL`

// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Runtime.Caching/src/System/Runtime/Caching/Dbg.cs
`DOTNET_SYSTEM_RUNTIME_CACHING_TRACING`

// https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Configuration.UserSecrets/src/PathHelper.cs
`DOTNET_USER_SECRETS_FALLBACK_DIR`

// https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.DependencyModel/src/Resolution/DotNetReferenceAssembliesPathResolver.cs
`DOTNET_REFERENCE_ASSEMBLIES_PATH`

// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/System/Net/SocketProtocolSupportPal.cs
`DOTNET_SYSTEM_NET_DISABLEIPV6`



// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.RegularExpressions/src/System/Text/RegularExpressions/RegexLWCGCompiler.cs
`DOTNET_SYSTEM_TEXT_REGULAREXPRESSIONS_PATTERNINNAME`

// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Net.Http/src/System/Net/Http/SocketsHttpHandler/AuthenticationHelper.NtAuth.cs
`DOTNET_SYSTEM_NET_HTTP_USEPORTINSPN`

// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/Microsoft/Win32/SafeHandles/SafeFileHandle.Unix.cs
`DOTNET_SYSTEM_IO_DISABLEFILELOCKING`

// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Unix/System.Security.Cryptography.Native/Interop.OpenSsl.cs
`DOTNET_SYSTEM_NET_SECURITY_DISABLETLSRESUME`

// https://github.com/dotnet/runtime/blob/main/src/coreclr/inc/eventtracebase.h
`DOTNET_TRACE_CONTEXT`

// https://github.com/dotnet/runtime/blob/main/src/native/corehost/hostpolicy/hostpolicy_context.cpp
// https://github.com/dotnet/runtime/blob/main/docs/design/features/host-startup-hook.md
`DOTNET_STARTUP_HOOKS`

// https://github.com/dotnet/runtime/blob/main/src/coreclr/jit/codegenarm64.cpp
`DOTNET_JitNoMemoryBarriers`

### Just-in Time (JIT)

// https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/jit/investigate-stress.md

- `DOTNET_JitStress`
- `DOTNET_JitStressModeNamesOnly`
- `DOTNET_GCStress`

// https://github.com/dotnet/runtime/blob/main/docs/design/features/additional-deps.md
`DOTNET_ADDITIONAL_DEPS`

### Tracing and diagnostic settings

// https://github.com/dotnet/runtime/blob/main/docs/design/mono/diagnostics-tracing.md
// https://github.com/dotnet/runtime/blob/main/src/mono/mono/eventpipe/ds-rt-mono.h
`DOTNET_EnableDiagnostics`
`DOTNET_DefaultDiagnosticPortSuspend`
`DOTNET_DiagnosticPorts`

// https://github.com/dotnet/runtime/blob/main/src/mono/mono/eventpipe/ep-rt-mono.h
`DOTNET_EnableEventPipe`
`DOTNET_EventPipeConfig`
`DOTNET_EventPipeOutputPath`
`DOTNET_EventPipeOutputStreaming`

// https://github.com/dotnet/runtime/blob/main/src/mono/mono/component/hot_reload.c
`DOTNET_MODIFIABLE_ASSEMBLIES`

## ASP.NET Core runtime environment variables

// https://github.com/dotnet/aspnetcore/blob/main/src/Hosting/Server.IntegrationTesting/src/Common/DotNetCommands.cs

`DOTNET_HOME`
`DOTNET_ROOT`
`DOTNET_INSTALL_DIR`

// https://github.com/dotnet/aspnetcore/blob/main/src/DataProtection/DataProtection/src/Internal/ContainerUtils.cs

`DOTNET_RUNNING_IN_CONTAINER`
`DOTNET_RUNNING_IN_CONTAINERS`

// https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/Server/src/ComponentsWebAssemblyApplicationBuilderExtensions.cs
`DOTNET_MODIFIABLE_ASSEMBLIES`

// https://github.com/dotnet/aspnetcore/blob/main/src/Tools/Shared/CommandLine/CliContext.cs
`DOTNET_CLI_CONTEXT_VERBOSE`

// https://github.com/dotnet/aspnetcore/blob/main/src/Servers/IIS/IIS/src/StartupHook.cs
`DOTNET_ENVIRONMENT`

## .NET SDK environment variables

### .NET watch settings

// https://github.com/dotnet/sdk/blob/main/src/BuiltInTools/dotnet-watch/DotNetWatchOptions.cs
`DOTNET_WATCH_SUPPRESS_STATIC_FILE_HANDLING`
`DOTNET_WATCH_SUPPRESS_MSBUILD_INCREMENTALISM`
`DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER`
`DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH`

// https://github.com/dotnet/sdk/blob/main/src/BuiltInTools/dotnet-watch/Program.cs
`DOTNET_USE_POLLING_FILE_WATCHER`
`DOTNET_WATCH`
`DOTNET_WATCH_ITERATION`
`DOTNET_CLI_CONTEXT_VERBOSE`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/UILanguageOverride.cs

`DOTNET_CLI_UI_LANGUAGE`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/Program.cs
`DOTNET_CLI_PERF_LOG`
`DOTNET_GENERATE_ASPNET_CERTIFICATE`
`DOTNET_ADD_GLOBAL_TOOLS_TO_PATH`

// https://github.com/dotnet/sdk/blob/main/src/Cli/Microsoft.DotNet.Cli.Utils/MSBuildForwardingAppWithoutLogging.cs
`DOTNET_CLI_RUN_MSBUILD_OUTOFPROC`
`DOTNET_CLI_USE_MSBUILDNOINPROCNODE`

// https://github.com/dotnet/sdk/blob/main/src/BuiltInTools/DotNetDeltaApplier/StartupHook.cs
`DOTNET_HOTRELOAD_NAMEDPIPE_NAME`

// https://github.com/dotnet/sdk/blob/main/src/Common/EnvironmentVariableNames.cs
`DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE`
`DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_INTERVAL_HOURS`
``

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/PerformanceLogManager.cs
`DOTNET_PERFLOG_DIR`

// https://github.com/dotnet/sdk/blob/main/src/Resolvers/Microsoft.DotNet.MSBuildSdkResolver/MSBuildSdkResolver.cs
`DOTNET_MSBUILD_SDK_RESOLVER_SDKS_DIR`
`DOTNET_MSBUILD_SDK_RESOLVER_SDKS_VER`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/commands/dotnet-internal-reportinstallsuccess/InternalReportinstallsuccessCommand.cs
`DOTNET_CLI_TELEMETRY_SESSIONID`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/commands/dotnet-new/NewCommandShim.cs
`DOTNET_NEW_PREFERRED_LANG`

// https://github.com/dotnet/sdk/blob/main/src/Resolvers/Microsoft.DotNet.NativeWrapper/EnvironmentProvider.cs
`DOTNET_MSBUILD_SDK_RESOLVER_CLI_DIR`

// https://github.com/dotnet/sdk/blob/main/src/Cli/Microsoft.DotNet.Cli.Utils/CommandContext.cs
`DOTNET_CLI_CONTEXT_{VERBOSE}`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/Telemetry/PersistenceChannel/PersistenceChannelDebugLog.cs
`DOTNET_ENABLE_PERSISTENCE_CHANNEL_DEBUG_OUTPUT`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/NugetPackageDownloader/FirstPartyNuGetPackageSigningVerifier.cs

`DOTNET_CLI_TEST_FORCE_SIGN_CHECK`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/ShellShim/OsxBashEnvironmentPath.cs

`DOTNET_CLI_TEST_OSX_PATHSD_PATH`

// https://github.com/dotnet/sdk/blob/main/src/Cli/dotnet/ShellShim/LinuxEnvironmentPath.cs

`DOTNET_CLI_TEST_LINUX_PROFILED_PATH`

// https://github.com/dotnet/sdk/blob/main/src/RazorSdk/Tool/ServerCommand.cs

`DOTNET_BUILD_PIDFILE_DIRECTORY`

// https://github.com/dotnet/sdk/blob/main/src/BuiltInTools/dotnet-watch/Filters/BrowserRefreshServer.cs

`DOTNET_WATCH_AUTO_RELOAD_WS_HOSTNAME`

// https://github.com/dotnet/installer/blob/main/src/SourceBuild/tarball/content/eng/install-nuget-credprovider.sh
`DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER`

// https://github.com/dotnet/installer/blob/main/build.sh
`DOTNET_CORESDK_NOPRETTYPRINT`

// https://github.com/dotnet/installer/blob/main/eng/dockerrun.ps1
`DOTNET_CORESDK_IGNORE_TAR_EXIT_CODE`
`DOTNET_BUILD_SKIP_CROSSGEN`

## See also

- [.NET runtime configuration settings](index.md)
- [Environment variables used by .NET SDK, .NET CLI, and .NET runtime](../tools/dotnet-environment-variables.md)
