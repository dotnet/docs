---
title: dotnet-dsrouter - .NET
description: An introduction to dotnet-dsrouter in .NET.
ms.date: 11/26/2021
---
# dotnet-dsrouter

**This article applies to:** ✔️ .NET 6.0 SDK and later versions

## Install

There are two ways to download and install `dotnet-dsrouter`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-dsrouter` [NuGet package](https://www.nuget.org/packages/dotnet-trace), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-dsrouter
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS | Platform |
  |--|--|
  | Windows | [x86](https://aka.ms/dotnet-dsrouter/win-x86) or [x64](https://aka.ms/dotnet-trace/win-x64) |
  | macOS | [x64](https://aka.ms/dotnet-dsrouter/osx-x64) |
  | Linux | [x64](https://aka.ms/dotnet-dsrouter/linux-x64) |

## Synopsis

```console
dotnet-dsrouter [-?, -h, --help] [--version] <command>
```

## Description

The `dotnet-dsrouter` connects diagnostic tooling like `dotnet-trace` and `dotnet-counters` to .NET applications running on Android, iOS, and tvOS, regardless of whether they're running as an emulator, simulator, or on the device itself. Diagnostic tooling uses local inter-process communication (IPC) (Named Pipe, Unix Domain Socket) to connect and communicate with a .NET runtime. .NET applications running in sandboxed environments on emulators, simulators, and devices need alternative ways to communicate. The `dotnet-dsrouter` injects itself between existing diagnostic tooling and .NET mobile applications and creates a local representation of the application. The `dotnet-dsrouter` enables diagnostic tools to communicate with a remote .NET runtime as if it has been running on the local machine.

The communication between diagnostic tooling and `dotnet-dsrouter` uses the same IPC (Named Pipe, Unix Domain Socket) as used when connecting to a local .NET runtime. `dotnet-dsrouter` uses TCP/IP in its communication with remote .NET runtime and support several different connectivity scenarios to handle different needs and requirements used by different platforms. `dotnet-dsrouter` also implements additional support to simplify connectivity configuration when running in emulator, simulator, and on physical device attached over USB.

> [!NOTE]
> `dotnet-dsrouter` is intended for development and testing and it's highly recommended to run `dotnet-dsrouter` over loopback interface (for example, `127.0.0.1`, `[::1]`). The connectivity features and port forwarding capabilities of `dotnet-dsrouter` handles all scenarios using local emulator, simulator or physical device connected over USB.

> [!WARNING]
> Binding TCP server endpoint to anything except loopback interface (`localhost`, `127.0.0.1` or `[::1]`) is _not_ recommended. Any connections towards TCP server endpoint will be unauthenticated and unencrypted. `dotnet-dsrouter` is intended for development use and should only be run in development and testing environments.

Detailed usage of `dotnet-dsrouter` together with mobile applications is outline by respective .NET SDKs. This document will only include a couple of examples on how to run diagnostic tools against .NET application running on Android. For in-depth details on configuration and scenarios, see [Diagnostics Tracing](https://github.com/dotnet/runtime/blob/main/docs/design/mono/diagnostics-tracing.md).

## Options

- **`-?|-h|--help`**

  Shows command-line help.

- **`--version`**

  Displays the version of the `dotnet-dsrouter` utility.

## Commands

| Command                                                         |
|-----------------------------------------------------------------|
| [dotnet-dsrouter client-server](#dotnet-dsrouter-client-server) |
| [dotnet-dsrouter server-server](#dotnet-dsrouter-server-server) |
| [dotnet-dsrouter server-client](#dotnet-dsrouter-server-client) |
| [dotnet-dsrouter client-client](#dotnet-dsrouter-client-client) |

## dotnet-dsrouter client-server

Start a .NET application diagnostics server routing local IPC server and remote TCP client. The router is configured using an IPC client (connecting diagnostic tool IPC server) and a TCP/IP server (accepting runtime TCP client).

### Synopsis

```console
dotnet-dsrouter client-server
    [-ipcc|--ipc-client <ipcClient>]
    [-tcps|--tcp-server <tcpServer>]
    [-rt|--runtime-timeout <timeout>]
    [-v|--verbose <level>]
    [-fp|--forward-port <platform>]
```

### Options

- **`-ipcc, --ipc-client <ipcClient>`**
  The diagnostic tool diagnostics server IPC address (`--diagnostic-port` argument). Router connects diagnostic tool IPC server when establishing a new route between runtime and diagnostic tool.

- **`-tcps, --tcp-server <tcpServer>`**
  The router TCP/IP address using format `[host]:[port]`. Router can bind one (`127.0.0.1`, `[::1]`, `0.0.0.0`, `[::]`, IPv4 address, IPv6 address, hostname) or all (*) interfaces. Launch runtime using `DOTNET_DiagnosticPorts` environment variable, connecting router TCP server during startup.

- **`-rt, --runtime-timeout <runtimeTimeout>`**
  Automatically shut down router if no runtime connects to it before specified timeout (seconds). If not specified, router won't trigger an automatic shutdown.

- **`-v, --verbose <verbose>`**
  Enable verbose logging (debug|trace)

- **`-fp, --forward-port <forwardPort>`**
  Enable port forwarding, values `Android` or `iOS` for `TcpClient`, and only `Android` for `TcpServer`. Make sure to set `ANDROID_SDK_ROOT` before using this option on Android.

## dotnet-dsrouter server-server

Start a .NET application diagnostics server routing local IPC client and remote TCP client. The router is configured using an IPC server (connecting to by diagnostic tools) and a TCP/IP server (accepting runtime TCP client).

### Synopsis

```console
dotnet-dsrouter server-server
    [-ipcs|--ipc-server <ipcServer>]
    [-tcps|--tcp-server <tcpServer>]
    [-rt|--runtime-timeout <timeout>]
    [-v|--verbose <level>]
    [-fp|--forward-port <platform>]
```

### Options

- **`-ipcs, --ipc-server <ipcServer>`**
  The diagnostics server IPC address to route. Router accepts IPC connections from diagnostic tools establishing a new route between runtime and diagnostic tool. If not specified router will use default IPC diagnostics server path.

- **`-tcps, --tcp-server <tcpServer>`**
  The router TCP/IP address using format `[host]:[port]`. Router can bind one (`127.0.0.1`, `[::1]`, `0.0.0.0`, `[::]`, IPv4 address, IPv6 address, hostname) or all (*) interfaces. Launch runtime using `DOTNET_DiagnosticPorts` environment variable, connecting router TCP server during startup.

- **`-rt, --runtime-timeout <runtimeTimeout>`**
  Automatically shut down router if no runtime connects to it before specified timeout (seconds). If not specified, router won't trigger an automatic shutdown.

- **`-v, --verbose <verbose>`**
  Enable verbose logging (debug|trace)

- **`-fp, --forward-port <forwardPort>`**
  Enable port forwarding, values `Android` or `iOS` for `TcpClient`, and only `Android` for `TcpServer`. Make sure to set `ANDROID_SDK_ROOT` before using this option on Android.

## dotnet-dsrouter server-client

Start a .NET application diagnostics server routing local IPC client and remote TCP server. The router is configured using an IPC server (connecting to by diagnostic tools) and a TCP/IP client (connecting runtime TCP server).

### Synopsis

```console
dotnet-dsrouter server-client
    [-ipcs|--ipc-server <ipcServer>]
    [-tcpc|--tcp-client <tcpClient>]
    [-rt|--runtime-timeout <timeout>]
    [-v|--verbose <level>]
    [-fp|--forward-port <platform>]
```

### Options

- **`-ipcs, --ipc-server <ipcServer>`**
  The diagnostics server IPC address to route. Router accepts IPC connections from diagnostic tools establishing a new route between runtime and diagnostic tool. If not specified router will use default IPC diagnostics server path.

- **`-tcpc, --tcp-client <tcpClient>`**
  The runtime TCP/IP address using format `[host]:[port]`. Router can connect `127.0.0.1`, `[::1]`, IPv4 address, IPv6 address, hostname addresses. Launch runtime using `DOTNET_DiagnosticPorts` environment variable to set up listener.

- **`-rt, --runtime-timeout <runtimeTimeout>`**
  Automatically shut down router if no runtime connects to it before specified timeout (seconds). If not specified, router won't trigger an automatic shutdown.

- **`-v, --verbose <verbose>`**
  Enable verbose logging (debug|trace)

- **`-fp, --forward-port <forwardPort>`**
  Enable port forwarding, values `Android` or `iOS` for `TcpClient`, and only `Android` for `TcpServer`. Make sure to set `ANDROID_SDK_ROOT` before using this option on Android.

## dotnet-dsrouter client-client

Start a .NET application diagnostics server routing local IPC server and remote TCP server. The router is configured using an IPC client (connecting diagnostic tool IPC server) and a TCP/IP client (connecting runtime TCP server).

### Synopsis

```console
dotnet-dsrouter client-client
    [-ipcc|--ipc-client <ipcClient>]
    [-tcpc|--tcp-client <tcpClient>]
    [-rt|--runtime-timeout <timeout>]
    [-v|--verbose <level>]
    [-fp|--forward-port <platform>]
```

### Options

- **`-ipcc, --ipc-client <ipcClient>`**
  The diagnostic tool diagnostics server IPC address (`--diagnostic-port argument`). Router connects diagnostic tool IPC server when establishing a new route between runtime and diagnostic tool.

- **`-tcpc, --tcp-client <tcpClient>`**
  The runtime TCP/IP address using format `[host]:[port]`. Router can connect `127.0.0.1`, `[::1]`, IPv4 address, IPv6 address, hostname addresses. Launch runtime using `DOTNET_DiagnosticPorts` environment variable to set up listener.

- **`-rt, --runtime-timeout <runtimeTimeout>`**
  Automatically shut down router if no runtime connects to it before specified timeout (seconds). If not specified, router won't trigger an automatic shutdown.

- **`-v, --verbose <verbose>`**
  Enable verbose logging (debug|trace)

- **`-fp, --forward-port <forwardPort>`**
  Enable port forwarding, values `Android` or `iOS` for `TcpClient`, and only `Android` for `TcpServer`. Make sure to set `ANDROID_SDK_ROOT` before using this option on Android.

## Collect a startup trace using dotnet-trace from a .NET application running on Android

Sometimes it may be useful to collect a trace of an application from its startup. The following steps illustrate the process of doing so targeting a .NET application running on Android. Since `dotnet-dsrouter` is run using port forwarding, the same scenario works against applications running on a local emulator and on a physical device attached over USB. Make sure to set `ANDROID_SDK_ROOT` before using this option, or `dotnet-dsrouter` won't be able to find `adb` needed to set up port forwarding.

- Launch dotnet-dsrouter in server-server mode:

  ```console
  dotnet-dsrouter server-server -ipcs ~/mylocalport -tcps 127.0.0.1:9000 --forward-port Android &
  ```

- Set `DOTNET_DiagnosticPorts` environment variable using `AndroidEnvironment`:

  Create a file in the same directory as the _.csproj_ using a name like `app.env`, add environment variables into file, `DOTNET_DiagnosticPorts=127.0.0.1:9000,suspend` and include following `ItemGroup` into _.csproj_:

  ```xml
  <ItemGroup Condition="'$(AndroidEnableProfiler)'=='true'">
    <AndroidEnvironment Include="app.env" />
  </ItemGroup>
  ```

  It's also possible to set `DOTNET_DiagnosticPorts` using `adb shell setprop`:

  ```console
  adb shell setprop debug.mono.profile '127.0.0.1:9000,suspend'
  ```

- Build and launch the application using .NET Android SDK, and enable tracing by passing `/p:AndroidEnableProfiler=true` to MSBuild. Since the app has been configured to suspend on startup, it will connect back to the `dotnet-dsrouter` TCP/IP listener running on `127.0.0.1:9000` and wait for diagnostic tooling to connect before resuming application execution.

- Start `dotnet-trace` in collect mode, connecting to `dotnet-dsrouter` IPC server, ~/mylocalport:

  ```console
    dotnet-trace collect --diagnostic-port ~/mylocalport,connect
  ```

`dotnet-trace` will start a trace session and resume application that will now continue to execute. A stream of events will start to flow from the mobile application, through `dotnet-dsrouter` into `dotnet-trace` nettrace file. When done tracing, press <kbd>Enter</kbd> to make sure trace session is properly closed making sure nettrace file includes all needed data before application gets closed.

It is possible to run several trace sessions against the same running application over time, leave `dotnet-dsrouter` running and rerun `dotnet-trace` when a new trace session is needed.

`dotnet-dsrouter` can be left running in background and reused if an application is configured to connect using its address and port.

`dotnet-dsrouter` is tied to one running application at any time. If there are needs to trace several different applications at the same time, each application needs to use its own `dotnet-dsrouter` instance, by setting up a unique IPC, TCP/IP address pair in `dotnet-dsrouter` and configure different application instances to connect back to its unique `dotnet-dsrouter` instance.

If `dotnet-dsrouter` is run with `--forward-port` targeting Android and `adb` server, emulator or device gets restarted, all `dotnet-dsrouter` instances needs to be restarted as well to restore port forwarding rules.

When done using `dotnet-dsrouter`, press <kbd>Q</kbd> or <kbd>Ctrl</kbd> + <kbd>C</kbd> to quit application.

> [!NOTE]
> When running `dotnet-dsrouter` on Windows it will use Named Pipes for its IPC channel. Replace ~/mylocalport with mylocalport in above examples when running on Windows.

> [!NOTE]
> TCP/IP port 9000 is just an example. Any free TCP/IP port can be used.

> [!NOTE]
> Unix Domain Socket ~/mylocalport is just an example. Any free Unix Domain Socket file path can be used.

## Collect a trace using dotnet-trace from a .NET application running on Android

If there's no need to collect a trace during application startup, it is possible to launch application in `nosuspend` mode, meaning runtime won't block at startup waiting for diagnostic tooling to connect before resuming execution. Most of the above-described scenario applies to this mode as well, just replace `suspend` with `nosuspend` in `DOTNET_DiagnosticPorts` environment variable to launch application in `nosuspend` mode.

## See also

- [Android .NET Tracing](https://github.com/xamarin/xamarin-android/blob/d17-0/Documentation/guides/tracing.md)
- [MAUI .NET Tracing](https://github.com/dotnet/maui/wiki/Profiling-.NET-MAUI-Apps)
- [.NET Diagnostics Tracing on mobile](https://github.com/dotnet/runtime/blob/main/docs/design/mono/diagnostics-tracing.md)
