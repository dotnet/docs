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

## Usage in dotnet diagnostic tools

Tools such as [dotnet-dump](./dotnet-dump.md), [dotnet-counters](./dotnet-counters.md), and [dotnet-trace](./dotnet-trace.md) all support `collect` or `monitor` verbs that communicate to a .NET app via the diagnostic port.

- When these tools use the `--processId` argument, the tool automatically computes the default diagnostic port address and connects to it.
- When specifying the `--diagnostic-port` argument, the tool listens at the given address and you should use the `DOTNET_DiagnosticPorts` environment variable to configure your app to connect. For a complete example with dotnet-counters, see [Using the Diagnostic Port](./dotnet-counters.md#using-diagnostic-port).

## Use ds-router to proxy the diagnostic port

All of the dotnet-* diagnostic tools expect to connect to a diagnostic port that's a local Named Pipe or Unix Domain Socket. Mono often runs on isolated hardware or in emulators that need a proxy over TCP to become accessible. The [dotnet-dsrouter tool](./dotnet-dsrouter.md) can proxy a local Named Pipe or Unix Domain Socket to TCP so that the tools can be used in those environments. For more information, see [dotnet-dsrouter](./dotnet-dsrouter.md).
