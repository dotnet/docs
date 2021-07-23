---
description: "Learn more about: ICorProfilerCallback::ExceptionUnwindFinallyEnter Method"
title: "ICorProfilerCallback::ExceptionUnwindFinallyEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionUnwindFinallyEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFinallyEnter"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFinallyEnter method [.NET Framework profiling]"
  - "ExceptionUnwindFinallyEnter method [.NET Framework profiling]"
ms.assetid: c7fab986-b69f-4ec8-b7b7-91dcfc239cd0
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionUnwindFinallyEnter Method

Notifies the profiler that the unwind phase of exception handling is entering a `finally` clause contained in the specified function.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionUnwindFinallyEnter(  
    [in] FunctionID functionId);  
```  
  
## Parameters

`functionId`
[in] The ID of the function that contains the `finally` clause.

## Remarks  

 The profiler should not block in its implementation of this method because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.  
  
 The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [GetNotifiedExceptionClauseInfo Method](icorprofilerinfo2-getnotifiedexceptionclauseinfo-method.md)
- [ExceptionUnwindFinallyLeave Method](icorprofilercallback-exceptionunwindfinallyleave-method.md)
