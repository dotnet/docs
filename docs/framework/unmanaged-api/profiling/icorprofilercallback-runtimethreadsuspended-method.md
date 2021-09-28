---
description: "Learn more about: ICorProfilerCallback::RuntimeThreadSuspended Method"
title: "ICorProfilerCallback::RuntimeThreadSuspended Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeThreadSuspended"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeThreadSuspended"
helpviewer_keywords: 
  - "RuntimeThreadSuspended method [.NET Framework profiling]"
  - "ICorProfilerCallback::RuntimeThreadSuspended method [.NET Framework profiling]"
ms.assetid: de830a8b-6ee1-4900-ace3-4237108f6b12
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RuntimeThreadSuspended Method

Notifies the profiler that the specified thread has been suspended or is about to be suspended.  
  
## Syntax  
  
```cpp  
HRESULT RuntimeThreadSuspended(  
    [in] ThreadID threadId);  
```  
  
## Parameters  

 `threadId`  
 [in] The ID of the thread that has been suspended.  
  
## Remarks  

 The `RuntimeThreadSuspended` notification can occur any time between the [ICorProfilerCallback::RuntimeSuspendStarted](icorprofilercallback-runtimesuspendstarted-method.md) and the associated [ICorProfilerCallback::RuntimeResumeStarted](icorprofilercallback-runtimeresumestarted-method.md) callbacks. Notifications that occur between [ICorProfilerCallback::RuntimeSuspendFinished](icorprofilercallback-runtimesuspendfinished-method.md) and `RuntimeResumeStarted` are for threads that had been running in unmanaged code and were suspended upon entry to the runtime.  
  
 Generally, this callback occurs just after a thread is suspended. However, if the currently executing thread (the thread that called this callback) is the one that is being suspended, this callback will occur just before the thread is suspended.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [RuntimeThreadResumed Method](icorprofilercallback-runtimethreadresumed-method.md)
