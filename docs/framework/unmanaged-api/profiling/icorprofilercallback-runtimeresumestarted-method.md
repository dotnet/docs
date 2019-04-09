---
title: "ICorProfilerCallback::RuntimeResumeStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RuntimeResumeStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeResumeStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeResumeStarted method [.NET Framework profiling]"
  - "RuntimeResumeStarted method [.NET Framework profiling]"
ms.assetid: 5854bfb2-c568-4f19-904a-7c9d41e7b995
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::RuntimeResumeStarted Method
Notifies the profiler that the runtime is resuming all run-time threads.  
  
## Syntax  
  
```  
HRESULT RuntimeResumeStarted();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [RuntimeResumeFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimeresumefinished-method.md)
