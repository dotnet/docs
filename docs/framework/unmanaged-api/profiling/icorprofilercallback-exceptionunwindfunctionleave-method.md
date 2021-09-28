---
description: "Learn more about: ICorProfilerCallback::ExceptionUnwindFunctionLeave Method"
title: "ICorProfilerCallback::ExceptionUnwindFunctionLeave Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionUnwindFunctionLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFunctionLeave"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionUnwindFunctionLeave method [.NET Framework profiling]"
  - "ExceptionUnwindFunctionLeave method [.NET Framework profiling]"
ms.assetid: ebaad1d5-ee0a-4cb0-96bc-8ba5d371b747
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionUnwindFunctionLeave Method

Notifies the profiler that the unwind phase of exception handling has finished unwinding a function.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionUnwindFunctionLeave();  
```  
  
## Remarks  

 When the `ExceptionUnwindFunctionLeave` method is called, the function instance and its stack data are removed from the stack.  
  
 The profiler should not block during this call because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and a garbage collection is attempted, the runtime will block until this callback returns.  
  
 Also, during this call, the profiler must not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionUnwindFunctionEnter Method](icorprofilercallback-exceptionunwindfunctionenter-method.md)
