---
title: "ETW Events in the Common Language Runtime"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "CLR ETW events"
  - "ETW, common language runtime"
  - "ETW, CLR events"
ms.assetid: 5bb9b6a2-7b57-4aea-8809-32b28bc73e88
author: "mairaw"
ms.author: "mairaw"
---
# ETW Events in the Common Language Runtime
The common language runtime (CLR) provides useful event tracing for Windows (ETW) diagnostic information through a large variety of debugging and profiling events. CLR ETW events leverage the Windows ETW tracing system to augment the existing profiling and debugging support provided by the common language runtime.  
  
 More information about ETW is available in the article [Improve Debugging and Performance Tuning with ETW](https://go.microsoft.com/fwlink/?LinkID=161142) on MSDN. Information about Xperf can be found in the entry [Windows Performance Toolkit - Xperf](https://go.microsoft.com/fwlink/?LinkID=161144) in the NTDebugging blog.  
  
 The .NET Framework 4 or later is required for all the events described in the event topics. The Windows Vista operating system is the minimum supported client, and Windows Server 2008 is the minimum supported server.  
  
## In This Section  
 [Controlling .NET Framework Logging](controlling-logging.md)  
 Describes the tools and commands for capturing and viewing ETW events.  
  
 [CLR ETW Providers](clr-etw-providers.md)  
 Provides information about the runtime and rundown providers, and how you can use them for ETW data collection.  
  
 [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md)  
 Describes the keywords for the Runtime and Rundown providers that enable the filtering of events by category.  
  
 [CLR ETW Events](clr-etw-events.md)  
 Provides detailed information about CLR ETW events, their keywords, levels, and event data.  
  
## See also

- [ETW Events in the .NET Framework](etw-events.md)
