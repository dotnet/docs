---
description: "Learn more about: ICorDebugCode4 Interface"
title: "ICorDebugCode4 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode4"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode4"
helpviewer_keywords: 
  - "ICorDebugCode4 interface [.NET Framework debugging]"
ms.assetid: a3fdf523-274a-449c-920b-9fcb0aed1d97
topic_type: 
  - "apiref"
---
# ICorDebugCode4 Interface

Provides a method that enables a debugger to enumerate the local variables and arguments in a function.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateVariableHomes Method](icordebugcode4-enumeratevariablehomes-method.md)|Gets an enumerator to the local variables and arguments in a function.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
