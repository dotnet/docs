---
description: "Learn more about: ICorProfilerCallback::ExceptionCatcherEnter Method"
title: "ICorProfilerCallback::ExceptionCatcherEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionCatcherEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionCatcherEnter"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionCatcherEnter method [.NET Framework profiling]"
  - "ExceptionCatcherEnter method [.NET Framework profiling]"
ms.assetid: 41462329-a648-46f0-ae6d-728b94c31aa9
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionCatcherEnter Method

Notifies the profiler that control is being passed to the appropriate `catch` block.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionCatcherEnter(  
    [in] FunctionID functionId,  
    [in] ObjectID   objectId);  
```  
  
## Parameters

`functionId`
[in] The identifier of the function containing the `catch` block.
  
`objectId`
[in] The identifier of the exception being handled.

## Remarks  

 The `ExceptionCatcherEnter` method is called only if the catch point is in code compiled with the just-in-time (JIT) compiler. An exception that is caught in unmanaged code or in the internal code of the runtime will not call this notification. The `objectId` value is passed again since a garbage collection could have moved the object since the `ExceptionThrown` notification.  
  
 The profiler should not block in its implementation of this method because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.  
  
 The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionCatcherLeave Method](icorprofilercallback-exceptioncatcherleave-method.md)
