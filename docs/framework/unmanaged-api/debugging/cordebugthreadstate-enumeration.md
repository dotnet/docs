---
description: "Learn more about: CorDebugThreadState Enumeration"
title: "CorDebugThreadState Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugThreadState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugThreadState"
helpviewer_keywords: 
  - "CorDebugThreadState enumeration [.NET Framework debugging]"
ms.assetid: a3ccdf18-4ec6-494d-9024-48e5c8c724f5
topic_type: 
  - "apiref"
---
# CorDebugThreadState Enumeration

Specifies the state of a thread for debugging.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugThreadState {  
    THREAD_RUN,  
    THREAD_SUSPEND  
} CorDebugThreadState;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`THREAD_RUN`|The thread runs freely, unless a debug event occurs.|  
|`THREAD_SUSPEND`|The thread cannot run.|  
  
## Remarks  

 The debugger uses the `CorDebugThreadState` enumeration to control a thread's execution. The state of a thread can be set by using the [ICorDebugThread::SetDebugState](icordebugthread-setdebugstate-method.md) or [ICorDebugController::SetAllThreadsDebugState](icordebugcontroller-setallthreadsdebugstate-method.md) method.  
  
 A callback provided to the [hosting API](../hosting/index.md) enables message pumping, so an interrupted state is not needed.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
