---
title: "ICorProfilerCallback::RuntimeSuspendAborted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeSuspendAborted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendAborted"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeSuspendAborted method [.NET Framework profiling]"
  - "RuntimeSuspendAborted method [.NET Framework profiling]"
ms.assetid: 5a8a4277-345b-448b-a028-fc8cff9998aa
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::RuntimeSuspendAborted Method
Notifies the profiler that the runtime has aborted the runtime suspension that was occurring.  
  
## Syntax  
  
```  
HRESULT RuntimeSuspendAborted();  
```  
  
## Remarks  
 The run-time suspension might be aborted if two threads simultaneously attempt to suspend the runtime.  
  
 Either the [ICorProfilerCallback::RuntimeSuspendFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimesuspendfinished-method.md) callback or the `RuntimeSuspendAborted` callback will occur on a single thread following a [ICorProfilerCallback::RuntimeSuspendStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimesuspendstarted-method.md) callback.  
  
 The `RuntimeSuspendAborted` callback is guaranteed to occur on the same thread as the `RuntimeSuspendStarted` callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
