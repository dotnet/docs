---
description: "Learn more about: ICorProfilerCallback::ExceptionOSHandlerLeave Method"
title: "ICorProfilerCallback::ExceptionOSHandlerLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionOSHandlerLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionOSHandlerLeave"
helpviewer_keywords: 
  - "ExceptionOSHandlerLeave method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionOSHandlerLeave method [.NET Framework profiling]"
ms.assetid: 4d164676-0ee9-4f67-a8ea-cb474db09053
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionOSHandlerLeave Method

Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionOSHandlerLeave(  
    [in] UINT_PTR __unused);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
