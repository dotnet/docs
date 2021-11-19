---
description: "Learn more about: ICorProfilerCallback::ExceptionSearchFunctionEnter Method"
title: "ICorProfilerCallback::ExceptionSearchFunctionEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionSearchFunctionEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionSearchFunctionEnter"
helpviewer_keywords: 
  - "ExceptionSearchFunctionEnter method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionSearchFunctionEnter method [.NET Framework profiling]"
ms.assetid: bfd54573-b7e6-4bd1-a184-7f08a8b39fae
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionSearchFunctionEnter Method

Notifies the profiler that the search phase of exception handling has begun searching a function to find a handler for the current exception.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionSearchFunctionEnter(  
    [in] FunctionID functionId);  
```  
  
## Parameters

`functionId`
[in] The ID of the function that has been entered.
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionSearchFunctionLeave Method](icorprofilercallback-exceptionsearchfunctionleave-method.md)
