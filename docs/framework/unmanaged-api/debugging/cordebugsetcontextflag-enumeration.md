---
title: "CorDebugSetContextFlag Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugSetContextFlag"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugSetContextFlag"
helpviewer_keywords: 
  - "CorDebugSetContextFlag enumeration [.NET Framework debugging]"
ms.assetid: b30280bb-fe75-44ed-8589-bcff081fae44
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CorDebugSetContextFlag Enumeration
Indicates whether the context is from the active (or leaf) frame on the stack or has been computed by unwinding from another frame.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugSetContextFlag  
{  
   SET_CONTEXT_FLAG_ACTIVE_FRAME = 1  
   SET_CONTEXT_FLAG_UNWIND_FRAME = 2  
}  CorDebugSetContextFlag;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|SET_CONTEXT_FLAG_ACTIVE_FRAME|The context is the thread’s active context.|  
|SET_CONTEXT_FLAG_UNWIND_FRAME|The context has been computed by unwinding from another frame.|  
  
## Remarks  
 `CorDebugSetContextFlag` provides values that are used by the [ICorDebugStackWalk::SetContext](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-setcontext-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
