---
title: "CorDebugBlockingObject Structure"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugBlockingObject Structure"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugBlockingObject"
helpviewer_keywords: 
  - "CorDebugBlockingObject structure [.NET Framework debugging]"
ms.assetid: 5944edd1-0914-4efa-aba0-d5a277c38b1a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CorDebugBlockingObject Structure
Defines an object that is blocking a thread and the specific reason that the thread is blocked.  
  
## Syntax  
  
```cpp  
Typedef struct CorDebugBlockingObject  
{  
ICorDebugValue pBlockingObject;  
DWORD dwTimeout;  
CorDebugBlockingReason blockingReason;  
}  CorDebugBlockingObject;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pBlockingObject`|The object on which the thread is blocking. This object is valid only for the duration of the current synchronized state. If two threads are blocking on the same object within the same synchronized state, you may expect the [ICorDebugValue::GetAddress](icordebugvalue-getaddress-method.md) method to return the same value. However, the interfaces may or may not be pointer equivalent.|  
|`dwTimeout`|The number of milliseconds before the blocking operation will time out, or the value INFINITE, which indicates that it will not time out. The time-out value specifies the total length of time for the blocking operation, not the time that is still remaining.|  
|`blockingReason`|The reason that the thread is blocked on this object.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
