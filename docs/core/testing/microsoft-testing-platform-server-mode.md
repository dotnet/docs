---
title: Microsoft.Testing.Platform (MTP) server mode
description: Learn how tools and IDEs drive MTP test applications through JSON-RPC server mode.
author: Evangelink
ms.author: amauryleve
ms.date: 08/26/2026
ai-usage: ai-assisted
---

# Server mode

MTP server mode lets an editor, IDE, or other test tool launch a test application and drive discovery and execution through JSON-RPC. Use server mode when you build tooling around MTP. For normal command-line and CI runs, run the test application directly or use `dotnet test`.

Start the public JSON-RPC server with `--server` or `--server jsonrpc`.

> [!IMPORTANT]
> The .NET SDK uses a separate internal binary protocol through `--server dotnettestcli`. Don't pass that value yourself. `dotnet test` configures the transport and protocol arguments.

## Use the source-only client

Starting with MTP 2.4.0, the [Microsoft.Testing.Platform.ServerMode.Client.Sources](https://www.nuget.org/packages/Microsoft.Testing.Platform.ServerMode.Client.Sources) package supplies a canonical client for the JSON-RPC protocol. The package injects C# source into your project instead of adding a runtime assembly.

The source-only design provides:

- No runtime DLL or additional deployment dependency.
- Native AOT-compatible, reflection-free serialization.
- Protocol types and serialization code from the same repository as the MTP server.

The injected `MtpServerClient` and `IMtpServerClient` types can initialize a connection, discover tests, run tests, request server exit, and report test-node updates. The types remain `internal` to your assembly.

## Meet client requirements

Use C# 12 or later. The package sets `LangVersion` to `12.0` when your project doesn't specify a language version. It also supplies internal compatibility types for .NET Framework 4.6.2 and `netstandard2.0`.

Remove any hand-written copy of the MTP client before you add the package to avoid duplicate internal types.

## Choose connection behavior

Set `MtpServerClientOptions.IsStateful` to tell the server whether the client preserves state across requests:

- Leave the value `false` for a single discovery or execution request followed by exit.
- Set the value to `true` for an editor or IDE session that sends multiple requests over the same connection.

The client sends this setting through the experimental `capabilities.testing.isStateful` protocol capability.

## See also

- [Run and debug tests with MTP](microsoft-testing-platform-run-and-debug.md)
- [Build a test framework for MTP](microsoft-testing-platform-architecture-test-framework.md)
- [MTP JSON-RPC protocol](https://github.com/microsoft/testfx/blob/main/docs/mstest-runner-protocol/001-protocol-intro.md)
