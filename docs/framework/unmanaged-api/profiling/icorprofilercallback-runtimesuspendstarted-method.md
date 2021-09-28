---
description: "Learn more about: ICorProfilerCallback::RuntimeSuspendStarted Method"
title: "ICorProfilerCallback::RuntimeSuspendStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeSuspendStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendStarted method [.NET Framework profiling]"
  - "RuntimeSuspendStarted method [.NET Framework profiling]"
ms.assetid: c8461cac-e31b-4efa-ad2c-26598173eb96
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RuntimeSuspendStarted Method

Notifies the profiler that the runtime is about to suspend all runtime threads.  
  
## Syntax  
  
```cpp  
HRESULT RuntimeSuspendStarted(  
    [in] COR_PRF_SUSPEND_REASON suspendReason);  
```  
  
## Parameters  

 `suspendReason`  
 [in] A value of the [COR_PRF_SUSPEND_REASON](cor-prf-suspend-reason-enumeration.md) enumeration that indicates the reason for the suspension.  
  
## Remarks  

 All runtime threads that are in unmanaged code are allowed to continue running until they try to re-enter the runtime. At that point they will also be suspended until the runtime resumes. This also applies to new threads that enter the runtime. All threads in the runtime are either suspended immediately if they are already in interruptible code, or they are asked to suspend when they reach interruptible code.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [RuntimeSuspendAborted Method](icorprofilercallback-runtimesuspendaborted-method.md)
- [RuntimeSuspendFinished Method](icorprofilercallback-runtimesuspendfinished-method.md)
