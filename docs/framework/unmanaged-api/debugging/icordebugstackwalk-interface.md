---
description: "Learn more about: ICorDebugStackWalk Interface"
title: "ICorDebugStackWalk Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStackWalk"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStackWalk"
helpviewer_keywords: 
  - "ICorDebugStackWalk interface [.NET Framework debugging]"
ms.assetid: 16d695e8-975d-431b-8421-e9e6c3e3f476
topic_type: 
  - "apiref"
---
# ICorDebugStackWalk Interface

Provides methods for getting the managed methods, or frames, on a thread’s stack.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetContext Method](icordebugstackwalk-getcontext-method.md)|Returns the context for the current frame in the `ICorDebugStackWalk` object.|  
|[SetContext Method](icordebugstackwalk-setcontext-method.md)|Sets the `ICorDebugStackWalk` object’s current context to a valid context for the thread.|  
|[Next Method](icordebugstackwalk-next-method.md)|Moves the `ICorDebugStackWalk` object to the next frame.|  
|[GetFrame Method](icordebugstackwalk-getframe-method.md)|Gets the current frame in the `ICorDebugStackWalk` object.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
