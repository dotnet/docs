---
title: "ICorDebugValueEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValueEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValueEnum"
helpviewer_keywords: 
  - "ICorDebugValueEnum interface [.NET Framework debugging]"
ms.assetid: 88989482-a09f-4bd0-9adb-16f47b0291fd
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugValueEnum Interface
Implements "ICorDebugEnum" methods and enumerates "ICorDebugValue" arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalueenum-next-method.md)|Gets the specified number of `ICorDebugValue` instances from the enumeration, starting at the current position.|  
  
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
