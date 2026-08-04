---
title: "Breaking change: NativeAOT CLI command handling enabled by default"
description: "Learn about the breaking change in .NET 11 where the NativeAOT-compiled command-handling fast path for the dotnet CLI is enabled by default on all platforms."
ms.date: 08/04/2026
ai-usage: ai-assisted
---

# NativeAOT CLI command handling enabled by default

Starting in .NET 11, the .NET SDK CLI enables its NativeAOT-compiled command-handling fast path by default on all platforms. This path is controlled by the [`DOTNET_CLI_ENABLEAOT`](../../../tools/dotnet-environment-variables.md#dotnet_cli_enableaot) environment variable, whose default changes from disabled to enabled. Common `dotnet` invocations, such as command-line parsing, `--version`, `--info`, and a growing set of built-in and external commands, are handled by a native entry point that transparently falls back to the managed CLI for anything it doesn't handle.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, the NativeAOT CLI fast path was off by default on all platforms. Unless [`DOTNET_CLI_ENABLEAOT`](../../../tools/dotnet-environment-variables.md#dotnet_cli_enableaot) was explicitly set to a truthy value (`true`, `1`, `yes`, or `on`), every `dotnet` invocation was handled by the managed CLI.

## New behavior

Starting in .NET 11, the NativeAOT CLI fast path is on by default on all platforms (Windows, macOS, and Linux). Supported commands are handled natively, and anything unsupported transparently falls back to the managed CLI. To opt out and route every invocation to the managed CLI, set [`DOTNET_CLI_ENABLEAOT`](../../../tools/dotnet-environment-variables.md#dotnet_cli_enableaot) to a falsy value: `false`, `0`, `no`, or `off`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Now that the native command-handling path has reached parity with the managed CLI, enabling it by default provides broad real-world testing and improves CLI startup performance for common commands.

## Recommended action

The native path is designed to be behaviorally identical to the managed CLI and should require no action. If you observe a difference in behavior, set the environment variable [`DOTNET_CLI_ENABLEAOT=false`](../../../tools/dotnet-environment-variables.md#dotnet_cli_enableaot) (or `0`, `no`, or `off`) to opt out and route all invocations to the managed CLI. Report the difference at <https://github.com/dotnet/sdk/issues>.

## Affected APIs

None.
