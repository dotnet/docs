---
title: System.Diagnostics.Tracing.EventWrittenEventArgs class
description: Learn about the System.Diagnostics.Tracing.EventWrittenEventArgs class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Diagnostics.Tracing.EventWrittenEventArgs class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Diagnostics.Tracing.EventWrittenEventArgs> class provides data for the <xref:System.Diagnostics.Tracing.EventListener.OnEventWritten%2A> callback.

Whenever an event is dispatched to an <xref:System.Diagnostics.Tracing.EventListener>, the <xref:System.Diagnostics.Tracing.EventListener.OnEventWritten%2A?displayProperty=nameWithType> callback method is invoked. It is passed an `EventWrittenEventArgs` instance that contains information associated with the event. All property values of the `EventWrittenEventArgs` class are valid only during the callback.

The following sections contain additional information about individual `EventWrittenEventArgs` properties.

## ActivityId property

When using <xref:System.Activities.Activity?displayProperty=nameWithType> and its derived classes, threads can be marked as having an activity associated with them. The `ActivityId` property returns the activity ID of the thread that logged the event. Note that threads do not have to have an activity, in which case this property returns <xref:System.Guid.Empty?displayProperty=nameWithType>.

## OSThreadId and TimeStamp properties

Starting with .NET Core 2.2, <xref:System.Diagnostics.Tracing.EventListener> objects can subscribe to native runtime events (such as GC, JIT, and threadpool events) in addition to events emitted by <xref:System.Diagnostics.Tracing.EventSource> objects. In previous versions of .NET Core and all versions of .NET Framework, the thread ID and timestamp can be gathered from the environment, because they are dispatched synchronously on the same thread that emitted them. Not all native runtime events can be dispatched synchronously, however. Some events, such as GC events, are emitted when managed thread execution is suspended. These events are buffered in native code and are dispatched by a dispatcher thread once managed code can execute again. Because these events are buffered, the environment cannot be used to reliably retrieve the thread ID and timestamp. Because of this, starting with .NET Core 2.2, thread ID and timestamp information are available as members of the `EventWrittenEventArgs` class.

## RelatedActivityId property

A related activity is an activity that is strongly related to the current one. Typically, it is either the activity that caused the current activity (events with the `Start` opcode typically do this) or an activity that was created by the current one (events with the `Send` opcode typically do this). When it is used, the `RelatedActivityID` is explicitly passed by the method doing the logging. Many events don't pass a `RelatedActivityId`, in which case this property returns <xref:System.Guid.Empty?displayProperty=nameWithType>.
