---
title: "Contention ETW Events"
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
  - "contention events [.NET Framework]"
  - "ETW, contention events (CLR)"
ms.assetid: 6933e753-2f2a-425b-ae84-42138c957d76
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Contention ETW Events
Contention events are raised whenever there is contention for <xref:System.Threading.Monitor?displayProperty=nameWithType> locks or native locks used by the runtime. Contention occurs when a thread is waiting for a lock while another thread possesses the lock.  
  
 The following table shows the keyword under which contention events are raised, and the level of the events. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStart_V1`|81|Contention starts. This event does not include the amount of spinning time before a thread waits to acquire a lock; it is raised only when the thread waits to acquire a lock.|  
|`ContentionStop`|81|Contention ends.|  
  
 The following table shows event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Flags|win:UInt8|0 for managed; 1 for native.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
