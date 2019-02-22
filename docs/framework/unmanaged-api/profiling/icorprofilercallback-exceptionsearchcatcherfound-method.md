---
title: "ICorProfilerCallback::ExceptionSearchCatcherFound Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionSearchCatcherFound"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionSearchCatcherFound"
helpviewer_keywords: 
  - "ExceptionSearchCatcherFound method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionSearchCatcherFound method [.NET Framework profiling]"
ms.assetid: 190f424d-5e37-4163-a191-0895686e9476
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ExceptionSearchCatcherFound Method
Notifies the profiler that the search phase of exception handling has located a handler for the exception that was thrown.  
  
## Syntax  
  
```  
RESULT ExceptionSearchCatcherFound(  
    [in] FunctionID functionId);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that contains the exception handler.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
