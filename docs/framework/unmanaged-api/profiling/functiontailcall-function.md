---
description: "Learn more about: FunctionTailcall Function"
title: "FunctionTailcall Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionTailcall"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionTailcall"
helpviewer_keywords: 
  - "FunctionTailcall function [.NET Framework profiling]"
ms.assetid: 66347e03-9a97-41e8-8f9d-89b80803f7b5
topic_type: 
  - "apiref"
---
# FunctionTailcall Function

Notifies the profiler that the currently executing function is about to perform a tail call to another function.  
  
> [!NOTE]
> The `FunctionTailcall` function is deprecated in the .NET Framework version 2.0. It will continue to work, but will incur a performance penalty. Use the [FunctionTailcall2](functiontailcall2-function.md) function instead.  
  
## Syntax  
  
```cpp
void __stdcall FunctionTailcall (  
    [in] FunctionID funcID  
);  
```  
  
## Parameters

`funcID`
[in] The identifier of the currently executing function that is about to make a tail call.

## Remarks  

 The target function of the tail call will use the current stack frame, and will return directly to the caller of the function that made the tail call. This means that a [FunctionLeave](functionleave-function.md) callback will not be issued for a function that is the target of a tail call.  
  
 The `FunctionTailcall` function is a callback; you must implement it. The implementation must use the `__declspec`(`naked`) storage-class attribute.  
  
 The execution engine does not save any registers before calling this function.  
  
- On entry, you must save all registers that you use, including those in the floating-point unit (FPU).  
  
- On exit, you must restore the stack by popping off all the parameters that were pushed by its caller.  
  
 The implementation of `FunctionTailcall` should not block because it will delay garbage collection. The implementation should not attempt a garbage collection because the stack may not be in a garbage collection-friendly state. If a garbage collection is attempted, the runtime will block until `FunctionTailcall` returns.  
  
 Also, the `FunctionTailcall` function must not call into managed code or in any way cause a managed memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [FunctionEnter2 Function](functionenter2-function.md)
- [FunctionLeave2 Function](functionleave2-function.md)
- [SetEnterLeaveFunctionHooks2 Method](icorprofilerinfo2-setenterleavefunctionhooks2-method.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
