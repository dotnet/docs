---
title: EventSource
description: A guide to logging with EventSource
ms.date: 02/17/2022
---
# EventSource

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

<xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType> is a fast structured logging solution
built into the .NET runtime. On .NET Framework EventSource can send events to
[Event Tracing for Windows (ETW)](/windows/win32/etw/event-tracing-portal) and
<xref:System.Diagnostics.Tracing.EventListener?displayProperty=nameWithType>. On .NET Core EventSource
additionally supports [EventPipe](./eventpipe.md), a cross-platform tracing option. Most often developers use EventSource
logs for performance analysis, but EventSource can be used for any diagnostic tasks where logs are useful.
The .NET runtime is already instrumented with [built-in events](./well-known-event-providers.md) and you can log
your own custom events.

> [!NOTE]
> Many technologies that integrate with EventSource use the terms 'Tracing' and 'Traces' instead of 'Logging' and 'Logs'.
> The meaning is the same here.

> [!WARNING]
> Potential Deadlocks with EventSource Callbacks
>
> When implementing EventSources, be cautious with invoking lock-acquiring APIs within EventSource callbacks. EventSource instances are initialized early in the runtime, before some core features are fully initialized. As a result, the re-entrant behavior of EventSource callbacks may cause deadlocks if the callback attempts to acquire locks already held by the thread that triggered the callback.
>
> To mitigate this risk, consider the following precautions:
>
> - **Avoid Complex Operations**: Refrain from performing complex operations within the callback that might acquire additional locks.
> - **Minimize Lock Duration**: Ensure that any locks acquired within the callback are not held for extended periods.
> - **Use Non-blocking APIs**: Prefer using non-blocking APIs within the callback to avoid potential deadlocks.

- [Getting started](./eventsource-getting-started.md)
- [Instrumenting code to create events](./eventsource-instrumentation.md)
- [Collecting and viewing event traces](./eventsource-collect-and-view-traces.md)
- [Understanding Activity IDs](./eventsource-activity-ids.md)
