---
title: "ICorDebugThreadEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThreadEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThreadEnum"
helpviewer_keywords: 
  - "ICorDebugThreadEnum interface [.NET Framework debugging]"
ms.assetid: 796de687-7dd4-4b7b-a10b-8bf22dc7779f
topic_type: 
  - "apiref"
---
# ICorDebugThreadEnum Interface
Implements ICorDebugEnum methods and enumerates ICorDebugThread arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugthreadenum-next-method.md)|Gets the specified number of `ICorDebugThread` instances from the enumeration, starting at the current position.|  
  
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
