---
description: "Learn more about: ICorProfilerCallback::ExceptionSearchFunctionLeave Method"
title: "ICorProfilerCallback::ExceptionSearchFunctionLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionSearchFunctionLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionSearchFunctionLeave"
helpviewer_keywords: 
  - "ExceptionSearchFunctionLeave method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionSearchFunctionLeave method [.NET Framework profiling]"
ms.assetid: 01de7ac6-0aad-42ef-bf93-50737667b0a4
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionSearchFunctionLeave Method

Notifies the profiler that the search phase of exception handling has finished searching a function.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionSearchFunctionLeave();  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionSearchFunctionEnter Method](icorprofilercallback-exceptionsearchfunctionenter-method.md)
