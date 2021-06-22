---
description: "Learn more about: FunctionLeave3 Function"
title: "FunctionLeave3 Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionLeave3"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionLeave3"
helpviewer_keywords: 
  - "FunctionLeave3 function [.NET Framework profiling]"
ms.assetid: 5d798088-7992-48a0-ae55-d2a7ee31913f
topic_type: 
  - "apiref"
---
# FunctionLeave3 Function

Notifies the profiler that control is being returned from a function.  
  
## Syntax  
  
```cpp  
void __stdcall FunctionLeave3(FunctionOrRemappedID functionOrRemappedID);  
```  
  
## Parameters  

`functionOrRemappedID`
[in] The identifier of the function from which control is returned.
  
## Remarks  

 The `FunctionLeave3` callback function notifies the profiler as functions are being called, but does not support return value inspection. Use the [ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 method](icorprofilerinfo3-setenterleavefunctionhooks3-method.md) to register your implementation of this function.  
  
 The `FunctionLeave3` function is a callback; you must implement it. The implementation must use the `__declspec(naked)` storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
- On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
- On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionLeave3` should not block, because it will delay garbage collection. The implementation should not attempt a garbage collection, because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionLeave3` returns.  
  
 The `FunctionLeave3` function must not call into managed code or cause a managed memory allocation in any way.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [FunctionEnter3](functionenter3-function.md)
- [FunctionTailcall3](functiontailcall3-function.md)
- [FunctionEnter3WithInfo](functiontailcall3-function.md)
- [FunctionLeave3WithInfo](functionleave3withinfo-function.md)
- [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)
- [SetEnterLeaveFunctionHooks3](icorprofilerinfo3-setenterleavefunctionhooks3-method.md)
- [SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)
- [SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)
- [SetFunctionIDMapper2](icorprofilerinfo3-setfunctionidmapper2-method.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
