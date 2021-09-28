---
description: "Learn more about: ICorProfilerCallback::RuntimeResumeFinished Method"
title: "ICorProfilerCallback::RuntimeResumeFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeResumeFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeResumeFinished"
helpviewer_keywords: 
  - "RuntimeResumeFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::RuntimeResumeFinished method [.NET Framework profiling]"
ms.assetid: 76de0494-dc49-426b-887d-bee98806a982
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RuntimeResumeFinished Method

Notifies the profiler that the runtime has resumed all runtime threads and has returned to normal operation.  
  
## Syntax  
  
```cpp  
HRESULT RuntimeResumeFinished();  
```  
  
## Remarks  

 The `RuntimeResumeFinished` callback is not guaranteed to occur on the same thread as the [ICorProfilerCallback::RuntimeSuspendStarted](icorprofilercallback-runtimesuspendstarted-method.md) callback. However, it is guaranteed to occur on the same thread as the [ICorProfilerCallback::RuntimeResumeStarted](icorprofilercallback-runtimeresumestarted-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
