---
description: "Learn more about: FunctionLeave3WithInfo Function"
title: "FunctionLeave3WithInfo Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionLeave3WithInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionLeave3WithInfo"
helpviewer_keywords: 
  - "FunctionLeave3WithInfo function [.NET Framework profiling]"
ms.assetid: 5fa68a67-ced6-41c6-a2c0-467060fd0692
topic_type: 
  - "apiref"
---
# FunctionLeave3WithInfo Function

Notifies the profiler that control is being returned from a function, and provides a handle that can be passed to the [ICorProfilerInfo3::GetFunctionLeave3Info method](icorprofilerinfo3-getfunctionleave3info-method.md) to retrieve the stack frame and the return value.  
  
## Syntax  
  
```cpp  
void __stdcall FunctionLeave3WithInfo(  
               [in] FunctionIDOrClientID functionIDOrClientID,  
               [in] COR_PRF_ELT_INFO eltInfo);  
```  
  
## Parameters

`functionIDOrClientID`
[in] The identifier of the function from which control is returned.

`eltInfo`
[in] An opaque handle that represents information about a given stack frame. This handle is valid only during the callback to which it is passed.

## Remarks  

 The `FunctionLeave3WithInfo` callback method notifies the profiler as functions are called, and allows the profiler to use the [ICorProfilerInfo3::GetFunctionLeave3Info method](icorprofilerinfo3-getfunctionleave3info-method.md) to inspect the return value. To access return value information, the `COR_PRF_ENABLE_FUNCTION_RETVAL` flag has to be set. The profiler can use the [ICorProfilerInfo::SetEventMask method](icorprofilerinfo-seteventmask-method.md) to set the event flags, and then use the [ICorProfilerInfo3::SetEnterLeaveFunctionHooks3WithInfo method](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md) to register your implementation of this function.  
  
 The `FunctionLeave3WithInfo` function is a callback; you must implement it. The implementation must use the `__declspec(naked)` storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
- On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
- On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionLeave3WithInfo` should not block, because it will delay garbage collection. The implementation should not attempt a garbage collection, because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionLeave3WithInfo` returns.  
  
 The `FunctionLeave3WithInfo` function must not call into managed code or cause a managed memory allocation in any way.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [GetFunctionLeave3Info](icorprofilerinfo3-getfunctionleave3info-method.md)
- [FunctionEnter3](functionenter3-function.md)
- [FunctionLeave3](functionleave3-function.md)
- [FunctionTailcall3](functiontailcall3-function.md)
- [FunctionEnter3WithInfo](functionenter3withinfo-function.md)
- [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)
- [SetEnterLeaveFunctionHooks3](icorprofilerinfo3-setenterleavefunctionhooks3-method.md)
- [SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)
- [SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)
- [SetFunctionIDMapper2](icorprofilerinfo3-setfunctionidmapper2-method.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
