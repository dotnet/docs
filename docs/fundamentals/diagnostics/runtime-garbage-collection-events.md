---
title: "Garbage collection runtime events"
description: See .NET runtime events that collect diagnostic information specific to .NET garbage collector.
ms.date: "11/13/2020"
ms.topic: reference
helpviewer_keywords:
  - "GC events"
  - "garbage collection events (CoreCLR)"
  - "ETW, EventPipe, LTTng garbage collection events (CoreCLR)"
---
# .NET runtime garbage collection events

These events collect information pertaining to garbage collection. They help in diagnostics and debugging, including determining how many times garbage collection was performed, how much memory was freed during garbage collection, etc. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

## GCStart_V2 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCStart_V1`|1|A garbage collection has started.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Count`|`win:UInt32`|The *n*th garbage collection.|
|`Depth`|`win:UInt32`|The generation that is being collected.|
|`Reason`|`win:UInt32`|Why the garbage collection was triggered:<br /><br /> `0x0` - Small object heap allocation.<br /><br /> `0x1` - Induced.<br /><br /> `0x2` - Low memory.<br /><br /> `0x3` - Empty.<br /><br /> `0x4` - Large object heap allocation.<br /><br /> `0x5` - Out of space (for small object heap).<br /><br /> `0x6` - Out of space (for large object heap).<br /><br /> `0x7` - Induced but not forced as blocking.|
|`Type`|`win:UInt32`|`0x0` - Blocking garbage collection occurred outside background garbage collection.<br /><br /> `0x1` - Background garbage collection.<br /><br /> `0x2` - Blocking garbage collection occurred during background garbage collection.|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CoreCLR.|

## GCEnd_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCEnd_V1`|2|The garbage collection has ended.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Count`|`win:UInt32`|The *n*th garbage collection.|
|`Depth`|`win:UInt32`|The generation that was collected.|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CoreCLR.|

## GCHeapStats_V2 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`GCHeapStats_V2`|4|Shows the heap statistics at the end of each garbage collection.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`GenerationSize0`|`win:UInt64`|The size, in bytes, of generation 0 memory.|
|`TotalPromotedSize0`|`win:UInt64`|The number of bytes that are promoted from generation 0 to generation 1.|
|`GenerationSize1`|`win:UInt64`|The size, in bytes, of generation 1 memory.|
|`TotalPromotedSize1`|`win:UInt64`|The number of bytes that are promoted from generation 1 to generation 2.|
|`GenerationSize2`|`win:UInt64`|The size, in bytes, of generation 2 memory.|
|`TotalPromotedSize2`|`win:UInt64`|The number of bytes that survived in generation 2 after the last collection.|
|`GenerationSize3`|`win:UInt64`|The size, in bytes, of the large object heap.|
|`TotalPromotedSize3`|`win:UInt64`|The number of bytes that survived in the large object heap after the last collection.|
|`FinalizationPromotedSize`|`win:UInt64`|The total size, in bytes, of the objects that are ready for finalization.|
|`FinalizationPromotedCount`|`win:UInt64`|The number of objects that are ready for finalization.|
|`PinnedObjectCount`|`win:UInt32`|The number of pinned (unmovable) objects.|
|`SinkBlockCount`|`win:UInt32`|The number of synchronization blocks in use.|
|`GCHandleCount`|`win:UInt32`|The number of garbage collection handles in use.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`GenerationSize4`|`win:UInt64`|The size, in bytes, of the pinned object heap.|
|`TotalPromotedSize4`|`win:UInt64`|The number of bytes that survived in the pinned object heap after the last collection.|

## GCCreateSegment_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCCreateSegment_V1`|5|A new garbage collection segment has been created. In addition, when tracing is enabled on a process that is already running, this event is raised for each existing segment.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Address`|`win:UInt64`|The address of the segment.|
|`Size`|`win:UInt64`|The size of the segment.|
|`Type`|`win:UInt32`|0x0 - Small object heap.<br /><br /> 0x1 - Large object heap.<br /><br /> 0x2 - Read-only heap.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

Note that the size of segments allocated by the garbage collector is implementation-specific and is subject to change at any time, including in periodic updates. Your app should never make assumptions about or depend on a particular segment size, nor should it attempt to configure the amount of memory available for segment allocations.

## GCFreeSegment_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCFreeSegment_V1`|6|A garbage collection segment has been released.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Address`|`win:UInt64`|The address of the segment.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## GCRestartEEBegin_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCRestartEEBegin_V1`|7|Resumption from common language runtime suspension has begun.|

This event does not have any event data.

## GCRestartEEEnd_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event Id|Raised when|
|-----------|--------------|-----------------|
|`GCRestartEEEnd_V1`|3|Resumption from common language runtime suspension has ended.|

This event does not have any event data.

## GCSuspendEEEnd_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCSuspendEEEnd_V1`|8|End of suspension of the execution engine for garbage collection.|

This event does not have any event data.

## GCSuspendEEBegin_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCSuspendEEBegin_V1`|9|Start of suspension of the execution engine for garbage collection.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Count`|`win:UInt32`|The *n*th garbage collection.|
|`Reason`|`win:UInt32`|Reason for EE suspension.<br/><br/>`0x0`: Suspend for Other<br/><br/>`0x1`: Suspend for GC.<br/><br/>`0x2`: Suspend for AppDomain shutdown.<br/><br/>`0x3`: Suspend for code pitching.<br/><br/>`0x4`: Suspend for shutdown.<br/><br/>`0x5`: Suspend for debugger.<br/><br/>`0x6`: Suspend for GC Prep.<br/><br/>`0x7`: Suspend for debugger sweep|

## GCAllocationTick_V3 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Verbose (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCAllocationTick_V3`|10|Each time approximately 100 KB is allocated.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`AllocationAmount`|`win:UInt32`|The allocation size, in bytes. This value is accurate for allocations that are less than the length of a ULONG (4,294,967,295 bytes). If the allocation is greater, this field contains a truncated value. Use `AllocationAmount64` for very large allocations.|
|`AllocationKind`|`win:UInt32`|`0x0` - Small object allocation (allocation is in small object heap).<br /><br /> `0x1` - Large object allocation (allocation is in large object heap).|
|`AllocationAmount64`|`win:UInt64`|The allocation size, in bytes. This value is accurate for very large allocations.|
|`TypeId`|`win:Pointer`|The address of the MethodTable. When there are several types of objects that were allocated during this event, this is the address of the MethodTable that corresponds to the last object allocated (the object that caused the 100 KB threshold to be exceeded).|
|`TypeName`|`win:UnicodeString`|The name of the type that was allocated. When there are several types of objects that were allocated during this event, this is the type of the last object allocated (the object that caused the 100 KB threshold to be exceeded).|
|`HeapIndex`|`win:UInt32`|The heap where the object was allocated. This value is 0 (zero) when running with workstation garbage collection.|
|`Address`|`win:Pointer`|The address of the last allocated object.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## GCCreateConcurrentThread_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|
|`ThreadingKeyword` (0x10000)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCCreateConcurrentThread_V1`|11|Concurrent garbage collection thread was created.|

This event does not have any event data.

## GCTerminateConcurrentThread_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|
|`ThreadingKeyword` (0x10000)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCTerminateConcurrentThread_V1`|12|Concurrent garbage collection thread was terminated.|

This event does not have any event data.

## GCFinalizersBegin_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCFinalizersBegin_V1`|14|The start of running finalizers.|

This event does not have any event data.

## GCFinalizersEnd_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCFinalizersEnd_V1`|13|The end of running finalizers.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Count`|`win:UInt32`|The number of finalizers that were run.|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## SetGCHandle event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCHandleKeyword` (0x2)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`SetGCHandle`|30|A GC Handle has been set.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`HandleID`|`win:Pointer`|The address of the allocated handle.|
|`ObjectID`|`win:Pointer`|The address of the object whose handle was created.|
|`Kind`|`win:UInt32`|The type of GC handle that was set. <br /><br />`0x0`: WeakShort <br/><br/>`0x1`: WeakLong <br /><br />`0x2`: Strong <br /><br />`0x3`: Pinned <br /><br />`0x4`: Variable<br /><br />`0x5`: RefCounted <br /><br />`0x6`: Dependent<br /><br />`0x7`: AsyncPinned<br /><br />`0x8`: SizedRef|
|`Generation`|`win:UInt32`|The generation of the object whose handle was created.|
|`AppDomainID`|`win:UInt64`|The AppDomain ID.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## DestroyGCHandle event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCHandleKeyword` (0x2)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`DestroyGCHandle`|31|A GC Handle is destroyed.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`HandleID`|`win:Pointer`|The address of the destroyed handle.|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CoreCLR.|

## PinObjectAtGCTime event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Verbose (5)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`PinObjectAtGCTime`|33|An object was pinned during a GC.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`HandleID`|`win:Pointer`|The address of the handle.|
|`ObjectID`|`win:Pointer`|The address of the pinned object.|
|`ObjectSize`|`win:UInt64`|The size of the pinned object.|
|`TypeName`|`win:UnicodeString`|The name of the type of the pinned object.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## GCTriggered event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Verbose (5)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCTriggered`|35|A GC has been triggered.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Reason`|`win:UInt32`|The reason a GC was triggered.<br/><br/>`0x0`: AllocSmall<br/><br/>`0x1`: Induced <br/><br/>`0x2`: LowMemory <br/><br/>`0x3`: Empty <br/><br/>`0x4`: AllocLarge <br/><br/>`0x5`: OutOfSpaceSmallObjectHeap <br/><br/>`0x6`: OutOfSpaceLargeObjectHeap <br/><br/>`0x7`:InducedNoForce <br/><br/>`0x8`: Stress <br/><br/>`0x9`: InducedLowMemory|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## IncreaseMemoryPressure event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Information (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|----------------|---------------|-----------------|
|`IncreaseMemoryPressure`|200|Memory pressure was increased.|

The following table shows the event data:

|Field Name|Data type|Description|
|----------------|---------------|-----------------|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CoreCLR.|

## DecreaseMemoryPressure event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Information (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|----------------|---------------|-----------------|
|`DecreaseMemoryPressure`|201|Memory pressure was decreased.|

The following table shows the event data:

|Field Name|Data type|Description|
|----------------|---------------|-----------------|
|`BytesFreed`|`win:UInt32`|Bytes freed.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## GCMarkWithType event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Information (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|----------------|---------------|-----------------|
|`GCMarkWithType`|202|A GC root has been marked during GC mark phase.|

The following table shows the event data:

|Field Name|Data type|Description|
|----------------|---------------|-----------------|
|`HeapNum`|`win:UInt32`|The heap number.|
|`ClrInstanceID`|win:UInt16|Unique ID for the instance of CoreCLR.|
|`Type`|`win:UInt32`|The GC root type.<br/><br/>`0x0`: Stack<br/><br/>`0x1`: Finalizer<br/><br/>`0x2`: Handle<br/><br/>`0x3`: Older<br/><br/>`0x4`: SizedRef<br/><br/>`0x5`: Overflow<br/><br/>|
|`Bytes`|`win:UInt64`|The number of bytes marked.|

## GCJoin_V2 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Verbose (5)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCJoin_V2`|203|A GC thread joined.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Heap`|`win:UInt32`|The heap number|
|`JoinTime`|`win:UInt32`|Indicates whether this event is fired at the start of a join or end of a join (`0x0` for join start, `0x1` for join end)|
|`JoinType`|`win:UInt32`|The join type. <br/><br/>`0x0`: Last Join<br/><br/>`0x1`: Join <br/><br/>`0x2`: Restart <br/><br/>`0x3`: First Reverse Join<br/><br/>`0x4`: Reverse Join<br/><br/>|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
