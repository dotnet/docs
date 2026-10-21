---
title: "Breaking change - CoreCLR trace events replace Mono trace events"
description: "Learn about the breaking change in .NET 11 where CoreCLR trace events replace Mono trace events."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56483
---

# CoreCLR trace events replace Mono trace events

In .NET 11, CoreCLR trace events replace Mono trace events.

## Version introduced

.NET 11

## Previous behavior

Mobile trace and profiler tools could request Mono events. Some tools used the
Mono-only `Microsoft-DotNETRuntimeMonoProfiler` provider for method enter and
leave tracing.

Mono EventPipe was a separate component. Mobile Release builds could leave that
component out.

## New behavior

`dotnet-trace` and `.nettrace` files remain supported.
[dotnet-dsrouter](../../../diagnostics/dotnet-dsrouter.md)
can connect the mobile diagnostic port over TCP.

CoreCLR events replace the smaller set of Mono events. A provider with the same
name might still use different event IDs, data, ordering, or stack information.
CoreCLR doesn't provide the `Microsoft-DotNETRuntimeMonoProfiler` provider.

EventPipe should otherwise work in the same way for most users. CoreCLR
diagnostics are part of the mobile runtime, but diagnostics must be enabled when
the app is built. Set `EnableDiagnostics=true` to enable diagnostics.

See [Tracing .NET for Android applications](https://github.com/dotnet/android/blob/main/Documentation/guides/tracing.md)
and the
[Apple `EnableDiagnostics` build property](/dotnet/ios/building-apps/build-properties#enablediagnostics).

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility), [binary compatibility](../../categories.md#binary-compatibility), and [behavior](../../categories.md#behavioral-change).

## Reason for change

CoreCLR and Mono provide different runtime events and profiler features.

## Recommended action

- Test custom trace tools with the documented
  [runtime events](../../../../fundamentals/diagnostics/runtime-events.md)
  and
  [well-known providers](../../../diagnostics/well-known-event-providers.md).
- Stop requesting `Microsoft-DotNETRuntimeMonoProfiler`.

## Affected APIs

The `Microsoft-DotNETRuntimeMonoProfiler` EventPipe provider and Mono event
schemas.
