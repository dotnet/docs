---
title: "ICorDebugModule Interface1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule Interface1
Represents a common language runtime (CLR) module, which is either an executable file or a dynamic-link library (DLL).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateBreakpoint Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-createbreakpoint-method.md)|Not implemented.|  
|[EnableClassLoadCallbacks Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-enableclassloadcallbacks-method.md)|Determines whether the [ICorDebugManagedCallback::LoadClass](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-unloadclass-method.md) callbacks are called for this module.|  
|[EnableJITDebugging Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-enablejitdebugging-method.md)|Determines whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.|  
|[GetAssembly Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getassembly-method.md)|Gets the containing assembly for this module.|  
|[GetBaseAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getbaseaddress-method.md)|Gets the base address of the module.|  
|[GetClassFromToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getclassfromtoken-method.md)|Gets the ICorDebugClass from the metadata.|  
|[GetEditAndContinueSnapshot Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-geteditandcontinuesnapshot-method.md)|Deprecated.|  
|[GetFunctionFromRVA Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getfunctionfromrva-method.md)|Not implemented.|  
|[GetFunctionFromToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getfunctionfromtoken-method.md)|Gets the function that is specified by the metadata token.|  
|[GetGlobalVariableValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getglobalvariablevalue-method.md)|Gets a value object for the specified global variable.|  
|[GetMetaDataInterface Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getmetadatainterface-method.md)|Gets a metadata interface pointer that can be used to examine the metadata for the module.|  
|[GetName Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getname-method.md)|Gets the file name of the module.|  
|[GetProcess Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getprocess-method.md)|Gets the containing process for this module.|  
|[GetSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-getsize-method.md)|Gets the size of the module in bytes.|  
|[GetToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-gettoken-method.md)|Gets the token for the table entry for this module.|  
|[IsDynamic Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-isdynamic-method.md)|Indicates whether the module is dynamic.|  
|[IsInMemory Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-isinmemory-method.md)|Indicates whether this module exists only in memory.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
