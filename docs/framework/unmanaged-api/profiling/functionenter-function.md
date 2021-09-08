---
description: "Learn more about: FunctionEnter Function"
title: "FunctionEnter Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionEnter"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionEnter"
helpviewer_keywords: 
  - "FunctionEnter function [.NET Framework profiling]"
ms.assetid: bf4ffa50-4506-4dd4-aa13-a0457b47ca74
topic_type: 
  - "apiref"
---
# FunctionEnter Function

Notifies the profiler that control is being passed to a function.  
  
> [!NOTE]
> The `FunctionEnter` function is deprecated in the .NET Framework version 2.0, and its use will incur a performance penalty. Use the [FunctionEnter2](functionenter2-function.md) function instead.  
  
## Syntax  
  
```cpp  
void __stdcall FunctionEnter (  
    [in]  FunctionID funcID  
);  
```  
  
## Parameters

`funcID`
[in] The identifier of the function to which control is passed.

## Remarks  

 The `FunctionEnter` function is a callback; you must implement it. The implementation must use the `__declspec`(`naked`) storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
- On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
- On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionEnter` should not block because it will delay garbage collection. The implementation should not attempt a garbage collection because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionEnter` returns.  
  
 Also, the `FunctionEnter` function must not call into managed code or in any way cause a managed memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [FunctionEnter2 Function](functionenter2-function.md)
- [FunctionLeave2 Function](functionleave2-function.md)
- [FunctionTailcall2 Function](functiontailcall2-function.md)
- [SetEnterLeaveFunctionHooks2 Method](icorprofilerinfo2-setenterleavefunctionhooks2-method.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
