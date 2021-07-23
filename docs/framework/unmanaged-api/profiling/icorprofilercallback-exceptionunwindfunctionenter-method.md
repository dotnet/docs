---
description: "Learn more about: ICorProfilerCallback::ExceptionUnwindFunctionEnter Method"
title: "ICorProfilerCallback::ExceptionUnwindFunctionEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionUnwindFunctionEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFunctionEnter"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFunctionEnter method [.NET Framework profiling]"
  - "ExceptionUnwindFunctionEnter method [.NET Framework profiling]"
ms.assetid: ea3dc625-5650-4bf4-8e67-01e42be065b1
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionUnwindFunctionEnter Method

Notifies the profiler that the unwind phase of exception handling has begun to unwind a function.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionUnwindFunctionEnter(  
    [in] FunctionID functionId);  
```  
  
## Parameters

`functionId`
[in] The ID of the function that is being unwound.

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
- [ExceptionUnwindFunctionLeave Method](icorprofilercallback-exceptionunwindfunctionleave-method.md)
