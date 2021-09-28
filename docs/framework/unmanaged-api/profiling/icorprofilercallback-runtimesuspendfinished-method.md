---
description: "Learn more about: ICorProfilerCallback::RuntimeSuspendFinished Method"
title: "ICorProfilerCallback::RuntimeSuspendFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeSuspendFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendFinished"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendFinished method [.NET Framework profiling]"
  - "RuntimeSuspendFinished method [.NET Framework profiling]"
ms.assetid: b7723f58-c55c-4399-9972-1bbf3b866694
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RuntimeSuspendFinished Method

Notifies the profiler that the runtime has completed suspension of all runtime threads.  
  
## Syntax  
  
```cpp  
HRESULT RuntimeSuspendFinished();  
```  
  
## Remarks  

 All runtime threads that are in unmanaged code are allowed to continue running until they try to re-enter the runtime. At that point they will also be suspended until the runtime resumes. This also applies to new threads that enter the runtime. All threads in the runtime are either suspended immediately if they are already in interruptible code, or they are asked to suspend when they reach interruptible code.  
  
 The `RuntimeSuspendFinished` callback is guaranteed to occur on the same thread as the [ICorProfilerCallback::RuntimeSuspendStarted](icorprofilercallback-runtimesuspendstarted-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [RuntimeSuspendAborted Method](icorprofilercallback-runtimesuspendaborted-method.md)
