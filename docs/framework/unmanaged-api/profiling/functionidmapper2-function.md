---
description: "Learn more about: FunctionIDMapper2 Function"
title: "FunctionIDMapper2 Function"
ms.date: "03/30/2017"
api_name: 
  - "FunctionIDMapper2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FunctionIDMapper2"
helpviewer_keywords: 
  - "FunctionIDMapper2 function [.NET Framework profiling]"
ms.assetid: 466ad51b-8f0c-41d9-81f7-371aac3374cb
topic_type: 
  - "apiref"
---
# FunctionIDMapper2 Function

Notifies the profiler that the given identifier of a function may be remapped to an alternative ID to be used in the [FunctionEnter3](functionenter3-function.md), [FunctionLeave3](functionleave3-function.md), and [FunctionTailcall3](functiontailcall3-function.md), or[FunctionEnter3WithInfo](functionenter3withinfo-function.md), [FunctionLeave3WithInfo](functionleave3withinfo-function.md), and [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md) callbacks for that function. `FunctionIDMapper2` also enables the profiler to indicate whether it wants to receive callbacks for that function.  
  
## Syntax  
  
```cpp  
UINT_PTR __stdcall FunctionIDMapper2 (  
    [in]  FunctionID  funcId,  
    [in]  void * clientData,  
    [out] BOOL       *pbHookFunction  
);  
```  
  
## Parameters

`funcId`
[in] The function identifier to be remapped.

`clientData`
[in] A pointer to data that is used to disambiguate among runtimes.

`pbHookFunction`
[out] A pointer to a value that the profiler sets to `true` if it wants to receive `FunctionEnter3`, `FunctionLeave3`, and `FunctionTailcall3`, or `FunctionEnter3WithInfo`, `FunctionLeave3WithInfo`, and `FunctionTailcall3WithInfo` callbacks; otherwise, it sets this value to `false`.

## Return Value  

 The profiler returns a value that the execution engine uses as an alternative function identifier. The return value cannot be null unless `false` is returned in `pbHookFunction`. Otherwise, a null return value produces unpredictable results, including possibly halting the process.  
  
## Remarks  

 This method extends the [FunctionIDMapper](functionidmapper-function.md) function with an additional parameter that is used to pass client data. The client data is used to disambiguate among runtimes.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo::SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)
- [ICorProfilerInfo3::SetFunctionIDMapper2](icorprofilerinfo3-setfunctionidmapper2-method.md)
- [FunctionEnter3](functionenter3-function.md)
- [FunctionLeave3](functionleave3-function.md)
- [FunctionTailcall3](functiontailcall3-function.md)
- [FunctionEnter3WithInfo](functionenter3withinfo-function.md)
- [FunctionLeave3WithInfo](functionleave3withinfo-function.md)
- [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
