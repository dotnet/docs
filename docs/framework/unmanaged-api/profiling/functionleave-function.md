---
title: "FunctionLeave Function"
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
  - "FunctionLeave"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionLeave"
helpviewer_keywords: 
  - "FunctionLeave function [.NET Framework profiling]"
ms.assetid: 18e89f45-e068-426a-be16-9f53a4346860
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FunctionLeave Function
Notifies the profiler that a function is about to return to the caller.  
  
> [!NOTE]
>  The `FunctionLeave` function is deprecated in the .NET Framework 2.0. It will continue to work, but will incur a performance penalty. Use the [FunctionLeave2](../../../../docs/framework/unmanaged-api/profiling/functionleave2-function.md) function instead.  
  
## Syntax  
  
```  
void __stdcall FunctionLeave (  
    [in] FunctionID funcID  
);  
```  
  
#### Parameters  
 `funcID`  
 [in] The identifier of the function that is returning.  
  
## Remarks  
 The `FunctionLeave` function is a callback; you must implement it. The implementation must use the `__declspec`(`naked`) storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
-   On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
-   On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionLeave` should not block because it will delay garbage collection. The implementation should not attempt a garbage collection because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionLeave` returns.  
  
 Also, the `FunctionLeave` function must not call into managed code or in any way cause a managed memory allocation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See Also  
 [FunctionEnter2 Function](../../../../docs/framework/unmanaged-api/profiling/functionenter2-function.md)  
 [FunctionLeave2 Function](../../../../docs/framework/unmanaged-api/profiling/functionleave2-function.md)  
 [FunctionTailcall2 Function](../../../../docs/framework/unmanaged-api/profiling/functiontailcall2-function.md)  
 [SetEnterLeaveFunctionHooks2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-setenterleavefunctionhooks2-method.md)  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)
