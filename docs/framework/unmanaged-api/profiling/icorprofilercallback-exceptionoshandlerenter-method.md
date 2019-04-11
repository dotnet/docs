---
title: "ICorProfilerCallback::ExceptionOSHandlerEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionOSHandlerEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionOSHandlerEnter"
helpviewer_keywords: 
  - "ExceptionOSHandlerEnter method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionOSHandlerEnter method [.NET Framework profiling]"
ms.assetid: 09238b9b-9359-4780-89dc-2f5e4f57920e
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ExceptionOSHandlerEnter Method
Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.  
  
## Syntax  
  
```  
HRESULT ExceptionOSHandlerEnter(  
    [in] UINT_PTR __unused);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
