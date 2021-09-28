---
description: "Learn more about: ICorDebugFunction2 Interface"
title: "ICorDebugFunction2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction2"
helpviewer_keywords: 
  - "ICorDebugFunction2 interface [.NET Framework debugging]"
ms.assetid: 2b936bef-9b75-48bf-859f-42e419c65f1c
topic_type: 
  - "apiref"
---
# ICorDebugFunction2 Interface

Logically extends the ICorDebugFunction interface to provide support for Just My Code step-through debugging, which skips non-user code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateNativeCode Method](icordebugfunction2-enumeratenativecode-method.md)|(Not yet implemented.) Gets an interface pointer to an ICorDebugCodeEnum that contains the native code statements in the function referenced by this ICorDebugFunction2 object.|  
|[GetJMCStatus Method](icordebugfunction2-getjmcstatus-method.md)|Gets a value that indicates whether this function is marked as user code.|  
|[GetVersionNumber Method](icordebugfunction2-getversionnumber-method.md)|Gets the Edit and Continue version of this function.|  
|[SetJMCStatus Method](icordebugfunction2-setjmcstatus-method.md)|Marks this function for Just My Code stepping.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
