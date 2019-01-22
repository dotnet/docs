---
title: "ICorDebugStringValue Interface1"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStringValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStringValue"
helpviewer_keywords: 
  - "ICorDebugStringValue interface [.NET Framework debugging]"
ms.assetid: bf84d0af-53e1-4c04-bc5b-7e5f81ba2cc2
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugStringValue Interface1
A subclass of ICorDebugHeapValue that applies to string values.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetLength Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstringvalue-getlength-method.md)|Gets the number of characters in the string referenced by this `ICorDebugStringValue`.|  
|[GetString Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstringvalue-getstring-method.md)|Gets the string referenced by this `ICorDebugStringValue`.|  
  
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
