---
title: "Runtime Events"
description: Review events emitted by CoreCLR runtime, which include #TODO.
ms.date: "09/14/2020"
helpviewer_keywords: 
  - "loader events [.NET Core]"
  - "ETW, EventPipe loader events (CoreCLR)"
---
# .NET Core runtime events

For runtime events in .NET Framework, please refer to the [CLR ETW Events document](../../framework/performance/clr-etw-events.md).


## In This Section  
 [Runtime Information Events](runtime-information-etw-events.md)  
 Captures information about the runtime, including the SKU, version number, the manner in which the runtime was activated, the command-line parameters it was started with, the GUID (if applicable), and other relevant information.  
  
 [Exception Thrown_V1 Event](exception-thrown-v1-etw-event.md)  
 Captures information about exceptions that are thrown.  
  
 [Contention Events](contention-etw-events.md)  
 Captures information about contention for monitor locks or native locks that the runtime uses.  
  
 [Thread Pool Events](thread-pool-etw-events.md)  
 Captures information about worker thread pools and I/O thread pools.  
  
 [Loader Events](loader-etw-events.md)  
 Captures information about loading and unloading application domains, assemblies, and modules.  
  
 [Method Events](method-etw-events.md)  
 Captures information about CLR methods for symbol resolution.  
  
 [Garbage Collection Events](garbage-collection-etw-events.md)  
 Captures information pertaining to garbage collection, to help in diagnostics and debugging.  
  
 [JIT Tracing Events](jit-tracing-etw-events.md)  
 Captures information about just-in-time (JIT) inlining and tail calls.  
  
 [Interop Events](interop-etw-events.md)  
 Captures information about Microsoft intermediate language (MSIL) stub generation and caching.  
  
 [ARM Events](application-domain-resource-monitoring-arm-etw-events.md)  
 Captures detailed diagnostic information about the state of an application domain.  
  
 [Security Events](security-etw-events.md)  
 Captures information about strong name and Authenticode verification.  
  
 [Stack Event](stack-etw-event.md)  
 Captures information that is used with other events to generate stack traces after an event is raised.  
  
## Runtime Information Events
These runtime events log information about the runtime, including the SKU, version number, the manner in which the runtime was activated, the command-line parameters it was started with, the GUID (if applicable), and other relevant information. If multiple runtimes are executing within a process, the information provided by these events (the ClrInstanceID) helps disambiguate the runtimes.  
  
 The following table shows the two runtime information events. The events can be raised under any keyword or mask. (For more information, see [CLR ETW Keywords and Levels](coreclr-etw-keywords-and-levels.md).)  

## TODO: IMPORT THIS!!!!!!!^^^^^

|Event|Event ID|Provider|Description|  
|-----------|--------------|--------------|-----------------|  
|`RuntimeInformationEvent`|187|CLRRuntime|Raised when a runtime is loaded.|  
|`RuntimeInformationDCStart`|187|CLRRundown|Enumerates the runtimes that are loaded.|  
  
 The following table shows event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|  
|Sku|win:UInt16|1 – Framework CLR.<br /><br /> 2 – CoreCLR.|  
|BclVersion – Major Version|win:UInt16|Major version of System.Private.CoreLib.dll.|  
|BclVersion – Minor Version|win:UInt16|Minor version number of System.Private.CoreLib.dll.|  
|BclVersion – Build Number|win:UInt16|Build number of System.Private.CoreLib.dll|  
|BclVersion – QFE|win:UInt16|Hotfix version number of System.Private.CoreLib.dll.|  
|VMVersion – Major Version|win:UInt16|Version of coreclr.dll, depending on SKU.|  
|VMVersion – Minor Version|win:UInt16|Minor version of coreclr.dll, depending on SKU.|  
|VMVersion – Build Number|win:UInt16|Build number of coreclr.dll.|  
|VMVersion – QFE|win:UInt16|Hotfix version number of coreclr.dll.|  
|StartupFlags|win:UInt32|Startup flags defined in mscoree.h.|  
|StartupMode|win:UInt8|0x01 - Managed executable.<br /><br /> 0x02 - Hosted CLR.<br /><br /> 0x04 - C++ managed interop.<br /><br /> 0x08 - COM-activated.<br /><br /> 0x10 - Other.|  
|CommandLine|win:UnicodeString|Non-null only if StartupMode=0x01.|  
|ComObjectGUID|win:GUID|Non-null only if StartupMode=0x08.| 
|RuntimeDLLPath|win:UnicodeString|Path to the coreclr.dll file that was loaded into the process.|  


## Garbage Collection Events

These events collect information pertaining to garbage collection. They help in diagnostics and debugging, including determining how many times garbage collection was performed, how much memory was freed during garbage collection, and so on.

### GCStart_V2 Event
The following table shows the keyword and level. For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md).

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
|Count|win:UInt32|The *n*th garbage collection.|
|Depth|win:UInt32|The generation that is being collected.|
|Reason|win:UInt32|Why the garbage collection was triggered:<br /><br /> 0x0 - Small object heap allocation.<br /><br /> 0x1 - Induced.<br /><br /> 0x2 - Low memory.<br /><br /> 0x3 - Empty.<br /><br /> 0x4 - Large object heap allocation.<br /><br /> 0x5 - Out of space (for small object heap).<br /><br /> 0x6 - Out of space (for large object heap).<br /><br /> 0x7 - Induced but not forced as blocking.|
|Type|win:UInt32|0x0 - Blocking garbage collection occurred outside background garbage collection.<br /><br /> 0x1 - Background garbage collection.<br /><br /> 0x2 - Blocking garbage collection occurred during background garbage collection.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### GCEnd_V1 Event

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
|Count|win:UInt32|The *n*th garbage collection.|
|Depth|win:UInt32|The generation that was collected.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### GCRestartEEEnd_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event Id|Raised when|
|-----------|--------------|-----------------|
|`GCRestartEEEnd_V1`|3|Resumption from common language runtime suspension has ended.|

This event does not have any event data.


### GCHeapStats_V2 Event

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
|GenerationSize4|win:UInt64|The size, in bytes, of the pinned object heap.|
|TotalPromotedSize4|win:UInt64|The number of bytes that survived in the pinned object heap after the last collection.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### GCCreateSegment_V1 Event

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
|Address|win:UInt64|The address of the segment.|
|Size|win:UInt64|The size of the segment.|
|Type|win:UInt32|0x0 - Small object heap.<br /><br /> 0x1 - Large object heap.<br /><br /> 0x2 - Read-only heap.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

Note that the size of segments allocated by the garbage collector is implementation-specific and is subject to change at any time, including in periodic updates. Your app should never make assumptions about or depend on a particular segment size, nor should it attempt to configure the amount of memory available for segment allocations.

### GCFreeSegment_V1 Event

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
|Address|win:UInt64|The address of the segment.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### GCRestartEEBegin_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCRestartEEBegin_V1`|7|Resumption from common language runtime suspension has begun.|

This event does not have any event data.


### GCSuspendEEEnd_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCSuspendEEEnd_V1`|8|End of suspension of the execution engine for garbage collection.|

This event does not have any event data.

### GCSuspendEEBegin_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCSuspendEEBegin_V1`|8|Start of suspension of the execution engine for garbage collection.|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Count|win:UInt32|The *n*th garbage collection.|
|Reason|win:UInt32|Reason for EE suspension.<br/><br/>0: Suspend for Other<br/><br/>1: Suspend for GC.<br/><br/>2: Suspend for AppDomain shutdown.<br/><br/>3: Suspend for code pitching.<br/><br/>4: Suspend for shutdown.<br/><br/>5: Suspend for debugger.<br/><br/>6: Suspend for GC Prep.<br/><br/>7: Suspend for debugger sweep|

### GCAllocationTick_V3 Event

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
|AllocationAmount|win:UInt32|The allocation size, in bytes. This value is accurate for allocations that are less than the length of a ULONG (4,294,967,295 bytes). If the allocation is greater, this field contains a truncated value. Use `AllocationAmount64` for very large allocations.|
|AllocationKind|win:UInt32|0x0 - Small object allocation (allocation is in small object heap).<br /><br /> 0x1 - Large object allocation (allocation is in large object heap).|
|AllocationAmount64|win:UInt64|The allocation size, in bytes. This value is accurate for very large allocations.|
|TypeId|win:Pointer|The address of the MethodTable. When there are several types of objects that were allocated during this event, this is the address of the MethodTable that corresponds to the last object allocated (the object that caused the 100 KB threshold to be exceeded).|
|TypeName|win:UnicodeString|The name of the type that was allocated. When there are several types of objects that were allocated during this event, this is the type of the last object allocated (the object that caused the 100 KB threshold to be exceeded).|
|HeapIndex|win:UInt32|The heap where the object was allocated. This value is 0 (zero) when running with workstation garbage collection.|
|Address|win:Pointer|The address of the last allocated object.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### GCCreateConcurrentThread_V1 Event

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

### GCTerminateConcurrentThread_V1 Event

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

### GCFinalizersEnd_V1 Event

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
|Count|win:UInt32|The number of finalizers that were run.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

### GCFinalizersBegin_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`GCKeyword` (0x1)|Informational (4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`GCFinalizersBegin_V1`|14|The start of running finalizers.|

This event does not have any event data.

### BulkType Event

// Fire an ETW event for all the types we batched so far, and then reset our state
// so we can start batching new types at the beginning of the array.




## Exception Events
These runtime events capture information about exceptions that are thrown.

This category consists of the following events:

- [ExceptionThrown_V1 Event](#exceptionthrown_v1-event)
- [ExceptionCatchStart Event](#exceptioncatchstart-event)
- [ExceptionCatchStop Event](#exceptioncatchstop-event)
- [ExceptionFinallyStart Event](#exceptionfinallystart-event)
- [ExceptionFinallyStop Event](#exceptionfinallystop-event)
- [ExceptionFilterStart Event](#exceptionfilterstart-event)
- [ExceptionFilterStop Event](#exceptionfilterstop-event)
- [ExceptionThrownStop Event](#exceptionthrownstop-event)

### ExceptionThrown_V1 Event
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Error (1)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionThrown_V1`|80|A managed exception is thrown.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Exception Type|win:UnicodeString|Type of the exception; for example, `System.NullReferenceException`.|  
|Exception Message|win:UnicodeString|Actual exception message.|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|ExceptionHR|win:UInt32|Exception [HRESULT](https://docs.microsoft.com/openspecs/windows_protocols/ms-erref/0642cb2f-2075-4469-918c-4441e69c548a).|  
|ExceptionFlags|win:UInt16|0x01: HasInnerException (see [CLR ETW Events](clr-etw-events.md) in the Visual Basic documentation).<br /><br /> 0x02: IsNestedException.<br /><br /> 0x04: IsRethrownException.<br /><br /> 0x08: IsCorruptedStateException (indicates that the process state is corrupt; see [Handling Corrupted State Exceptions](https://docs.microsoft.com/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions)).<br /><br /> 0x10: IsCLSCompliant (an exception that derives from <xref:System.Exception> is CLS-compliant; otherwise, it is not CLS-compliant).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


### ExceptionCatchStart Event

This event is emitted when a managed exception catch handler begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionCatchStart`|250|A managed exception is handled by the runtime.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


### ExceptionCatchStop Event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionCatchStop`|251|A managed exception catch handler is done.|


### ExceptionFinallyStart Event

This event is emitted when a managed exception finally handler begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFinallyStart`|252|A managed exception is handled by the runtime.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


### ExceptionFinallyStop Event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFinallyStop`|253|A managed exception finally handler is done.|

### ExceptionFilterStart Event

This event is emitted when a managed exception filtering begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFilterStart`|254|A managed exception filtering begins.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


### ExceptionFilterStop Event

This event is emitted when a managed exception filtering ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFilteringStart`|255|A managed exception filtering ends.|  

### ExceptionThrownStop Event

This event is emitted when the runtime is done handling a managed exception that was thrown.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionThrownStop`|256|A managed exception filtering ends.|  


## Contention Events


These runtime events capture information about managed thread contentions.

This category consists of the following events:

- [ContentionStart_V1](#contentionstart_v1-event)
- [ContentionStop_V1](#contentionstop_v1-event)

### ContentionStart_V1 Event

This event is emitted at the start of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStart_V1`|81|A managed thread contention starts.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### ContentionStop_V1 Event

This event is emitted at the end of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStop_V1`|91|A managed thread contention ends.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|
|DurationNs|win:Double|Duration of the contention in nanoseconds.|

## Interop Events

These runtime events capture information about Microsoft intermediate language (MSIL) stub generation.  

This category consists of the following events:

- [ILStubGenerated](#ilstubgenerated-event)
- [ILStubCacheHit](#ilstubcachehit-event)

### ILStubGenerated Event

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`InteropKeyword` (0x2000)|Informational(4)|  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ILStubGenerated`|91|An IL Stub is generated.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt16|The module identifier.|  
|StubMethodID|win:UInt64|The stub method identifier.|  
|StubFlags|win:UInt64|The flags for the stub:<br /><br /> 0x1 - Reverse interop.<br /><br /> 0x2 - COM interop.<br /><br /> 0x4 - Stub generated by NGen.exe.<br /><br /> 0x8 - Delegate.<br /><br /> 0x10 - Variable argument.<br /><br /> 0x20 - Unmanaged callee.<br /><br /> 0x40 - Struct Marshal|  
|ManagedInteropMethodToken|win:UInt32|The token for the managed interop method.|  
|ManagedInteropMethodNameSpace|win:UnicodeString|The namespace of the managed interop method.|  
|ManagedInteropMethodName|win:UnicodeString|The name of the managed interop method.|  
|ManagedInteropMethodSignature|win:UnicodeString|The signature of the managed interop method.|  
|NativeMethodSignature|win:UnicodeString|The native method signature.|  
|StubMethodSignature|win:UnicodeString|The stub method signature.|  
|StubMethodILCode|win:UnicodeString|The MSIL code for the stub method.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


# Method ETW Events

These events collect information that is specific to methods. The payload of these events is required for symbol resolution. In addition, these events provide helpful information such as the number of times a method was called.

All method events have a level of "Informational (4)". All method verbose events have a level of "Verbose (5)".

All method events are raised by the `JITKeyword` (0x10) keyword or the `NGenKeyword` (0x20) keyword under the runtime provider, or `JitRundownKeyword` (0x10) or `NGENRundownKeyword` (0x20) under the rundown provider.

## CLR Method Events

The following table shows the keyword and level. For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md). The V2 versions of these events include the ReJITID, the V1 versions do not.

This category consists of the following events:

- [MethodLoad_V1](#methodload_v1-event)
- [MethodLoad_V2](#methodload_v2-event)
- [MethodUnLoad_V1](#methodunload_v1-event)
- [MethodUnLoad_V2](#methodunload_v2-event)
- [R2RGetEntryPoint](#r2rgetentrypoint-event)
- [R2RGetEntryPointStart](#r2rgetentrypointstart-event)
- [MethodLoadVerbose_V1](#methodloadverbose_v1-event)
- [MethodLoadVerbose_V2](#methodloadverbose_v2-event)
- [MethodUnLoadVerbose_V1](#methodunloadverbose_v1-event)
- [MethodUnLoadVerbose_V2](#methodunloadverbose_v2-event)

### MethodLoad_V1 Event


The following table shows the event information:

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoad_V1`|141|Raised when a method is just-in-time loaded (JIT-loaded) or an NGEN image is loaded. Dynamic and generic methods do not use this version for method loads. JIT helpers never use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) runtime provider|Informational (4)|
|`NGenKeyword` (0x20) runtime provider|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address of the method.|
|MethodSize|win:UInt32|Size of the method.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### MethodLoad_V2 Event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodLoad_V2`|141|Raised when a method is just-in-time loaded (JIT-loaded) or an NGEN image is loaded. Dynamic and generic methods do not use this version for method loads. JIT helpers never use this version.|


|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) runtime provider|Informational (4)|
|`NGenKeyword` (0x20) runtime provider|Informational (4)|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address of the method.|
|MethodSize|win:UInt32|Size of the method.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|ReJITID|win:UInt64|ReJIT ID of the method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### MethodUnLoad_V1

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodUnLoad_V1`|142|Raised when a module is unloaded, or an application domain is destroyed. Dynamic methods never use this version for method unloads.|


|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10)|Informational (4)|
|`NGenKeyword` (0x20)|Informational (4)|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address of the method.|
|MethodSize|win:UInt32|Size of the method.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### MethodUnLoad_V2

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodUnLoad_V2`|142|Raised when a module is unloaded, or an application domain is destroyed. Dynamic methods never use this version for method unloads.|


|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10)|Informational (4)|
|`NGenKeyword` (0x20)|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address of the method.|
|MethodSize|win:UInt32|Size of the method.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|ReJITID|win:UInt64|ReJIT ID of the method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### R2RGetEntryPoint Event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`R2RGetEntryPoint`|159|Raised when an R2R entry point lookup ends.|


|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a R2R method.|
|MethodNamespace|win:UnicodeString|The namespace of method being looked up.|
|MethodName|win:UnicodeString|The name of the method being looked up.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|EntryPoint|win:UInt64|The pointer to the entry point of the R2R method|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### R2RGetEntryPointStart Event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`R2RGetEntryPointStart`|160|Raised when an R2R entry point lookup starts.|


|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a R2R method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### MethodLoadVerbose_V1 Event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoadVerbose_V1`|143|Raised when a method is JIT-loaded or an NGEN image is loaded. Dynamic and generic methods always use this version for method loads. JIT helpers always use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address.|
|MethodSize|win:UInt32|Method length.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|MethodNameSpace|win:UnicodeString|Full namespace name associated with the method.|
|MethodName|win:UnicodeString|Full class name associated with the method.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### MethodLoadVerbose_V2 Event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoadVerbose_V1`|143|Raised when a method is JIT-loaded or an NGEN image is loaded. Dynamic and generic methods always use this version for method loads. JIT helpers always use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address.|
|MethodSize|win:UInt32|Method length.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|MethodNameSpace|win:UnicodeString|Full namespace name associated with the method.|
|MethodName|win:UnicodeString|Full class name associated with the method.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|ReJITID|win:UInt64|ReJIT ID of the method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### MethodUnLoadVerbose_V1 Event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodUnLoadVerbose_V1`|144|Raised when a dynamic method is destroyed, a module is unloaded, or an application domain is destroyed. Dynamic methods always use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address.|
|MethodSize|win:UInt32|Method length.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|MethodNameSpace|win:UnicodeString|Full namespace name associated with the method.|
|MethodName|win:UnicodeString|Full class name associated with the method.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### MethodUnLoadVerbose_V2 Event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodUnLoadVerbose_V2`|144|Raised when a dynamic method is destroyed, a module is unloaded, or an application domain is destroyed. Dynamic methods always use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|
|MethodStartAddress|win:UInt64|Start address.|
|MethodSize|win:UInt32|Method length.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|MethodNameSpace|win:UnicodeString|Full namespace name associated with the method.|
|MethodName|win:UnicodeString|Full class name associated with the method.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|ReJITID|win:UInt64|ReJIT ID of the method.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

nt16|Unique ID for the instance of CLR or CoreCLR.|

### MethodJittingStarted_V1 Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Verbose (5)|
|`NGenKeyword` (0x20) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJittingStarted_V1`|145|Raised when a method is being JIT-compiled.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of the method.|
|ModuleID|win:UInt64|Identifier of the module to which this method belongs.|
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|
|MethodILSize|win:UInt32|The size of the Microsoft intermediate language (MSIL) for the method that is being JIT-compiled.|
|MethodNameSpace|win:UnicodeString|Full class name associated with the method.|
|MethodName|win:UnicodeString|Name of the method.|
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### MethodJitInliningSucceeded Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|


|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitInliningSucceeded`|185|Raised when a method is successfully inlined by the JIT compiler.|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodBeingCompiledNamespace|win:UnicodeString|Namespace of the method being compiled.|
|MethodBeingCompiledName|win:UnicodeString|Name of the method being compiled.|
|MethodBeingCompiledNameSignature|UnicodeString|Signature of the method (comma-separated list of type names) being compiled.|
|InlinerNamespace|win:UnicodeString|The namespace of inliner ("parent") method.|
|InlinerName|win:UnicodeString|Name of the inliner ("parent") method.|
|InlinerNameSignature|win:UnicodeString|Signature of the inliner ("parent") method (comma-separated list of type names).|
|InlineeNamespace|win:UnicodeString|The namespace of inlinee ("child") method.|
|InlineeName|win:UnicodeString|Name of the inlinee ("child") method.|
|InlineeNameSignature|win:UnicodeString|Signature of the inlinee ("child") method (comma-separated list of type names).|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### MethodJitInliningFailed Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|


|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitInliningFailed`|192|Raised when a method was failed to be inlined by the JIT compiler.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodBeingCompiledNamespace|win:UnicodeString|Namespace of the method being compiled.|
|MethodBeingCompiledName|win:UnicodeString|Name of the method being compiled.|
|MethodBeingCompiledNameSignature|UnicodeString|Signature of the method (comma-separated list of type names) being compiled.|
|InlinerNamespace|win:UnicodeString|The namespace of inliner ("parent") method.|
|InlinerName|win:UnicodeString|Name of the inliner ("parent") method.|
|InlinerNameSignature|win:UnicodeString|Signature of the inliner ("parent") method (comma-separated list of type names).|
|InlineeNamespace|win:UnicodeString|The namespace of inlinee ("child") method.|
|InlineeName|win:UnicodeString|Name of the inlinee ("child") method.|
|InlineeNameSignature|win:UnicodeString|Signature of the inlinee ("child") method (comma-separated list of type names).|
|FailAlways|win:Boolean||Whether the method is marked as not inlinable.|
|FailReason|win:UnicodeString|Reason inlining failed.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## MethodJitTailCallSucceeded Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitTailCallSucceeded`|192|Raised by the JIT compiler when a method can be successfully tail called.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodBeingCompiledNamespace|win:UnicodeString|Namespace of the method being compiled.|
|MethodBeingCompiledName|win:UnicodeString|Name of the method being compiled.|
|MethodBeingCompiledNameSignature|UnicodeString|Signature of the method (comma-separated list of type names) being compiled.|
|CallerNamespace|win:UnicodeString|Namespace of the caller method.|
|CallerName|win:UnicodeString|Name of the caller method.|
|CallerNameSignature|win:UnicodeString|Signature of the caller method (Comma-separated list of type names).|
|CalleeNamespace|win:UnicodeString|Namespace of the callee method.|
|CalleeName|win:UnicodeString|Name of the callee method.|
|CalleeNameSignature|win:UnicodeString|Signature of the callee method (Comma-separated list of type names).|
|TailPrefix|win:Boolean||
|TailCallType|win:UInt32|The type of tail call.<br/><br/>0: Optimized tail call (epilog + jmp)<br/><br/>1: Recursive tail call (method tail calls itself)<br/><br/>2: Helper assisted tail call|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


## MethodJitTailCallFailed Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitTailCallFailed`|191|Raised by the JIT compiler when a method was failed to be tail called.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodBeingCompiledNamespace|win:UnicodeString|Namespace of the method being compiled.|
|MethodBeingCompiledName|win:UnicodeString|Name of the method being compiled.|
|MethodBeingCompiledNameSignature|UnicodeString|Signature of the method (comma-separated list of type names) being compiled.|
|CallerNamespace|win:UnicodeString|Namespace of the caller method.|
|CallerName|win:UnicodeString|Name of the caller method.|
|CallerNameSignature|win:UnicodeString|Signature of the caller method (Comma-separated list of type names).|
|CalleeNamespace|win:UnicodeString|Namespace of the callee method.|
|CalleeName|win:UnicodeString|Name of the callee method.|
|CalleeNameSignature|win:UnicodeString|Signature of the callee method (Comma-separated list of type names).|
|TailPrefix|win:Boolean||
|FailReason|win:UnicodeString|Reason tail call failed.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## MethodILToNativeMap Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JittedMethodILToNativeMapKeyword` (0x20000) |Verbose (5)|

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodILToNativeMap`|||

TODO

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|MethodID|win:UInt64|Unique identifier of a method.|
|ReJITID|win:UInt64|The ReJIT ID of the method.|
|MethodExtent||
|CountOfMapEntries|win:UInt8|Number of map entries|
|ILOffsets|win:UInt32|Offset of the IL from beginning of the method.|
|NativeOffsets|win:UInt32||
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


## Loader ETW Events
These events collect information relating to loading and unloading assemblies and modules.  
  
 All loader events are raised under the `LoaderKeyword` (0x8) keyword. The `DCStart` and the `DCEnd` events are raised under `LoaderRundownKeyword` (0x8) with `StartRundown`/`EndRundown` enabled. (For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md).)  

### DomainModuleLoad_V1 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`DomainModuleLoad_V1`|151|Raised when a module is loaded for an application domain.|  


### ModuleLoad_V2 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleLoad_V2`|152|Raised when a module is loaded during the lifetime of a process.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Unique ID for the module.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|  
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|  
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|  
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|

## FireEtwModuleUnload_V2 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleUnload_V2`|153|Raised when a module is unloaded during the lifetime of a process.| 
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Unique ID for the module.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|  
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|  
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|  
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|

## FireEtwModuleDCStart_V2 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleDCStart_V2`|153|Enumerates modules during a start rundown.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Unique ID for the module.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|  
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|  
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|  
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|

## FireEtwModuleDCEnd_V2 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleDCEnd_V2`|154|Enumerates modules during an end rundown.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Unique ID for the module.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance       of CLR or CoreCLR.|  
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|  
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|  
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|  
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|


### FireAssemblyLoad_V1 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyLoad_V1`|154|Raised when an assembly is loaded.|

  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AssemblyID|win:UInt64|Unique ID for the assembly.|  
|AppDomainID|win:UInt64|ID of the domain of this assembly.|  
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|  
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|  
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.

### FireAssemblyUnload_V1 Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`FireAssemblyUnload_V1`|155|Raised when an assembly is loaded.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AssemblyID|win:UInt64|Unique ID for the assembly.|  
|AppDomainID|win:UInt64|ID of the domain of this assembly.|  
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|  
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|  
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.

### FireAssemblyDCStart_V1

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyDCStart_V1`|155|Enumerates assemblies during a start rundown.|  


|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AssemblyID|win:UInt64|Unique ID for the assembly.|  
|AppDomainID|win:UInt64|ID of the domain of this assembly.|  
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|  
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|  
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

### FireAssemblyDCStart_V1

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyDCEnd_V1`|156|Enumerates assemblies during an end rundown.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AssemblyID|win:UInt64|Unique ID for the assembly.|  
|AppDomainID|win:UInt64|ID of the domain of this assembly.|  
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|  
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|  
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### AssemblyLoadStart Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`Binder` (0x4)|`AssemblyLoadStart`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyLoadStart`|290|An assembly load has been requested.| 

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|  
|AssemblyPath|win:UnicodeString|Path of assembly name.|  
|RequestingAssembly|win:UnicodeString|Name of the requesting ("parent") assemb.|
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|RequestingAssemblyLoadContext|win:UnicodeString|Load context of the requesting ("parent") assembly.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### AssemblyLoadStop Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|  
|`Binder` (0x4)|`AssemblyLoadStart`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyLoadStart`|291|An assembly load has been requested.| 


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|  
|AssemblyPath|win:UnicodeString|Path of assembly name.|  
|RequestingAssembly|win:UnicodeString|Name of the requesting ("parent") assemb.|
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|RequestingAssemblyLoadContext|win:UnicodeString|Load context of the requesting ("parent") assembly.|
|Success|win:Boolean|Whether the assembly load succeeded.|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was loaded.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was loaded from.|
|Cached|win:UnicodeString|Whether the load was cached.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


### ResolutionAttempted Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|  
|`Binder` (0x4)|`ResolutionAsttemted`|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ResolutionAsttemted`|291|An assembly load has been requested.| 


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|  
|Stage|win:UInt16|The resolution stage.<br/><br/>0: Find in load.<br/><br/>1: Assembly Load Context</br><br/>2: Application assemblies.<br/><br/>3: Default assembly load context fallback. <br/><br/>4: Resolve satellite assembly. <br/><br/>5: Assembly load context resolving.<br/><br/>6: AppDomain assembly resolving.| 
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|Result|win:UInt16|The result of resolution attempt.<br/><br/>0: Success<br/><br/>1: Assembly NotFound<br/><br/>2: Incompatible Version<br/><br/>3: Mismatched Assembly Name<br/><br/>4: Failure<br/><br/>5: Exception|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was resolved.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was resolved from.|
|ErrorMessage|win:UnicodeString|Error message if there is an exception.|
