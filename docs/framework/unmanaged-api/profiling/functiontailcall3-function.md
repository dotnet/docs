---
description: "Learn more about: FunctionTailcall3 Function"
title: "FunctionTailcall3 Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionTailcall3"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionTailcall3"
helpviewer_keywords: 
  - "FunctionTailcall3 function [.NET Framework profiling]"
ms.assetid: 1e48243f-5de6-4bd6-a1d0-e1d248bca4b8
topic_type: 
  - "apiref"
---
# FunctionTailcall3 Function

Notifies the profiler that the currently executing function is about to perform a tail call to another function.  
  
## Syntax  
  
```cpp  
void __stdcall FunctionTailcall3 (FunctionOrRemappedID functionOrRemappedID);  
```  
  
## Parameters

`functionOrRemappedID`
[in] The identifier of the currently executing function that is about to make a tail call.

## Remarks  

 The `FunctionTailcall3` callback function notifies the profiler as functions are being called. Use the [ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 method](icorprofilerinfo3-setenterleavefunctionhooks3-method.md) to register your implementation of this function.  
  
 The `FunctionTailcall3` function is a callback; you must implement it. The implementation must use the `__declspec(naked)` storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
- On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
- On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionTailcall3` should not block, because it will delay garbage collection. The implementation should not attempt a garbage collection, because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionTailcall3` returns.  
  
 The `FunctionTailcall3` function must not call into managed code or cause a managed memory allocation in any way.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [FunctionEnter3](functionenter3-function.md)
- [FunctionLeave3](functionleave3-function.md)
- [FunctionEnter3WithInfo](functionenter3withinfo-function.md)
- [FunctionLeave3WithInfo](functionleave3withinfo-function.md)
- [FunctionTailcall3WithInfo Function](functiontailcall3withinfo-function.md)
- [SetEnterLeaveFunctionHooks3](icorprofilerinfo3-setenterleavefunctionhooks3-method.md)
- [SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)
- [SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)
- [SetFunctionIDMapper2](icorprofilerinfo3-setfunctionidmapper2-method.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
