---
title: "FunctionTailcall3WithInfo Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "FunctionTailcall3WithInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionTailcall3WithInfo"
helpviewer_keywords: 
  - "FunctionTailcall3WithInfo function [.NET Framework profiling]"
ms.assetid: 46380fcc-0198-43ae-a1f5-2d4939425886
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FunctionTailcall3WithInfo Function
Notifies the profiler that the currently executing function is about to perform a tail call to another function, and provides a handle that can be passed to the [ICorProfilerInfo3::GetFunctionTailcall3Info method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getfunctiontailcall3info-method.md) to retrieve the stack frame.  
  
## Syntax  
  
```  
void __stdcall FunctionTailcall3WithInfo(  
               [in] FunctionIDOrClientID functionIDOrClientID,  
               [in] COR_PRF_ELT_INFO eltInfo);  
```  
  
#### Parameters  
 `functionIDOrClientID`  
 [in] The identifier of the currently executing function that is about to make a tail call.  
  
 `eltInfo`  
 [in] An opaque handle that represents information about a given stack frame. This handle is valid only during the callback to which it is passed.  
  
## Remarks  
 The `FunctionTailcall3WithInfo` callback method notifies the profiler as functions are called, and allows the profiler to use the [ICorProfilerInfo3::GetFunctionTailcall3Info method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getfunctiontailcall3info-method.md) to inspect the stack frame. To access stack frame information, the `COR_PRF_ENABLE_FRAME_INFO` flag has to be set. The profiler can use the [ICorProfilerInfo::SetEventMask method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-seteventmask-method.md) to set the event flags, and then use the [ICorProfilerInfo3::SetEnterLeaveFunctionHooks3WithInfo method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md) to register your implementation of this function.  
  
 The `FunctionTailcall3WithInfo` function is a callback; you must implement it. The implementation must use the `__declspec(naked)` storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
-   On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
-   On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionTailcall3WithInfo` should not block, because it will delay garbage collection. The implementation should not attempt a garbage collection, because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionTailcall3WithInfo` returns.  
  
 Also, the FunctionTailcall3WithInfo function must not call into managed code or cause a managed memory allocation in any way.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [FunctionEnter3](../../../../docs/framework/unmanaged-api/profiling/functionenter3-function.md)  
 [FunctionLeave3](../../../../docs/framework/unmanaged-api/profiling/functionleave3-function.md)  
 [FunctionTailcall3](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3-function.md)  
 [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3-function.md)  
 [FunctionLeave3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionleave3withinfo-function.md)  
 [SetEnterLeaveFunctionHooks3](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setenterleavefunctionhooks3-method.md)  
 [SetEnterLeaveFunctionHooks3WithInfo](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)  
 [SetFunctionIDMapper](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setfunctionidmapper-method.md)  
 [SetFunctionIDMapper2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setfunctionidmapper2-method.md)  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)
