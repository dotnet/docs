---
title: "CLR ETW Providers"
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
  - "ETW, CLR providers"
  - "CLR ETW providers"
ms.assetid: 0beafad4-b2c8-47f4-b342-83411d57a51f
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLR ETW Providers
The common language runtime (CLR) has two providers: the runtime provider and the rundown provider.  
  
 The runtime provider raises events, depending on which keywords (categories of events) are enabled. For example, you can collect loader events by enabling the `LoaderKeyword` keyword.  
  
 Event tracking for Windows (ETW) events are logged into a file that has an .etl extension, which can later be post-processed in comma-separated value (.csv) files as needed. For information about how to convert the .etl file to a .csv file, see [Controlling .NET Framework Logging](../../../docs/framework/performance/controlling-logging.md).  
  
## The Runtime Provider  
 The runtime provider is the main CLR ETW provider.  
  
 The CLR runtime provider GUID is e13c0d23-ccbc-4e12-931b-d9cc2eee27e4.  
  
 For examples of how to log and view CLR ETW events by using commonly available tools, see [Controlling .NET Framework Logging](../../../docs/framework/performance/controlling-logging.md).  
  
 In addition to using keywords such as `LoaderKeyword`, you may have to enable keywords for logging events that may be raised too frequently. The `StartEnumerationKeyword` and the `EndEnumerationKeyword` keywords enable these events and are summarized in [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).  
  
## The Rundown Provider  
 The rundown provider must be turned on for certain special-purpose uses. However, for a majority of users, the runtime provider should suffice.  
  
 The CLR rundown provider GUID is A669021C-C450-4609-A035-5AF59AF4DF18.  
  
 Normally, ETW logging is enabled before a process launches, and the logging is turned off after the process exits. However, if ETW logging is turned on while the process is executing, additional information is needed about the process. For example, for symbol resolution you have to log method events for methods that were already loaded before logging was turned on.  
  
 The `DCStart` and `DCEnd` events capture the state of the process when data collection was started and stopped. (State refers to information at a high level, including the methods that were already just-in-time (JIT) compiled and assemblies that were loaded.) These two events can provide information about what has already happened in the process; for example, which methods were JIT- compiled, and so on.  
  
 Only the events with `DC`, `DCStart`, `DCEnd`, or `DCInit` in their names are raised under the rundown provider. Additionally, these events are raised only under the rundown provider.  
  
 In addition to the event keyword filters, the rundown provider also supports the `StartRundownKeyword` and `EndRundownKeyword` keywords to provide targeted filtering.  
  
### Start Rundown  
 A start rundown is triggered when logging under the rundown provider is enabled with the `StartRundownKeyword` keyword. This causes the `DCStart` event to be raised, and captures the state of the system. Before the start of the enumeration, the `DCStartInit` event is raised. At the end of the enumeration, the `DCStartComplete` event is raised to notify the controller that data collection terminated normally.  
  
### End Rundown  
 An end rundown is triggered when logging under the rundown provider is enabled with the `EndRundownKeyword` keyword. End rundown stops profiling on a process that continues to execute. The `DCEnd` events capture the state of the system when profiling is stopped.  
  
 Before the start of the enumeration, the `DCEndInit` event is raised. At the end of the enumeration, the `DCEndComplete` event is raised to notify the consumer that data collection terminated normally. Start rundown and end rundown are primarily used for managed symbol resolution. Start rundown can provide address range information for methods that were already JIT-compiled before the profiling session was started. End rundown can provide address range information for all methods that have been JIT-compiled when profiling is about to be turned off.  
  
 End rundown does not happen automatically when a profiling session is stopped. Instead, a tool that is seeking to perform managed symbol resolution has to explicitly invoke a CLR rundown provider session with the `EndRundownKeyword` keyword enabled, just before profiling is stopped.  
  
 Although either start rundown or end rundown can provide method address range information for managed symbol resolution, we recommend that you use the `EndRundownKeyword` keyword (which supplies `DCEnd` events) instead of the `StartRundownKeyword` keyword (which supplies `DCStart` events). Using `StartRundownKeyword` causes the rundown to happen during the profiling session, which may disturb the profiled scenario.  
  
## ETW Data Collection Using Runtime and Rundown Providers  
 The following example demonstrates how to use the CLR rundown provider in a way that allows symbol resolution of managed processes with minimal impact, regardless of whether the processes start or end inside or outside the profiled window.  
  
1.  Turn on ETW logging by using the CLR runtime provider:  
  
    ```  
    xperf -start clr -on e13c0d23-ccbc-4e12-931b-d9cc2eee27e4:0x1CCBD:0x5 -f clr1.etl      
    ```  
  
     The log will be saved to the clr1.etl file.  
  
2.  To stop profiling while the process continues to execute, start the rundown provider to capture the `DCEnd` events:  
  
    ```  
    xperf -start clrRundown -on A669021C-C450-4609-A035-5AF59AF4DF18:0xB8:0x5 -f clr2.etl      
    ```  
  
     This enables the collection of `DCEnd` events to start a rundown session. You may need to wait 30 to 60 seconds for all events to be collected. The log will be saved to the clr1.et2 file.  
  
3.  Turn off all ETW profiling:  
  
    ```  
    xperf -stop clrRundown   
    xperf -stop clr  
    ```  
  
4.  Merge the profiles to create one log file:  
  
    ```  
    xperf -merge -d clr1.etl clr2.etl merged.etl  
    ```  
  
     The merged.etl file will contain the events from the runtime and the rundown provider sessions.  
  
 A tool can execute steps 2 and 3 (starting a rundown session and then terminating profiling) instead of immediately turning off profiling when a user requests profiling to be stopped. A tool can also execute step 4.  
  
## See Also  
 [ETW Events in the Common Language Runtime](../../../docs/framework/performance/etw-events-in-the-common-language-runtime.md)
