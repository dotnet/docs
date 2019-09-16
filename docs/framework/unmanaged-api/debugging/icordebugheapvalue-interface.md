---
title: "ICorDebugHeapValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugHeapValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue"
helpviewer_keywords: 
  - "ICorDebugHeapValue interface [.NET Framework debugging]"
ms.assetid: 1bca66db-0359-4ae8-846e-e35f7e547e8b
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugHeapValue Interface

A subclass of "ICorDebugValue" that represents an object that has been collected by the common language runtime (CLR) garbage collector.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateRelocBreakpoint Method](../../../../docs/framework/unmanaged-api/debugging/icordebugheapvalue-createrelocbreakpoint-method.md)|Not implemented.|  
|[IsValid Method](../../../../docs/framework/unmanaged-api/debugging/icordebugheapvalue-isvalid-method.md)|Gets a value that indicates whether the object represented by this `ICorDebugHeapValue` is valid, or has been reclaimed by the garbage collector. This method has been deprecated in the .NET Framework version 2.0.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
