---
title: "ICorProfilerCallback::ExceptionSearchFilterLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionSearchFilterLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionSearchFilterLeave"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionSearchFilterLeave method [.NET Framework profiling]"
  - "ExceptionSearchFilterLeave method [.NET Framework profiling]"
ms.assetid: c28a2a82-dd11-4385-843f-b509fb61753b
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ExceptionSearchFilterLeave Method
Notifies the profiler that a user filter has just finished executing.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionSearchFilterLeave();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ExceptionSearchFilterEnter Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionsearchfilterenter-method.md)
