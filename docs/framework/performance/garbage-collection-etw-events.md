---
title: "Garbage Collection ETW Events"
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
  - "GC events"
  - "garbage collection events [.NET Framework]"
  - "ETW, garbage collection events (CLR)"
ms.assetid: f14b6fd7-0966-4d87-bc89-54ef3a44a94a
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Garbage Collection ETW Events
<a name="top"></a> These events collect information pertaining to garbage collection. They help in diagnostics and debugging, including determining how many times garbage collection was performed, how much memory was freed during garbage collection, and so on.  
  
 This category consists of the following events:  
  
-   [GCStart_V1 Event](#gcstart_v1_event)  
  
-   [GCEnd_V1 Event](#gcend_v1_event)  
  
-   [GCHeapStats_V1 Event](#gcheapstats_v1_event)  
  
-   [GCCreateSegment_V1 Event](#gccreatesegment_v1_event)  
  
-   [GCFreeSegment_V1 Event](#gcfreesegment_v1_event)  
  
-   [GCRestartEEBegin_V1 Event](#gcrestarteebegin_v1_event)  
  
-   [GCRestartEEEnd_V1 Event](#gcrestarteeend_v1_event)  
  
-   [GCSuspendEE_V1 Event](#gcsuspendee_v1_event)  
  
-   [GCSuspendEEEnd_V1 Event](#gcsuspendeeend_v1_event)  
  
-   [GCAllocationTick_V2 Event](#gcallocationtick_v2_event)  
  
-   [GCFinalizersBegin_V1 Event](#gcfinalizersbegin_v1_event)  
  
-   [GCFinalizersEnd_V1 Event](#gcfinalizersend_v1_event)  
  
-   [GCCreateConcurrentThread_V1 Event](#gccreateconcurrentthread_v1_event)  
  
-   [GCTerminateConcurrentThread_V1 Event](#gcterminateconcurrentthread_v1_event)  
  
<a name="gcstart_v1_event"></a>   
## GCStart_V1 Event  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCStart_V1`|1|A garbage collection has started.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt32|The *n*th garbage collection.|  
|Depth|win:UInt32|The generation that is being collected.|  
|Reason|win:UInt32|Why the garbage collection was triggered:<br /><br /> 0x0 - Small object heap allocation.<br /><br /> 0x1 - Induced.<br /><br /> 0x2 - Low memory.<br /><br /> 0x3 - Empty.<br /><br /> 0x4 - Large object heap allocation.<br /><br /> 0x5 - Out of space (for small object heap).<br /><br /> 0x6 - Out of space (for large object heap).<br /><br /> 0x7 - Induced but not forced as blocking.|  
|Type|win:UInt32|0x0 - Blocking garbage collection occurred outside background garbage collection.<br /><br /> 0x1 - Background garbage collection.<br /><br /> 0x2 - Blocking garbage collection occurred during background garbage collection.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gcend_v1_event"></a>   
## GCEnd_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCEnd_V1`|2|The garbage collection has ended.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt32|The *n*th garbage collection.|  
|Depth|win:UInt32|The generation that was collected.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gcheapstats_v1_event"></a>   
## GCHeapStats_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`GCHeapStats_V1`|4|Shows the heap statistics at the end of each garbage collection.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|GenerationSize0|win:UInt64|The size, in bytes, of generation 0 memory.|  
|TotalPromotedSize0|win:UInt64|The number of bytes that are promoted from generation 0 to generation 1.|  
|GenerationSize1|win:UInt64|The size, in bytes, of generation 1 memory.|  
|TotalPromotedSize1|win:UInt64|The number of bytes that are promoted from generation 1 to generation 2.|  
|GenerationSize2|win:UInt64|The size, in bytes, of generation 2 memory.|  
|TotalPromotedSize2|win:UInt64|The number of bytes that survived in generation 2 after the last collection.|  
|GenerationSize3|win:UInt64|The size, in bytes, of the large object heap.|  
|TotalPromotedSize3|win:UInt64|The number of bytes that survived in the large object heap after the last collection.|  
|FinalizationPromotedSize|win:UInt64|The total size, in bytes, of the objects that are ready for finalization.|  
|FinalizationPromotedCount|win:UInt64|The number of objects that are ready for finalization.|  
|PinnedObjectCount|win:UInt32|The number of pinned (unmovable) objects.|  
|SinkBlockCount|win:UInt32|The number of synchronization blocks in use.|  
|GCHandleCount|win:UInt32|The number of garbage collection handles in use.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gccreatesegment_v1_event"></a>   
## GCCreateSegment_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCCreateSegment_V1`|5|A new garbage collection segment has been created. In addition, when tracing is enabled on a process that is already running, this event is raised for each existing segment.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Address|win:UInt64|The address of the segment.|  
|Size|win:UInt64|The size of the segment.|  
|Type|win:UInt32|0x0 - Small object heap.<br /><br /> 0x1 - Large object heap.<br /><br /> 0x2 - Read-only heap.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 Note that the size of segments allocated by the garbage collector is implementation-specific and is subject to change at any time, including in periodic updates. Your app should never make assumptions about or depend on a particular segment size, nor should it attempt to configure the amount of memory available for segment allocations.  
  
 [Back to top](#top)  
  
<a name="gcfreesegment_v1_event"></a>   
## GCFreeSegment_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCFreeSegment_V1`|6|A garbage collection segment has been released.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Address|win:UInt64|The address of the segment.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gcrestarteebegin_v1_event"></a>   
## GCRestartEEBegin_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCRestartEEBegin_V1`|7|Resumption from common language runtime suspension has begun.|  
  
 No event data.  
  
 [Back to top](#top)  
  
<a name="gcrestarteeend_v1_event"></a>   
## GCRestartEEEnd_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event Id|Raised when|  
|-----------|--------------|-----------------|  
|`GCRestartEEEnd_V1`|3|Resumption from common language runtime suspension has ended.|  
  
 No event data.  
  
 [Back to top](#top)  
  
<a name="gcsuspendee_v1_event"></a>   
## GCSuspendEE_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCSuspendEE_V1`|9|Start of suspension of the execution engine for garbage collection.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Reason|win:UInt16|0x0 - Other.<br /><br /> 0x1 - Garbage collection.<br /><br /> 0x2 - Application domain shutdown.<br /><br /> 0x3 - Code pitching.<br /><br /> 0x4 - Shutdown.<br /><br /> 0x5 - Debugger.<br /><br /> 0x6 - Preparation for garbage collection.|  
|Count|win:UInt32|The GC count at the time. Usually, you would see a subsequent GC Start event after this, and its Count would be this Count + 1 as we increase the GC index during a garbage collection.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gcsuspendeeend_v1_event"></a>   
## GCSuspendEEEnd_V1 Event  
 The following table shows the keyword and level:  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information:  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCSuspendEEEnd_V1`|8|End of suspension of the execution engine for garbage collection.|  
  
 No event data.  
  
 [Back to top](#top)  
  
<a name="gcallocationtick_v2_event"></a>   
## GCAllocationTick_V2 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCAllocationTick_V2`|10|Each time approximately 100 KB is allocated.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AllocationAmount|win:UInt32|The allocation size, in bytes. This value is accurate for allocations that are less than the length of a ULONG (4,294,967,295 bytes). If the allocation is greater, this field contains a truncated value. Use `AllocationAmount64` for very large allocations.|  
|AllocationKind|win:UInt32|0x0 - Small object allocation (allocation is in small object heap).<br /><br /> 0x1 - Large object allocation (allocation is in large object heap).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|AllocationAmount64|win:UInt64|The allocation size, in bytes. This value is accurate for very large allocations.|  
|TypeId|win:Pointer|The address of the MethodTable. When there are several types of objects that were allocated during this event, this is the address of the MethodTable that corresponds to the last object allocated (the object that caused the 100 KB threshold to be exceeded).|  
|TypeName|win:UnicodeString|The name of the type that was allocated. When there are several types of objects that were allocated during this event, this is the type of the last object allocated (the object that caused the 100 KB threshold to be exceeded).|  
|HeapIndex|win:UInt32|The heap where the object was allocated. This value is 0 (zero) when running with workstation garbage collection.|  
  
 [Back to top](#top)  
  
<a name="gcfinalizersbegin_v1_event"></a>   
## GCFinalizersBegin_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCFinalizersBegin_V1`|14|The start of running finalizers.|  
  
 No event data.  
  
 [Back to top](#top)  
  
<a name="gcfinalizersend_v1_event"></a>   
## GCFinalizersEnd_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCFinalizersEnd_V1`|13|The end of running finalizers.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt32|The number of finalizers that were run.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="gccreateconcurrentthread_v1_event"></a>   
## GCCreateConcurrentThread_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCCreateConcurrentThread_V1`|11|Concurrent garbage collection thread was created.|  
  
 No event data.  
  
 [Back to top](#top)  
  
<a name="gcterminateconcurrentthread_v1_event"></a>   
## GCTerminateConcurrentThread_V1 Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`GCKeyword` (0x1)|Informational (4)|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`GCTerminateConcurrentThread_V1`|12|Concurrent garbage collection thread was terminated.|  
  
 No event data.  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
