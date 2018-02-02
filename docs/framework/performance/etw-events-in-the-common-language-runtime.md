---
title: "ETW Events in the Common Language Runtime"
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
ms.assetid: 5bb9b6a2-7b57-4aea-8809-32b28bc73e88
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ETW Events in the Common Language Runtime
The common language runtime (CLR) provides useful event tracing for Windows (ETW) diagnostic information through a large variety of debugging and profiling events. CLR ETW events leverage the Windows ETW tracing system to augment the existing profiling and debugging support provided by the common language runtime.  
  
 More information about ETW is available in the article [Improve Debugging and Performance Tuning with ETW](http://go.microsoft.com/fwlink/?LinkID=161142) on MSDN. Information about Xperf can be found in the entry [Windows Performance Toolkit - Xperf](http://go.microsoft.com/fwlink/?LinkID=161144) in the NTDebugging blog.  
  
 The [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] or later is required for all the events described in the event topics. The Windows Vista operating system is the minimum supported client, and Windows Server 2008 is the minimum supported server.  
  
## In This Section  
 [Controlling .NET Framework Logging](../../../docs/framework/performance/controlling-logging.md)  
 Describes the tools and commands for capturing and viewing ETW events.  
  
 [CLR ETW Providers](../../../docs/framework/performance/clr-etw-providers.md)  
 Provides information about the runtime and rundown providers, and how you can use them for ETW data collection.  
  
 [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md)  
 Describes the keywords for the Runtime and Rundown providers that enable the filtering of events by category.  
  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)  
 Provides detailed information about CLR ETW events, their keywords, levels, and event data.  
  
## See Also  
 [ETW Events in the .NET Framework](../../../docs/framework/performance/etw-events.md)
