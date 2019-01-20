---
title: "ICorDebugModuleEnum Interface1"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModuleEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModuleEnum"
helpviewer_keywords: 
  - "ICorDebugModuleEnum interface [.NET Framework debugging]"
ms.assetid: 2fb93cd6-6d47-4fdc-a9a0-047726fd03a1
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugModuleEnum Interface1
Implements ICorDebugEnum methods, and enumerates ICorDebugModule arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmoduleenum-next-method.md)|Gets the specified number of `ICorDebugModule` instances from the enumeration, starting at the current position.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
