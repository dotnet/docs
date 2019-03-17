---
title: "ICorProfilerCallback::ExceptionCatcherLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionCatcherLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionCatcherLeave"
helpviewer_keywords: 
  - "ExceptionCatcherLeave method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionCatcherLeave method [.NET Framework profiling]"
ms.assetid: 1f3dbdf5-db0c-4b07-bbb7-375de2a63673
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ExceptionCatcherLeave Method
Notifies the profiler that control is being passed out of the appropriate `catch` block.  
  
## Syntax  
  
```  
HRESULT ExceptionCatcherLeave();  
```  
  
## Remarks  
 The profiler should not block in its implementation of this method because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.  
  
 The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ExceptionCatcherEnter Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptioncatcherenter-method.md)
