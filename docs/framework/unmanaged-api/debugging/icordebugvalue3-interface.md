---
title: "ICorDebugValue3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValue3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue3"
helpviewer_keywords: 
  - "ICorDebugValue3 interface [.NET Framework debugging]"
ms.assetid: 7d5385d3-f4a5-47c4-8478-a3513b5e9406
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugValue3 Interface
Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetSize64 Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue3-getsize64-method.md)|Gets the size, in bytes, of this `ICorDebugValue3` object.|  
  
## Remarks  
 The [ICorDebugValue::GetSize](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue3-getsize64-method.md) method returns an object size that ranges from 0 to 2,147,483,647 bytes. In the .NET Framework 4.5, the size of arrays can exceed 2 GB. The `ICorDebugValue3` interface enables you to determine the size of these arrays.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
