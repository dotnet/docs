---
title: "Breaking change: 'dotnet watch' logs to stderr instead of stdout"
description: "Learn about the breaking change in .NET 10 where 'dotnet watch' emits its internal-facing log messages to stderr instead of stdout."
ms.date: 10/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45871
---
# 'dotnet watch' logs to stderr instead of stdout

Starting in .NET 10, [`dotnet watch`](../../../tools/dotnet-watch.md) emits its internal-facing log messages to the `stderr` channel instead of `stdout`. This change is part of a general trend towards `dotnet` CLI commands not obscuring the `stdout` channel. That channel is often reserved for special semantics when running certain kinds of applications, like LSP or MCP servers.

## Version introduced

.NET 10 RC 2

## Previous behavior

Previously, [`dotnet watch`](../../../tools/dotnet-watch.md) emitted log messages to `stdout`.

## New behavior

Starting in .NET 10, [`dotnet watch`](../../../tools/dotnet-watch.md) emits log messages to `stderr`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change is part of a general trend towards `dotnet` CLI commands not obscuring the `stdout` channel, which is often reserved or assumed to have special semantics when running certain kinds of applications, like LSP or MCP servers. In general, the .NET CLI should get out of the way of your applications.

## Recommended action

Most users shouldn't need to take any action. If you need the `dotnet watch` messages on `stdout`, you can redirect the `stderr` stream to `stdout`. For example, use `2>&1` to redirect the `2` file descriptor for `stderr` to the `1` file descriptor for `stdout`

## Affected APIs

None.
