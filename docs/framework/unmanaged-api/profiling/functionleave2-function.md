---
title: "FunctionLeave2 Function"
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
  - "FunctionLeave2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionLeave2"
helpviewer_keywords: 
  - "FunctionLeave2 function [.NET Framework profiling]"
ms.assetid: 8cdac941-8b94-4497-b874-4e571785f3fe
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FunctionLeave2 Function
Notifies the profiler that a function is about to return to the caller and provides information about the stack frame and function return value.  
  
## Syntax  
  
```  
void __stdcall FunctionLeave2 (  
    [in]  FunctionID                        funcId,  
    [in]  UINT_PTR                          clientData,  
    [in]  COR_PRF_FRAME_INFO                func,  
    [in]  COR_PRF_FUNCTION_ARGUMENT_RANGE  *retvalRange  
);  
```  
  
#### Parameters  
 `funcId`  
 [in] The identifier of the function that is returning.  
  
 `clientData`  
 [in] The remapped function identifier, which the profiler previously specified via the [FunctionIDMapper](../../../../docs/framework/unmanaged-api/profiling/functionidmapper-function.md) function.  
  
 `func`  
 [in] A `COR_PRF_FRAME_INFO` value that points to information about the stack frame.  
  
 The profiler should treat this as an opaque handle that can be passed back to the execution engine in the [ICorProfilerInfo2::GetFunctionInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getfunctioninfo2-method.md) method.  
  
 `retvalRange`  
 [in] A pointer to a [COR_PRF_FUNCTION_ARGUMENT_RANGE](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-range-structure.md) structure that specifies the memory location of the function's return value.  
  
 In order to access return value information, the `COR_PRF_ENABLE_FUNCTION_RETVAL` flag must be set. The profiler can use the [ICorProfilerInfo::SetEventMask](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-seteventmask-method.md) method to set the event flags.  
  
## Remarks  
 The values of the `func` and `retvalRange` parameters are not valid after the `FunctionLeave2` function returns because the values may change or be destroyed.  
  
 The `FunctionLeave2` function is a callback; you must implement it. The implementation must use the `__declspec`(`naked`) storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
-   On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
-   On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionLeave2` should not block because it will delay garbage collection. The implementation should not attempt a garbage collection because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionLeave2` returns.  
  
 Also, the `FunctionLeave2` function must not call into managed code or in any way cause a managed memory allocation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [FunctionEnter2 Function](../../../../docs/framework/unmanaged-api/profiling/functionenter2-function.md)  
 [FunctionTailcall2 Function](../../../../docs/framework/unmanaged-api/profiling/functiontailcall2-function.md)  
 [SetEnterLeaveFunctionHooks2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-setenterleavefunctionhooks2-method.md)  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)
