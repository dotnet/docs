---
title: "Breaking change: BackgroundService runs all of ExecuteAsync as a Task"
description: "Learn about the breaking change in .NET 10 where BackgroundService now runs the entirety of ExecuteAsync on a background thread instead of running the synchronous portion on the main thread."
ms.date: 10/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/runtime/issues/116181
---

# BackgroundService runs all of ExecuteAsync as a Task

<xref:Microsoft.Extensions.Hosting.BackgroundService> now runs the entirety of <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A> on a background thread. Previously, the synchronous portion of `ExecuteAsync` (before the first `await`) ran on the main thread during service startup, blocking other services from starting. Only code after the first `await` ran on a background thread.

## Version introduced

.NET 10

## Previous behavior

Previously, the synchronous portion of `ExecuteAsync` ran on the main thread and blocked other services from starting.

## New behavior

Starting in .NET 10, all of `ExecuteAsync` runs on a background thread, and no part of it blocks other services from starting.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was a common pitfall that didn't meet user expectations. Most implementers of `BackgroundService` didn't understand that the synchronous portion before the first `await` blocked other services from starting during application startup.

## Recommended action

If you require any part of your `BackgroundService.ExecuteAsync` to run earlier during startup (synchronously and blocking other services), you can do any one of the following:

- Place the code that needs to run synchronously in the constructor, and it executes as part of the service construction.
- Override `StartAsync` and do some work before calling `base.StartAsync`. `StartAsync` retains the behavior that its synchronous portion runs synchronously during startup and blocks other services from starting.
- If you want to run code at a more specific time during service startup, implement <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService?displayProperty=fullName> on your `BackgroundService`.
- Forgo `BackgroundService` entirely and implement your own <xref:Microsoft.Extensions.Hosting.IHostedService?displayProperty=fullName>.

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A?displayProperty=fullName>
