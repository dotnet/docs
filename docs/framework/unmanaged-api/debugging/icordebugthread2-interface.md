---
description: "Learn more about: ICorDebugThread2 Interface"
title: "ICorDebugThread2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread2"
helpviewer_keywords: 
  - "ICorDebugThread2 interface [.NET Framework debugging]"
ms.assetid: 678f89f9-cce7-46d1-af87-5e989abaa93c
topic_type: 
  - "apiref"
---
# ICorDebugThread2 Interface

Serves as a logical extension to the ICorDebugThread interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetActiveFunctions Method](icordebugthread2-getactivefunctions-method.md)|Gets an array of COR_ACTIVE_FUNCTION instances that contain data about the active functions in a thread's frames.|  
|[GetConnectionID Method](icordebugthread2-getconnectionid-method.md)|Gets a connection identifier for this `ICorDebugThread2`.|  
|[GetTaskID Method](icordebugthread2-gettaskid-method.md)|Gets a task identifier for this `ICorDebugThread2`.|  
|[GetVolatileOSThreadID Method](icordebugthread2-getvolatileosthreadid-method.md)|Gets the operating system thread identifier for this `ICorDebugThread2`.|  
|[InterceptCurrentException Method](icordebugthread2-interceptcurrentexception-method.md)|Allows a debugger to intercept the current exception on a thread.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
