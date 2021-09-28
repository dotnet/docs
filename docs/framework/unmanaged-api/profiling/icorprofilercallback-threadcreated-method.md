---
description: "Learn more about: ICorProfilerCallback::ThreadCreated Method"
title: "ICorProfilerCallback::ThreadCreated Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ThreadCreated"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ThreadCreated"
helpviewer_keywords: 
  - "ICorProfilerCallback::ThreadCreated method [.NET Framework profiling]"
  - "ThreadCreated method [.NET Framework profiling]"
ms.assetid: cca0f799-09b8-4689-a33c-6d6537943a9b
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ThreadCreated Method

Notifies the profiler that a thread has been created.  
  
## Syntax  
  
```cpp  
HRESULT ThreadCreated(  
    [in] ThreadID threadId);
```  
  
## Parameters  

 `threadId`  
 [in] The ID of the thread that has been created.  
  
## Remarks  

 The `threadId` value is immediately valid.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ThreadDestroyed Method](icorprofilercallback-threaddestroyed-method.md)
