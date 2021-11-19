---
description: "Learn more about: FunctionIDMapper Function"
title: "FunctionIDMapper Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionIDMapper"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionIDMapper"
helpviewer_keywords: 
  - "FunctionIDMapper function [.NET Framework profiling]"
ms.assetid: b8205b60-1893-4303-8cff-7ac5a00892aa
topic_type: 
  - "apiref"
---
# FunctionIDMapper Function

Notifies the profiler that the given identifier of a function may be remapped to an alternative ID to be used in the [FunctionEnter2](functionenter2-function.md), [FunctionLeave2](functionleave2-function.md), and [FunctionTailcall2](functiontailcall2-function.md) callbacks for that function. `FunctionIDMapper` also enables the profiler to indicate whether it wants to receive callbacks for that function.  
  
## Syntax  
  
```cpp  
UINT_PTR __stdcall FunctionIDMapper (  
    [in]  FunctionID  funcId,
    [out] BOOL       *pbHookFunction  
);  
```  
  
## Parameters

`funcId`
[in] The function identifier to be remapped.

`pbHookFunction`
[out] A pointer to a value that the profiler sets to `true` if it wants to receive `FunctionEnter2`, `FunctionLeave2`, and `FunctionTailcall2` callbacks; otherwise, it sets this value to `false`.

## Return Value  

 The profiler returns a value that the execution engine uses as an alternative function identifier. The return value cannot be null unless `false` is returned in `pbHookFunction`. Otherwise, a null return value will produce unpredictable results, including possibly halting the process.  
  
## Remarks  

 The `FunctionIDMapper` function is a callback. It is implemented by the profiler to remap a function ID to some other identifier that is more useful for the profiler. The `FunctionIDMapper` returns the alternate ID to be used for any given function. The execution engine then honors the profiler's request by passing this alternate ID, in addition to the traditional function ID, back to the profiler in the `clientData` parameter of the `FunctionEnter2`, `FunctionLeave2`, and `FunctionTailcall2` hooks, to identify the function for which the hook is being called.  
  
 You can use the [ICorProfilerInfo::SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md) method to specify the implementation of the `FunctionIDMapper` function. You can call the `ICorProfilerInfo::SetFunctionIDMapper` method only once, and we recommend that you do so in the [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
 By default, it is assumed that a profiler that sets the COR_PRF_MONITOR_ENTERLEAVE flag by using [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md), and which sets hooks via [ICorProfilerInfo::SetEnterLeaveFunctionHooks](icorprofilerinfo-setenterleavefunctionhooks-method.md) or [ICorProfilerInfo2::SetEnterLeaveFunctionHooks2](icorprofilerinfo2-setenterleavefunctionhooks2-method.md), should receive the `FunctionEnter2`, `FunctionLeave2`, and `FunctionTailcall2` callbacks for every function. However, profilers may implement `FunctionIDMapper` to selectively avoid receiving these callbacks for certain functions by setting `pbHookFunction` to `false`.  
  
 Profilers should be tolerant of cases where multiple threads of a profiled application are calling the same method/function simultaneously. In such cases, the profiler may receive multiple `FunctionIDMapper` callbacks for the same `FunctionID`. The profiler should be certain to return the same values from this callback when it is called multiple times with the same `FunctionID`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [SetFunctionIDMapper Method](icorprofilerinfo-setfunctionidmapper-method.md)
- [FunctionIDMapper2 Function](functionidmapper2-function.md)
- [FunctionEnter2 Function](functionenter2-function.md)
- [FunctionLeave2 Function](functionleave2-function.md)
- [FunctionTailcall2 Function](functiontailcall2-function.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
