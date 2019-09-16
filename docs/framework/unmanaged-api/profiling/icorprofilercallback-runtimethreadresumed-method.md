---
title: "ICorProfilerCallback::RuntimeThreadResumed Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeThreadResumed"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeThreadResumed"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeThreadResumed method [.NET Framework profiling]"
  - "RuntimeThreadResumed method [.NET Framework profiling]"
ms.assetid: da984f89-4f53-4ab0-ae6f-3e2ee6085994
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::RuntimeThreadResumed Method
Notifies the profiler that the specified thread has resumed after being suspended.  
  
## Syntax  
  
```cpp  
HRESULT RuntimeThreadResumed(  
    [in] ThreadID threadId);  
```  
  
## Parameters  
 `threadId`  
 [in] The ID of the thread that has been resumed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [RuntimeThreadSuspended Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimethreadsuspended-method.md)
