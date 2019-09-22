---
title: "COR_ACTIVE_FUNCTION Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_ACTIVE_FUNCTION"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_ACTIVE_FUNCTION"
helpviewer_keywords: 
  - "COR_ACTIVE_FUNCTION structure [.NET Framework debugging]"
ms.assetid: ed86185f-2152-459c-961f-10c06d62e83f
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# COR_ACTIVE_FUNCTION Structure
Contains information about the functions that are currently active in a thread's frames. This structure is used by the [ICorDebugThread2::GetActiveFunctions](../../../../docs/framework/unmanaged-api/debugging/icordebugthread2-getactivefunctions-method.md) method.  
  
## Syntax  
  
```cpp  
typedef struct  _COR_ACTIVE_FUNCTION {  
    ICorDebugAppDomain   *pAppDomain;  
    ICorDebugModule      *pModule;  
    ICorDebugFunction2   *pFunction;  
    ULONG32              ilOffset;  
    ULONG32              flags;  
} COR_ACTIVE_FUNCTION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pAppDomain`|Pointer to the application domain owner of the `ilOffset` field.|  
|`pModule`|Pointer to the module owner of the `ilOffset` field.|  
|`pFunction`|Pointer to the function owner of the `ilOffset` field.|  
|`ilOffset`|The Microsoft intermediate language (MSIL) offset of the frame.|  
|`flags`|Reserved for future extensibility.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
