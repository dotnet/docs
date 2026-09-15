---
title: Microsoft.Testing.Platform (MTP) server mode
description: Learn how tools and IDEs drive MTP test applications through JSON-RPC server mode.
author: Evangelink
ms.author: amauryleve
ms.date: 09/02/2026
ai-usage: ai-assisted
---

# Server mode

MTP server mode lets an editor, IDE, or other test tool launch a test application and drive discovery and execution through JSON-RPC. Use server mode when you build tooling around MTP. For normal command-line and CI runs, run the test application directly or use `dotnet test`.

Start the public JSON-RPC server with `--server` or `--server jsonrpc`.

> [!IMPORTANT]
> The .NET SDK uses a separate internal binary protocol through `--server dotnettestcli`. Don't pass that value yourself. `dotnet test` configures the transport and protocol arguments.

## Use the source-only client

The MTP 2.4 preview provides a canonical JSON-RPC client. Add the [Microsoft.Testing.Platform.ServerMode.Client.Sources](https://www.nuget.org/packages/Microsoft.Testing.Platform.ServerMode.Client.Sources) package. The package injects C# source into your project instead of adding a runtime assembly.

The source-only design provides:

- No runtime DLL or additional deployment dependency.
- Native AOT-compatible, reflection-free serialization.
- Protocol types and serialization code from the same repository as the MTP server.

The injected `MtpServerClient`, `IMtpServerClient`, and protocol types can initialize a connection, discover tests, run tests, request server exit, and report test-node updates. All injected types remain `internal` to the consuming assembly.

## Meet client requirements

Use C# 12 or later. The package sets `LangVersion` to `12.0` when your project doesn't specify a language version. It also supplies internal compatibility types for .NET Framework 4.6.2 and `netstandard2.0`.

Remove any hand-written copy of the MTP client before you add the package to avoid duplicate internal types.

## Choose a launch model

To start the test application as an external process, use `MtpServerClient.LaunchAsync`. The client owns that child process and terminates it during teardown when needed.

For an embedded host or UI-thread environment that can't use `Process.Start`, use `MtpServerClient.LaunchInProcessAsync`. The method runs the test application through an asynchronous callback in the current process. Don't block the launching thread because the callback and client share the process.

Both launch models use a loopback TCP transport. Browser WebAssembly can't create the required listener, so in-process launch throws <xref:System.PlatformNotSupportedException>. In-process launch doesn't provide an alternative WebAssembly transport.

## Shut down the client

To tear down the client and launched application without blocking the calling thread, call `IMtpServerClient.ShutdownAsync()`. The asynchronous method avoids UI-thread responsiveness and deadlock problems in embedded hosts.

For an in-process host, `MtpServerClientOptions.ServerShutdownTimeout` controls how long teardown waits after the client closes the transport. The default is 30 seconds. Read `ServerExitCode` after shutdown to get the callback's exit code. The value remains `null` while the application runs or when the application fails instead of returning an exit code.

## Choose connection behavior

Set `MtpServerClientOptions.IsStateful` to tell the server whether the client preserves state across requests:

- Leave the value `false` for a single discovery or execution request followed by exit.
- Set the value to `true` for an editor or IDE session that sends multiple requests over the same connection.

The client sends this setting through the experimental `capabilities.testing.isStateful` protocol capability.

## See also

- [Run and debug tests with MTP](microsoft-testing-platform-run-and-debug.md)
- [Build a test framework for MTP](microsoft-testing-platform-architecture-test-framework.md)
- [MTP JSON-RPC protocol](https://github.com/microsoft/testfx/blob/main/docs/mstest-runner-protocol/001-protocol-intro.md)
