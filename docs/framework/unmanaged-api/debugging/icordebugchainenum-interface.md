---
title: "ICorDebugChainEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChainEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChainEnum"
helpviewer_keywords: 
  - "ICorDebugChainEnum interface [.NET Framework debugging]"
ms.assetid: 6639335c-48e1-4e74-a4f3-70a6a0f54af1
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugChainEnum Interface

Implements ICorDebugEnum methods, and enumerates ICorDebugChain arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugchainenum-next-method.md)|Gets the specified number of `ICorDebugChain` instances from the enumeration, starting at the current position.|  
  
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
