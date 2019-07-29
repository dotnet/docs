---
title: "ICorProfilerCallback::ThreadDestroyed Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ThreadDestroyed"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ThreadDestroyed"
helpviewer_keywords: 
  - "ThreadDestroyed method [.NET Framework profiling]"
  - "ICorProfilerCallback::ThreadDestroyed method [.NET Framework profiling]"
ms.assetid: 4c2b66fd-0595-40a3-8931-f9c4fff97ac8
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ThreadDestroyed Method
Notifies the profiler that a thread has been destroyed.  
  
## Syntax  
  
```cpp  
HRESULT ThreadDestroyed(  
    [in] ThreadID threadId);  
```  
  
## Parameters  
 `threadId`  
 [in] The ID of the thread that has been destroyed.  
  
## Remarks  
 The `threadId` value is no longer valid at the time of this call.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ThreadCreated Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-threadcreated-method.md)
