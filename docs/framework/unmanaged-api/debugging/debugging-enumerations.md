---
title: "Debugging Enumerations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "debugging enumerations [.NET Framework]"
  - "unmanaged enumerations [.NET Framework], debugging"
  - "enumerations [.NET Framework debugging]"
ms.assetid: 3af9f584-f1b4-4154-aeaa-8fce7c9f8b50
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Debugging Enumerations
This section describes the unmanaged enumerations that the debugging API uses.  
  
## In This Section  
 [CLR_DEBUGGING_PROCESS_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/debugging/clr-debugging-process-flags-enumeration.md)  
 Provides values that are used by the [ICLRDebugging::OpenVirtualProcess](../../../../docs/framework/unmanaged-api/debugging/iclrdebugging-openvirtualprocess-method.md) method.  
  
 [CLRDataEnumMemoryFlags Enumeration](../../../../docs/framework/unmanaged-api/debugging/clrdataenummemoryflags-enumeration.md)  
 Indicates which memory regions a call to the [ICLRDataEnumMemoryRegions::EnumMemoryRegions](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregions-enummemoryregions-method.md) method should include.  
  
 [COR_PUB_ENUMPROCESS Enumeration](../../../../docs/framework/unmanaged-api/debugging/cor-pub-enumprocess-enumeration.md)  
 Identifies the type of process to be enumerated.  
  
 [CorDebugBlockingReason Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingreason-enumeration.md)  
 Specifies the reasons why a thread may become blocked on a given object.  
  
 CorDebugChainReason  
 Indicates the reason or reasons for the initiation of a call chain.  
  
 [CorDebugCodeInvokeKind Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugcodeinvokekind-enumeration.md)  
 Describes how an exported function invokes managed code.  
  
 [CorDebugCodeInvokePurpose Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugcodeinvokepurpose-enumeration.md)  
 Describes why an exported function calls managed code.  
  
 CorDebugCreateProcessFlags  
 Provides additional debugging options that can be used in a call to the [ICorDebug::CreateProcess](../../../../docs/framework/unmanaged-api/debugging/icordebug-createprocess-method.md) method.  
  
 [CorDebugDebugEventKind Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugdebugeventkind-enumeration.md)  
 Indicates the type of event whose information is decoded by the [DecodeEvent](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-decodeevent-method.md) method.  
  
 [CorDebugDecodeEventFlagsWindows Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugdecodeeventflagswindows-enumeration.md)  
 Provides additional information about debug events on the Windows platform.  
  
 CorDebugExceptionCallbackType  
 Indicates the type of callback that is made from an [ICorDebugManagedCallback2::Exception](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-exception-method.md) event.  
  
 [CorDebugExceptionFlags Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugexceptionflags-enumeration.md)  
 Provides additional information about an exception.  
  
 CorDebugExceptionUnwindCallbackType  
 Indicates the event that is being signaled by the callback during the unwind phase.  
  
 [CorDebugGCType Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebuggctype-enumeration.md)  
 Indicates whether the garbage collector is running on a workstation or a server.  
  
 [CorDebugGenerationTypes Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebuggenerationtypes-enumeration.md)  
 Specifies the generation of a region of memory on the managed heap.  
  
 CorDebugHandleType  
 Indicates the handle type.  
  
 [CorDebugIlToNativeMappingTypes Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugiltonativemappingtypes-enumeration.md)  
 Indicates whether a particular range of native instructions corresponds to a special code region.  
  
 CorDebugIntercept  
 Indicates the types of code that can be stepped into.  
  
 [CorDebugInterfaceVersion Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebuginterfaceversion-enumeration.md)  
 Specifies either a version of the .NET Framework, or the version of the .NET Framework in which an interface was introduced.  
  
 CorDebugInternalFrameType  
 Identifies the type of stack frame.  
  
 [CorDebugJITCompilerFlags Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflags-enumeration.md)  
 Contains values that influence the behavior of the managed just-in-time (JIT) compiler.  
  
 [CorDebugJITCompilerFlagsDeprecated Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflagsdeprecated-enumeration.md)  
 Obsolete. Use the `CORDEBUG_JIT_DEFAULT` member of the [CorDebugJITCompilerFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflags-enumeration.md) enumeration instead.  
  
 CorDebugMappingResult  
 Provides the details of how the value of the instruction pointer (IP) was obtained.  
  
 [CorDebugMDAFlags Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugmdaflags-enumeration.md)  
 Specifies the status of the thread on which the managed debugging assistant (MDA) is fired.  
  
 [CorDebugNGenPolicy Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugngenpolicy-enumeration.md)  
 Provides a value that determines whether a debugger loads native (NGen) images from the native image cache.  
  
 [CorDebugPlatform Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugplatform-enumeration.md)  
 Provides target platform values that are used by the [ICorDebugDataTarget::GetPlatform](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getplatform-method.md) method.  
  
 [CorDebugRecordFormat Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugrecordformat-enumeration.md)  
 Describes the format of the data in a byte array that contains information about a native exception debug event.  
  
 CorDebugRegister  
 Specifies the registers associated with a given processor architecture.  
  
 [CorDebugSetContextFlag Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugsetcontextflag-enumeration.md)  
 Indicates whether the context is from the active (or leaf) frame on the stack or has been computed by unwinding from another frame.  
  
 [CorDebugStateChange Enumeration](../../../../docs/framework/unmanaged-api/debugging/cordebugstatechange-enumeration.md)  
 Describes the amount of cached data that must be discarded based on changes to the process.  
  
 CorDebugStepReason  
 Indicates the outcome of an individual step.  
  
 CorDebugThreadState  
 Specifies the state of a thread for debugging.  
  
 \>CorDebugUnmappedStop  
 Specifies the type of unmapped code that can trigger a halt in code execution by the stepper.  
  
 CorDebugUserState  
 Indicates the user state of a thread.  
  
 [CorGCReferenceType Enumeration](../../../../docs/framework/unmanaged-api/debugging/corgcreferencetype-enumeration.md)  
 Identifies the source of an object to be garbage-collected.  
  
 [ILCodeKind Enumeration](../../../../docs/framework/unmanaged-api/debugging/ilcodekind-enumeration.md)  
 Provides values that specify whether the debugger is able to access local variables or code added in profiler ReJIT instrumentation.  
  
 [LoggingLevelEnum Enumeration](../../../../docs/framework/unmanaged-api/debugging/logginglevelenum-enumeration.md)  
 Indicates the severity level of a descriptive message that is written to the event log when a managed thread logs an event.  
  
 [LogSwitchCallReason Enumeration](../../../../docs/framework/unmanaged-api/debugging/logswitchcallreason-enumeration.md)  
 Indicates the operation that was performed on a debugging/tracing switch.  
  
 [VariableLocationType Enumeration](../../../../docs/framework/unmanaged-api/debugging/variablelocationtype-enumeration.md)  
 Indicates the native location type of a variable.  
  
 [WriteableMetadataUpdateMode Enumeration](../../../../docs/framework/unmanaged-api/debugging/writeablemetadataupdatemode-enumeration.md)  
 Provides values that specify whether in-memory updates to metadata are visible to a debugger.  
  
## Related Sections  
 [Debugging Coclasses](../../../../docs/framework/unmanaged-api/debugging/debugging-coclasses.md)  
  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)  
  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
