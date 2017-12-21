---
title: "CLR ETW Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "CLR ETW events"
  - "ETW, common language runtime"
  - "ETW, CLR events"
ms.assetid: ef2b31c3-7426-43e7-9924-92339b96556d
caps.latest.revision: 45
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLR ETW Events
The topics in this section describe event tracing for Windows (ETW) events. Each event has an associated keyword and level, which are described in the [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md) topic. The CLR has two providers for the events:  
  
-   The runtime provider, which raises events depending on which keywords (categories of events) are enabled. The CLR runtime provider GUID is e13c0d23-ccbc-4e12-931b-d9cc2eee27e4.  
  
-   The rundown provider, which has special-purpose uses. The CLR rundown provider GUID is a669021c-c450-4609-a035-5af59af4df18.  
  
 For more information about the providers, see [CLR ETW Providers](../../../docs/framework/performance/clr-etw-providers.md).  
  
## In This Section  
 [Runtime Information Events](../../../docs/framework/performance/runtime-information-etw-events.md)  
 Captures information about the runtime, including the SKU, version number, the manner in which the runtime was activated, the command-line parameters it was started with, the GUID (if applicable), and other relevant information.  
  
 [Exception Thrown_V1 Event](../../../docs/framework/performance/exception-thrown-v1-etw-event.md)  
 Captures information about exceptions that are thrown.  
  
 [Contention Events](../../../docs/framework/performance/contention-etw-events.md)  
 Captures information about contention for monitor locks or native locks that the runtime uses.  
  
 [Thread Pool Events](../../../docs/framework/performance/thread-pool-etw-events.md)  
 Captures information about worker thread pools and I/O thread pools.  
  
 [Loader Events](../../../docs/framework/performance/loader-etw-events.md)  
 Captures information about loading and unloading application domains, assemblies, and modules.  
  
 [Method Events](../../../docs/framework/performance/method-etw-events.md)  
 Captures information about CLR methods for symbol resolution.  
  
 [Garbage Collection Events](../../../docs/framework/performance/garbage-collection-etw-events.md)  
 Captures information pertaining to garbage collection, to help in diagnostics and debugging.  
  
 [JIT Tracing Events](../../../docs/framework/performance/jit-tracing-etw-events.md)  
 Captures information about just-in-time (JIT) inlining and tail calls.  
  
 [Interop Events](../../../docs/framework/performance/interop-etw-events.md)  
 Captures information about Microsoft intermediate language (MSIL) stub generation and caching.  
  
 [ARM Events](../../../docs/framework/performance/application-domain-resource-monitoring-arm-etw-events.md)  
 Captures detailed diagnostic information about the state of an application domain.  
  
 [Security Events](../../../docs/framework/performance/security-etw-events.md)  
 Captures information about strong name and Authenticode verification.  
  
 [Stack Event](../../../docs/framework/performance/stack-etw-event.md)  
 Captures information that is used with other events to generate stack traces after an event is raised.  
  
## See Also  
 [Improve Debugging And Performance Tuning With ETW](http://go.microsoft.com/fwlink/?LinkId=179696)  
 [Windows Performance Blog](http://go.microsoft.com/fwlink/?LinkId=179509)  
 [Controlling .NET Framework Logging](../../../docs/framework/performance/controlling-logging.md)  
 [CLR ETW Providers](../../../docs/framework/performance/clr-etw-providers.md)  
 [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md)  
 [ETW Events in the Common Language Runtime](../../../docs/framework/performance/etw-events-in-the-common-language-runtime.md)
