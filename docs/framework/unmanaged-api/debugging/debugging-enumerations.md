---
title: "Debugging Enumerations"
description: "Learn more about: Debugging Enumerations"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "debugging enumerations [.NET Framework]"
  - "unmanaged enumerations [.NET Framework], debugging"
  - "enumerations [.NET Framework debugging]"
---
# Debugging Enumerations

This section describes the unmanaged enumerations that the debugging API uses.

## In This Section

 [CLR_DEBUGGING_PROCESS_FLAGS Enumeration](clr-debugging-process-flags-enumeration.md)\
 Provides values that are used by the [ICLRDebugging::OpenVirtualProcess](iclrdebugging-openvirtualprocess-method.md) method.

 [CLRDataAddressType Enumeration](clrdataaddresstype-enumeration.md)\
 Indicates the type of data contained at a given address by the [IXCLRDataProcess::GetAddressType](ixclrdataprocess-getaddresstype-method.md).

 [CLRDataByNameFlag Enumeration](clrdatabynameflag-enumeration.md)\
 Indicates how names should match in a search.

 [CLRDataDetailedFrameType Enumeration](clrdatadetailedframetype-enumeration.md)\
 Describes a type of frame in the call stack in detail from the [IXCLRDataStackWalk::GetFrameType](ixclrdatastackwalk-getframetype-method.md) method.

 [CLRDataEnumMemoryFlags Enumeration](clrdataenummemoryflags-enumeration.md)\
 Indicates which memory regions a call to the [ICLRDataEnumMemoryRegions::EnumMemoryRegions](iclrdataenummemoryregions-enummemoryregions-method.md) method should include.

 [CLRDataExceptionSameFlag Enumeration](clrdataexceptionsameflag-enumeration.md)\
 Indicates how exception states should match against system records.

 [CLRDataFieldFlag Enumeration](clrdatafieldflag-enumeration.md)\
 Indicates various attributes of a field.

 [CLRDataFollowStubInFlag Enumeration](clrdatafollowstubinflag-enumeration.md)\
 A set of flags passed to [IXCLRDataProcess::FollowStub](ixclrdataprocess-followstub-method.md) and [IXCLRDataProcess::FollowStub2](ixclrdataprocess-followstub2-method.md) that define how to follow the stub.

 [CLRDataFollowStubOutFlag Enumeration](clrdatafollowstuboutflag-enumeration.md)\
 A set of flags returned from [IXCLRDataProcess::FollowStub](ixclrdataprocess-followstub-method.md) and [IXCLRDataProcess::FollowStub2](ixclrdataprocess-followstub2-method.md) that indicate the result of following a stub.

 [CLRDataMethodCodeNotification Enumeration](clrdatamethodcodenotification-enumeration.md)\
 Indicates the type of notifications pertaining to method instance code that should be delivered. Used in calls to [IXCLRDataProcess::SetCodeNotifications](ixclrdataprocess-setcodenotifications-method.md) and [IXCLRDataProcess::SetAllCodeNotifications Method](ixclrdataprocess-setallcodenotifications-method.md).

 [CLRDataModuleExtentType Enumeration](clrdatamoduleextenttype-enumeration.md)\
 Indicates the type of memory region associated with a module via [IXCLRDataModule::EnumExtent](ixclrdatamodule-enumextent-method.md).

 [CLRDataOtherNotifyFlag Enumeration](clrdataothernotifyflag-enumeration.md)\
 Indicates the type of notifications that should be delivered. Used in calls to [IXCLRDataProcess::SetOtherNotificationFlags Method](ixclrdataprocess-setothernotificationflags-method.md).

 [CLRDataSimpleFrameType Enumeration](clrdatasimpleframetype-enumeration.md)\
 Describes a type of frame in the call stack from [IXCLRDataStackWalk::GetFrameType](ixclrdatastackwalk-getframetype-method.md).

 [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)\
 Provides values that are used by the CLRDATA_IL_ADDRESS_MAP structure.

 [CLRDataValueFlag Enumeration](clrdatavalueflag-enumeration.md)\
 Indicates various attributes of a value.

 [COR_PUB_ENUMPROCESS Enumeration](cor-pub-enumprocess-enumeration.md)\
 Identifies the type of process to be enumerated.

 [CorDebugBlockingReason Enumeration](cordebugblockingreason-enumeration.md)\
 Specifies the reasons why a thread may become blocked on a given object.

 [CorDebugChainReason Enumeration](cordebugchainreason-enumeration.md)\
 Indicates the reason or reasons for the initiation of a call chain.

 [CorDebugCodeInvokeKind Enumeration](cordebugcodeinvokekind-enumeration.md)\
 Describes how an exported function invokes managed code.

 [CorDebugCodeInvokePurpose Enumeration](cordebugcodeinvokepurpose-enumeration.md)\
 Describes why an exported function calls managed code.

 [CorDebugCreateProcessFlags Enumeration](cordebugcreateprocessflags-enumeration.md)\
 Provides additional debugging options that can be used in a call to the [ICorDebug::CreateProcess](icordebug-createprocess-method.md) method.

 [CorDebugDebugEventKind Enumeration](cordebugdebugeventkind-enumeration.md)\
 Indicates the type of event whose information is decoded by the [DecodeEvent](icordebugprocess6-decodeevent-method.md) method.

 [CorDebugDecodeEventFlagsWindows Enumeration](cordebugdecodeeventflagswindows-enumeration.md)\
 Provides additional information about debug events on the Windows platform.

 [CorDebugExceptionCallbackType Enumeration](cordebugexceptioncallbacktype-enumeration.md)\
 Indicates the type of callback that is made from an [ICorDebugManagedCallback2::Exception](icordebugmanagedcallback2-exception-method.md) event.

 [CorDebugExceptionFlags Enumeration](cordebugexceptionflags-enumeration.md)\
 Provides additional information about an exception.

 [CorDebugExceptionUnwindCallbackType Enumeration](cordebugexceptionunwindcallbacktype-enumeration.md)\
 Indicates the event that is being signaled by the callback during the unwind phase.

 [CorDebugGCType Enumeration](cordebuggctype-enumeration.md)\
 Indicates whether the garbage collector is running on a workstation or a server.

 [CorDebugGenerationTypes Enumeration](cordebuggenerationtypes-enumeration.md)\
 Specifies the generation of a region of memory on the managed heap.

 [CorDebugHandleType Enumeration](cordebughandletype-enumeration.md)\
 Indicates the handle type.

 [CorDebugIlToNativeMappingTypes Enumeration](cordebugiltonativemappingtypes-enumeration.md)\
 Indicates whether a particular range of native instructions corresponds to a special code region.

 [CorDebugIntercept Enumeration](cordebugintercept-enumeration.md)\
 Indicates the types of code that can be stepped into.

 [CorDebugInterfaceVersion Enumeration](cordebuginterfaceversion-enumeration.md)\
 Specifies either a version of the .NET Framework, or the version of the .NET Framework in which an interface was introduced.

 [CorDebugInternalFrameType Enumeration](cordebuginternalframetype-enumeration.md)\
 Identifies the type of stack frame.

 [CorDebugJITCompilerFlags Enumeration](cordebugjitcompilerflags-enumeration.md)\
 Contains values that influence the behavior of the managed just-in-time (JIT) compiler.

 [CorDebugJITCompilerFlagsDeprecated Enumeration](cordebugjitcompilerflagsdeprecated-enumeration.md)\
 Obsolete. Use the `CORDEBUG_JIT_DEFAULT` member of the [CorDebugJITCompilerFlags](cordebugjitcompilerflags-enumeration.md) enumeration instead.

 [CorDebugMappingResult Enumeration](cordebugmappingresult-enumeration.md)\
 Provides the details of how the value of the instruction pointer (IP) was obtained.

 [CorDebugMDAFlags Enumeration](cordebugmdaflags-enumeration.md)\
 Specifies the status of the thread on which the managed debugging assistant (MDA) is fired.

 [CorDebugNGenPolicy Enumeration](cordebugngenpolicy-enumeration.md)\
 Provides a value that determines whether a debugger loads native (NGen) images from the native image cache.

 [CorDebugPlatform Enumeration](cordebugplatform-enumeration.md)\
 Provides target platform values that are used by the [ICorDebugDataTarget::GetPlatform](icordebugdatatarget-getplatform-method.md) method.

 [CorDebugRecordFormat Enumeration](cordebugrecordformat-enumeration.md)\
 Describes the format of the data in a byte array that contains information about a native exception debug event.

 [CorDebugRegister Enumeration](cordebugregister-enumeration.md)\
 Specifies the registers associated with a given processor architecture.

 [CorDebugSetContextFlag Enumeration](cordebugsetcontextflag-enumeration.md)\
 Indicates whether the context is from the active (or leaf) frame on the stack or has been computed by unwinding from another frame.

 [CorDebugStateChange Enumeration](cordebugstatechange-enumeration.md)\
 Describes the amount of cached data that must be discarded based on changes to the process.

 [CorDebugStepReason Enumeration](cordebugstepreason-enumeration.md)\
 Indicates the outcome of an individual step.

 [CorDebugThreadState Enumeration](cordebugthreadstate-enumeration.md)\
 Specifies the state of a thread for debugging.

 [CorDebugUnmappedStop Enumeration](cordebugunmappedstop-enumeration.md)\
 Specifies the type of unmapped code that can trigger a halt in code execution by the stepper.

 [CorDebugUserState Enumeration](cordebuguserstate-enumeration.md)\
 Indicates the user state of a thread.

 [CorGCReferenceType Enumeration](corgcreferencetype-enumeration.md)\
 Identifies the source of an object to be garbage-collected.

 [ILCodeKind Enumeration](ilcodekind-enumeration.md)\
 Provides values that specify whether the debugger is able to access local variables or code added in profiler ReJIT instrumentation.

 [LoggingLevelEnum Enumeration](logginglevelenum-enumeration.md)\
 Indicates the severity level of a descriptive message that is written to the event log when a managed thread logs an event.

 [LogSwitchCallReason Enumeration](logswitchcallreason-enumeration.md)\
 Indicates the operation that was performed on a debugging/tracing switch.

 [VariableLocationType Enumeration](variablelocationtype-enumeration.md)\
 Indicates the native location type of a variable.

 [WriteableMetadataUpdateMode Enumeration](writeablemetadataupdatemode-enumeration.md)\
 Provides values that specify whether in-memory updates to metadata are visible to a debugger.

## Related Sections

 [Debugging Coclasses](debugging-coclasses.md)

 [Debugging Interfaces](debugging-interfaces.md)

 [Debugging Global Static Functions](debugging-global-static-functions.md)

 [Debugging Structures](debugging-structures.md)
