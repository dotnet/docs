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

- [Getting started](./eventsource-getting-started.md)
- [Instrumenting code to create events](./eventsource-instrumentation.md)
- [Collecting and viewing event traces](./eventsource-collect-and-view-traces.md)
- [Understanding Activity IDs](./eventsource-activity-ids.md)
