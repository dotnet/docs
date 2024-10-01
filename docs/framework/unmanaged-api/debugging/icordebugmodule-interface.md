---
description: "Learn more about: ICorDebugModule Interface"
title: "ICorDebugModule Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule"
helpviewer_keywords:
  - "ICorDebugModule interface [.NET Framework debugging]"
ms.assetid: 32e4d6fa-e5a3-413e-9166-d5e2871d3114
topic_type:
  - "apiref"
---
# ICorDebugModule Interface

Represents a common language runtime (CLR) module, which is either an executable file or a dynamic-link library (DLL).

## Methods

|Method|Description|
|------------|-----------------|
|[CreateBreakpoint Method](icordebugmodule-createbreakpoint-method.md)|Not implemented.|
|[EnableClassLoadCallbacks Method](icordebugmodule-enableclassloadcallbacks-method.md)|Determines whether the [ICorDebugManagedCallback::LoadClass](icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](icordebugmanagedcallback-unloadclass-method.md) callbacks are called for this module.|
|[EnableJITDebugging Method](icordebugmodule-enablejitdebugging-method.md)|Determines whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.|
|[GetAssembly Method](icordebugmodule-getassembly-method.md)|Gets the containing assembly for this module.|
|[GetBaseAddress Method](icordebugmodule-getbaseaddress-method.md)|Gets the base address of the module.|
|[GetClassFromToken Method](icordebugmodule-getclassfromtoken-method.md)|Gets the ICorDebugClass from the metadata.|
|[GetEditAndContinueSnapshot Method](icordebugmodule-geteditandcontinuesnapshot-method.md)|Deprecated.|
|[GetFunctionFromRVA Method](icordebugmodule-getfunctionfromrva-method.md)|Not implemented.|
|[GetFunctionFromToken Method](icordebugmodule-getfunctionfromtoken-method.md)|Gets the function that is specified by the metadata token.|
|[GetGlobalVariableValue Method](icordebugmodule-getglobalvariablevalue-method.md)|Gets a value object for the specified global variable.|
|[GetMetaDataInterface Method](icordebugmodule-getmetadatainterface-method.md)|Gets a metadata interface pointer that can be used to examine the metadata for the module.|
|[GetName Method](icordebugmodule-getname-method.md)|Gets the file name of the module.|
|[GetProcess Method](icordebugmodule-getprocess-method.md)|Gets the containing process for this module.|
|[GetSize Method](icordebugmodule-getsize-method.md)|Gets the size of the module in bytes.|
|[GetToken Method](icordebugmodule-gettoken-method.md)|Gets the token for the table entry for this module.|
|[IsDynamic Method](icordebugmodule-isdynamic-method.md)|Indicates whether the module is dynamic.|
|[IsInMemory Method](icordebugmodule-isinmemory-method.md)|Indicates whether this module exists only in memory.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
