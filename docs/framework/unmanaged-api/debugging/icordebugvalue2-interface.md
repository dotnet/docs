---
title: "ICorDebugValue2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValue2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue2"
helpviewer_keywords: 
  - "ICorDebugValue2 interface [.NET Framework debugging]"
ms.assetid: 3ff2ad2a-da5a-461b-8627-1a8eba49df9c
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugValue2 Interface
Extends the "ICorDebugValue" interface to provide support for "ICorDebugType" objects.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetExactType Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue2-getexacttype-method.md)|Gets an interface pointer to an `ICorDebugType` object that represents the <xref:System.Type> of this value.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
    
 [ICorDebugValue3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue3-interface.md)
