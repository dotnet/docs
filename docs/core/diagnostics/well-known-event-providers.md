---
title: Well-known event providers in .NET
description: Review the providers and events published by the .NET runtime and libraries.
ms.topic: reference
ms.date: 12/21/2020
---

# Well-known event providers in .NET

The .NET runtime and libraries write diagnostic events through a number of different event providers. Depending on your diagnostic needs, you can choose the appropriate providers to enable. This article describes some of the most commonly used event providers in the .NET runtime and libraries.

## CoreCLR

### "Microsoft-Windows-DotNETRuntime" provider

This provider emits various events from the .NET runtime, including GC, loader, JIT, exception, and other events. Read more about each event from this provider in [Runtime Provider Events List](../../fundamentals/diagnostics/runtime-events.md).

### "Microsoft-DotNETCore-SampleProfiler" provider

This provider is a .NET runtime event provider that is used for CPU sampling for managed callstacks. When enabled, it captures a snapshot of each thread's managed callstack every 10 milliseconds. To enable this capture, you must specify an <xref:System.Diagnostics.Tracing.EventLevel> of `Informational` or higher.

## Framework libraries

### "Microsoft-Extensions-DependencyInjection" provider

This provider logs information from DependencyInjection. The following table shows events logged by the `Microsoft-Extensions-DependencyInjection` provider:

|Event name|Keyword|Level|Description|
|----------|-------|-----|-----------|
|`CallSiteBuilt`||Verbose (5)|A call site has been built.|
|`ServiceResolved`||Verbose (5)|A service has been resolved.|
|`ExpressionTreeGenerated`||Verbose (5)|An expression tree has been generated.|
|`DynamicMethodBuilt`||Verbose (5)|A <xref:System.Reflection.Emit.DynamicMethod> has been built.|
|`ScopeDisposed`||Verbose (5)|A scope has been disposed.|
|`ServiceRealizationFailed`||Verbose (5)|A service realization has failed.|
|`ServiceProviderBuilt`|`ServiceProviderInitialized(0x1)`|Verbose (5)|A <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> has been built.|
|`ServiceProviderDescriptors`|`ServiceProviderInitialized(0x1)`|Verbose (5)|A list of <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor> that has been used during the <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> build.|

### "System.Buffers.ArrayPoolEventSource" provider

This provider logs information from the ArrayPool. The following table shows the events logged by `ArrayPoolEventSource`:

|Event name|Level|Description|
|----------|-----|-----------|
|`BufferRented`|Verbose (5)|A buffer is successfully rented.|
|`BufferAllocated`|Informational (4)|A buffer is allocated by the pool.|
|`BufferReturned`|Verbose (5)|A buffer is returned to the pool.|
|`BufferTrimmed`|Informational (4)|A buffer is attempted to be freed due to memory pressure or inactivity.|
|`BufferTrimPoll`|Informational (4)|A check is being made to trim buffers.|

### "System.Net.Http" provider

This provider logs information from the HTTP stack. The following table shows the events logged by `System.Net.Http` provider:

|Event name|Level|Description|
|----------|-----|-----------|
|RequestStart|Informational (4)|An HTTP request has started.|
|RequestStop|Informational (4)|An HTTP request has finished.|
|RequestFailed|Error (2)|An HTTP request has failed.|
|ConnectionEstablished|Informational (4)|An HTTP connection has been established.|
|ConnectionClosed|Informational (4)|An HTTP connection has been closed.|
|RequestLeftQueue|Informational (4)|An HTTP request has left the request queue.|
|RequestHeadersStart|Informational (4)|An HTTP request for header has started.|
|RequestHeaderStop|Informational (4)|An HTTP request for header has finished.|
|RequestContentStart|Informational (4)|An HTTP request for content has started.|
|RequestContentStop|Informational (4)|An HTTP request for content has finished.|
|ResponseHeadersStart|Informational (4)|An HTTP response for header has started.|
|ResponseHeaderStop|Informational (4)|An HTTP response for header has finished.|
|ResponseContentStart|Informational (4)|An HTTP response for content has started.|
|ResponseContentStop|Informational (4)|An HTTP response for content has finished.|

### "System.Net.NameResolution" provider

This provider logs information related to domain name resolution. The following table shows the events logged by `System.Net.NameResolution`:

|Event name|Level|Description|
|----------|-----|-----------|
|`ResolutionStart`|Informational (4)|A domain name resolution has started.|
|`ResolutionStop`|Informational (4)|A domain name resolution has finished.|
|`ResolutionFailed`|Informational (4)|A domain name resolution has failed.|

### "System.Net.Sockets" provider

This provider logs information from <xref:System.Net.Sockets.Socket>. The following table shows the events logged by `System.Net.Sockets` provider:

|Event name|Level|Description|
|----------|-----|-----------|
|`ConnectStart`|Informational (4)|An attempt to start a socket connection has started.|
|`ConnectStop`|Informational (4)|An attempt to start a socket connection has finished.|
|`ConnectFailed`|Informational (4)|An attempt to start a socket connection has failed.|
|`AcceptStart`|Informational (4)|An attempt to accept a socket connection has started.|
|`AcceptStop`|Informational (4)|An attempt to accept a socket connection has finished.|
|`AcceptFailed`|Informational (4)|An attempt to accept a socket connection has failed.|

### "System.Threading.Tasks.TplEventSource" provider

This provider logs information on the [Task Parallel Library](../../standard/parallel-programming/task-parallel-library-tpl.md), such as Task scheduler events. The following table shows the events logged by `TplEventSource`:

|Event name|Keyword|Level|Description|
|----------|-------|-----|-----------|
|`TaskScheduled`|`TaskTransfer`(`0x1`)<br /><br />`Tasks`(`0x2`)|Informational (4)|A <xref:System.Threading.Tasks.Task> is queued to the Task scheduler.|
|`TaskStarted`|`Tasks`(`0x2`)|Informational (4)|A <xref:System.Threading.Tasks.Task> has started executing.|
|`TaskCompleted`|`TaskStops`(`0x40`)|Informational (4)|A <xref:System.Threading.Tasks.Task> has finished executing.|
|`TaskWaitBegin`|`TaskTransfer`(`0x1`)<br /><br />`TaskWait`(`0x2`)|Informational (4)|Fired when an implicit or an explicit wait on a <xref:System.Threading.Tasks.Task> completion has started.|
|`TaskWaitEnd`|`Tasks`(`0x2`)|Verbose (5)|Fired when the wait for a <xref:System.Threading.Tasks.Task> completion returns.|
|`TaskWaitContinuationStarted`|`Tasks`(`0x2`)|Verbose (5)|Fired when the work (method) associated with a `TaskWaitEnd` is started.|
|`TaskWaitContinuationCompleted`|`TaskStops`(`0x40`)|Verbose (5)|Fired when the work (method) associated with a `TaskWaitEnd` is completed.|
|`AwaitTaskContinuationScheduled`|`TaskTransfer`(`0x1`)<br /><br />`Tasks`(`0x2`)|Informational (4)|Fired when the an asynchronous continuation for a <xref:System.Threading.Tasks.Task> is scheduled.|

## ASP.NET Core

ASP.NET Core also provides several events to help you diagnose issues in the ASP.NET Core stack.

To learn more about the events in ASP.NET Core and how to consume them, see [Logging in .NET Core and ASP.NET Core](/aspnet/core/fundamentals/logging/).

## Entity Framework core

EF Core also provides events to help you diagnose issues in EF Core.

To learn more about the events in EF Core and how to consume them, see [.NET Events in EF Core](/ef/core/logging-events-diagnostics/events).
