---
title: "Runtime Events"
description: Review events emitted by CoreCLR runtime.
ms.date: "09/14/2020"
ms.topic: reference
helpviewer_keywords: 
  - "runtime events [.NET Core]"
  - "ETW, EventPipe runtime events (CoreCLR)"
---
# .NET Core runtime events

For runtime events in .NET Framework, please refer to the [CLR ETW Events document](../../framework/performance/clr-etw-events.md).

## In This Section

 [Garbage Collection Events](runtime-garbage-collection-events.md)
 These events collect information pertaining to garbage collection. They help in diagnostics and debugging, including determining how many times garbage collection was performed, how much memory was freed during garbage collection, etc.

 [Exception Events](runtime-exception-events.md)
 These runtime events capture information about exceptions that are thrown.

 [Interop Events](runtime-interop-events.md)  
 These runtime events capture information about Common Intermediate Language (CIL) stub generation.

 [Loader and Binder Events](runtime-loader-binder-events.md)
 These events collect information relating to loading and unloading assemblies and modules.  

 [Method Events](runtime-method-events.md)
 These events collect information that is specific to methods. The payload of these events is required for symbol resolution. In addition, these events provide helpful information such as the number of times a method was called.

 [Thread Events](runtime-thread-events.md)
 These events collect information about worker and I/O threads.  

 [Type Events](runtime-type-events.md)
 These events collect information about the type system.
