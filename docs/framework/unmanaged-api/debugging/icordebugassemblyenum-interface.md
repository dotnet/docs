---
title: "ICorDebugAssemblyEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAssemblyEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssemblyEnum"
helpviewer_keywords: 
  - "ICorDebugAssemblyEnum interface [.NET Framework debugging]"
ms.assetid: 891ceb43-5161-421e-a0bf-299962fd7efd
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugAssemblyEnum Interface

Implements ICorDebugEnum methods and enumerates ICorDebugAssembly arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassemblyenum-next-method.md)|Gets the specified number of `ICorDebugAssembly` instances in the enumeration, starting from the current position.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
