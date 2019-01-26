---
title: "ICorDebugClass2 Interface1"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugClass2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass2"
helpviewer_keywords: 
  - "ICorDebugClass2 interface [.NET Framework debugging]"
ms.assetid: 5416de70-43f2-4cdf-a11f-d570759c9c0c
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugClass2 Interface1
Represents a generic class or a class with a method parameter of type <xref:System.Type>. This interface extends [ICorDebugClass](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-interface.md).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetParameterizedType Method](../../../../docs/framework/unmanaged-api/debugging/icordebugclass2-getparameterizedtype-method.md)|Gets the type declaration for this class.|  
|[SetJMCStatus Method](../../../../docs/framework/unmanaged-api/debugging/icordebugclass2-setjmcstatus-method.md)|For each method of this class, sets a value that indicates whether the method is user-defined code.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorDebugClass Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
