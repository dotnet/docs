---
title: "CorDebugUserState Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorDebugUserState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugUserState"
helpviewer_keywords: 
  - "CorDebugUserState enumeration [.NET Framework debugging]"
ms.assetid: 5f6c2bcd-8102-4e3b-abc5-86ab0bd62def
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugUserState Enumeration
Indicates the user state of a thread.  
  
## Syntax  
  
```  
typedef enum CorDebugUserState {  
    USER_STOP_REQUESTED     =  0x01,  
    USER_SUSPEND_REQUESTED  =  0x02,  
    USER_BACKGROUND         =  0x04,  
    USER_UNSTARTED          =  0x08,  
    USER_STOPPED            =  0x10,  
    USER_WAIT_SLEEP_JOIN    =  0x20,  
    USER_SUSPENDED          =  0x40,  
    USER_UNSAFE_POINT       =  0x80,  
    USER_THREADPOOL         = 0x100  
} CorDebugUserState;  
```  
  
## Members  
  
|Value|Description|  
|-----------|-----------------|  
|`USER_STOP_REQUESTED`|A termination of the thread has been requested.|  
|`USER_SUSPEND_REQUESTED`|A suspension of the thread has been requested.|  
|`USER_BACKGROUND`|The thread is running in the background.|  
|`USER_UNSTARTED`|The thread has not started executing.|  
|`USER_STOPPED`|The thread has been terminated.|  
|`USER_WAIT_SLEEP_JOIN`|The thread is waiting for another thread to complete a task.|  
|`USER_SUSPENDED`|The thread has been suspended.|  
|`USER_UNSAFE_POINT`|The thread is at an unsafe point. That is, the thread is at a point in execution where it may block garbage collection.<br /><br /> Debug events may be dispatched from unsafe points, but suspending a thread at an unsafe point  will very likely cause a deadlock until the thread is resumed. The safe and unsafe points are determined by the just-in-time (JIT) and garbage collection implementation.|  
|`USER_THREADPOOL`|The thread is from the thread pool.|  
  
## Remarks  
 The user state of a thread is the state that the thread has when the debugger examines it. A thread may have a combination of user states.  
  
 Use the [ICorDebugThread::GetUserState](../../../../docs/framework/unmanaged-api/debugging/icordebugthread-getuserstate-method.md) method to retrieve a thread's user state.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
