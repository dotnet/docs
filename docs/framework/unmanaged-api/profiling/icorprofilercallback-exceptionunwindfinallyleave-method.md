---
title: "ICorProfilerCallback::ExceptionUnwindFinallyLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionUnwindFinallyLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFinallyLeave"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFinallyLeave method [.NET Framework profiling]"
  - "ExceptionUnwindFinallyLeave method [.NET Framework profiling]"
ms.assetid: 2350351e-f253-4c0c-a191-f952bc5700e6
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ExceptionUnwindFinallyLeave Method
Notifies the profiler that the unwind phase of exception handling has left a `finally` clause.  
  
## Syntax  
  
```  
HRESULT ExceptionUnwindFinallyLeave();  
```  
  
## Remarks  
 The profiler should not block during this call because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and a garbage collection is attempted, the runtime will block until this callback returns.  
  
 Also, during this call, the profiler must not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ExceptionUnwindFinallyEnter Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionunwindfinallyenter-method.md)
