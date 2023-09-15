---
title: Diagnostic port
description: Learn about .NET diagnostic ports
ms.date: 09/14/2023
ms.topic: overview
---

# Diagnostic ports

**This article applies to: ✔️** .NET Core 3.1 and later versions

The .NET runtime exposes a service endpoint that allows other processes to send diagnostic commands and receive responses over an [IPC channel](https://en.wikipedia.org/wiki/Inter-process_communication). This endpoint is called a *diagnostic port*. Commands can be sent to the diagnostic port to:

- Capture a memory dump.
- Start an [EventPipe](./eventpipe.md) trace.
- Request the command line used to launch the app.

The diagnostic port supports different transports depending on platform. Currently both the CoreCLR and Mono runtime implementations use Named Pipes on Windows and Unix Domain Sockets on Linux and macOS. The Mono runtime implementation on Android, iOS, and tvOS uses TCP/IP. The channel uses a [custom binary protocol](https://github.com/dotnet/diagnostics/blob/main/documentation/design-docs/ipc-protocol.md). Most developers will never directly interact with the underlying channel and protocol, but rather will use GUI or CLI tools that communicate on their behalf. For example, the [dotnet-dump](./dotnet-dump.md) and [dotnet-trace](./dotnet-trace.md) tools abstract sending protocol commands to capture dumps and start traces. For developers that want to write custom tooling, the [Microsoft.Diagnostics.NETCore.Client NuGet package](./diagnostics-client-library.md) provides a .NET API abstraction of the underlying transport and protocol.

## Security considerations

The diagnostic port exposes sensitive information about a running application. If an untrusted user gains access to this channel, they could observe detailed program state, including any secrets that are in memory, and arbitrarily modify the execution of the program. On the CoreCLR runtime, the default diagnostic port is configured to only be accessible by the same user account that launched the app or by an account with super-user permissions. If your security model does not trust other processes with the same user account credentials, you can disable all diagnostic ports by setting environment variable `DOTNET_EnableDiagnostics=0`. This setting will block your ability to use external tooling such as .NET debugging or any of the dotnet-* diagnostic tools.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Default diagnostic port

On Windows, Linux, and macOS, the runtime has one diagnostic port open by default at a well-known endpoint. This is the port that the dotnet-* diagnostic tools connect to automatically when they haven't been explicitly configured to use an alternate port. The endpoint is:

- Windows - Named Pipe `\\.\pipe\dotnet-diagnostic-{pid}`
- Linux and macOS - Unix Domain Socket `{temp}/dotnet-diagnostic-{pid}-{disambiguation_key}-socket`

`{pid}` is the process id written in decimal, `{temp}` is the `TMPDIR` environment variable or the value `/tmp` if `TMPDIR` is undefined/empty, and `{disambiguation_key}` is the process start time written in decimal. On macOS and NetBSD, the process start time is number of seconds since UNIX epoch time. On all other platforms, it's jiffies since boot time.

## Suspend the runtime at startup

By default, the runtime executes managed code as soon as it starts, regardless of whether any diagnostic tools have connected to the diagnostic port. Sometimes it's useful to have the runtime wait to run managed code until after a diagnostic tool is connected, to observe the initial program behavior. Setting environment variable `DOTNET_DefaultDiagnosticPortSuspend=1` causes the runtime to wait until a tool connects to the default port. If no tool is attached after several seconds, the runtime prints a warning message to the console explaining that it's still waiting for a tool to attach.

## Configure additional diagnostic ports

> [!NOTE]
> This works for apps running .NET 5 or later only.

Both the Mono and CoreCLR runtimes can use custom configured diagnostic ports in the `connect` role. These ports are in addition to the default port that remains available. There are a few common reasons this is useful:

- On Android, iOS, and tvOS there's no default port, so configuring a port is necessary to use diagnostic tools.
- In environments with containers or firewalls, you may want to set up a predictable endpoint address that doesn't vary based on process ID as the default port does. Then the custom port can be explicitly added to an allow list or proxied across some security boundary.
- For monitoring tools it is useful to have the tool listen on an endpoint, and the runtime actively attempts to connect to it. This avoids needing the monitoring tool to continuously poll for new apps starting. In environments where the default diagnostic port isn't accessible, it also avoids needing to configure the monitor with a custom endpoint for each monitored app.

In each communication channel between a diagnostic tool and the .NET runtime, one side needs to be the listener and wait for the other side to connect. The runtime can be configured to act in the `connect` role for any port. Ports can also be independently configured to suspend at startup, waiting for a diagnostic tool to issue a resume command. Ports configured to connect repeat their connection attempts indefinitely if the remote endpoint isn't listening or if the connection is lost. But the app does not automatically suspend managed code while waiting to establish that connection. If you want the app to wait for a connection to be established, use the suspend at startup option.

Custom ports are configured using the `DOTNET_DiagnosticPorts` environment variable. This variable should be set to a semicolon delimited list of port descriptions. Each port description consists of an endpoint address and optional modifiers that control whether the runtime should suspend on startup. On Windows, the endpoint address is the name of a named pipe without the `\\.\pipe\` prefix. On Linux and macOS, it's the full path to a Unix Domain Socket. On Android, iOS, and tvOS, the address is an IP and port. For example:

1. `DOTNET_DiagnosticPorts=my_diag_port1` - (Windows) The runtime connects to the named pipe `\\.\pipe\my_diag_port1`.
1. `DOTNET_DiagnosticPorts=/foo/tool1.socket;foo/tool2.socket` - (Linux and macOS) The runtime connects to both the Unix Domain Sockets `/foo/tool1.socket` and `/foo/tool2.socket`.
1. `DOTNET_DiagnosticPorts=127.0.0.1:9000` - (Android, iOS, and tvOS) The runtime connects to IP 127.0.0.1 on port 9000.
1. `DOTNET_DiagnosticPorts=/foo/tool1.socket,nosuspend` - (Linux and macOS) This example has the `nosuspend` modifier. The runtime tries to connect to Unix Domain Socket `/foo/tool1.socket` that an external tool creates. Additional diagnostic ports would normally cause the runtime to suspend at startup waiting for a resume command, but `nosuspend` causes the runtime not to wait.

The complete syntax for a port is `address[,(suspend|nosuspend)]`. `suspend` is the default if neither `suspend` or `nosuspend` is specified.

## Usage in dotnet diagnostic tools

Tools such as [dotnet-dump](./dotnet-dump.md), [dotnet-counters](./dotnet-counters.md), and [dotnet-trace](./dotnet-trace.md) all support `collect` or `monitor` verbs that communicate to a .NET app via the diagnostic port.

- When these tools use the `--processId` argument, the tool automatically computes the default diagnostic port address and connects to it.
- When specifying the `--diagnostic-port` argument, the tool listens at the given address and you should use the `DOTNET_DiagnosticPorts` environment variable to configure your app to connect. For a complete example with dotnet-counters, see [Using the Diagnostic Port](./dotnet-counters.md#using-diagnostic-port).

## Use ds-router to proxy the diagnostic port

All of the dotnet-* diagnostic tools expect to connect to a diagnostic port that's a local Named Pipe or Unix Domain Socket. Mono often runs on isolated hardware or in emulators that need a proxy over TCP to become accessible. The [dotnet-dsrouter tool](./dotnet-dsrouter.md) can proxy a local Named Pipe or Unix Domain Socket to TCP so that the tools can be used in those environments. For more information, see [dotnet-dsrouter](./dotnet-dsrouter.md).
