---
title: "Runtime events"
description: Review diagnostic events emitted by .NET runtime (CoreCLR) that can be used with ETW, LTTng, or EventPipe.
ms.date: "11/13/2020"
helpviewer_keywords:
  - "runtime events (CoreCLR)"
  - "ETW, EventPipe runtime events (CoreCLR)"
---

# .NET runtime events

The .NET runtime (CoreCLR) emits various events that can be used to diagnose issues with your .NET application that can be consumed via various mechanisms such as `ETW`, `LTTng`, and `EventPipe`.

This document serves as a reference on the events that are fired by .NET Core runtime.

For runtime events in .NET Framework, see [CLR ETW Events](../../framework/performance/clr-etw-events.md).

## In this section

[Contention Events](runtime-contention-events.md)\
These events collect information about monitor lock contentions.

[Garbage Collection Events](runtime-garbage-collection-events.md)\
These events collect information pertaining to garbage collection. They help in diagnostics and debugging, including determining how many times garbage collection was performed, how much memory was freed during garbage collection, etc.

[Exception Events](runtime-exception-events.md)\
These runtime events capture information about exceptions that are thrown.

[Interop Events](runtime-interop-events.md)\
These runtime events capture information about Common Intermediate Language (CIL) stub generation.

[Loader and Binder Events](runtime-loader-binder-events.md)\
These events collect information relating to loading and unloading assemblies and modules.

[Method Events](runtime-method-events.md)\
These events collect information that is specific to methods. The payload of these events is required for symbol resolution. In addition, these events provide helpful information such as the number of times a method was called.

[Thread Events](runtime-thread-events.md)\
These events collect information about worker and I/O threads.

[Type Events](runtime-type-events.md)\
These events collect information about the type system.

[Tiered compilation events](runtime-tiered-compilation-events.md)\
These events collect information about tiered compilation.
