---
description: "Learn more about: ICorProfilerInfo2::SetEnterLeaveFunctionHooks2 Method"
title: "ICorProfilerInfo2::SetEnterLeaveFunctionHooks2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.SetEnterLeaveFunctionHooks2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::SetEnterLeaveFunctionHooks2"
helpviewer_keywords: 
  - "ICorProfilerInfo2::SetEnterLeaveFunctionHooks2 method [.NET Framework profiling]"
  - "SetEnterLeaveFunctionHooks2 method [.NET Framework profiling]"
ms.assetid: 3c26b3e7-f72b-48a5-bf8c-edc122523a4b
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::SetEnterLeaveFunctionHooks2 Method

Specifies profiler-implemented functions to be called on the updated versions of the "enter", "leave", and "tailcall" hooks of managed functions.  
  
## Syntax  
  
```cpp  
HRESULT SetEnterLeaveFunctionHooks2(  
    [in] FunctionEnter2    *pFuncEnter,  
    [in] FunctionLeave2    *pFuncLeave,  
    [in] FunctionTailcall2 *pFuncTailcall);  
```  
  
## Parameters  

 `pFuncEnter`  
 [in] A pointer to the implementation to be used as the [FunctionEnter2](functionenter2-function.md) callback.  
  
 `pFuncLeave`  
 [in] A pointer to the implementation to be used as the [FunctionLeave2](functionleave2-function.md) callback.  
  
 `pFuncTailcall`  
 [in] A pointer to the implementation to be used as the [FunctionTailcall2](functiontailcall2-function.md) callback.  
  
## Remarks  

 The `SetEnterLeaveFunctionHooks2` method is similar to the [ICorProfilerInfo::SetEnterLeaveFunctionHooks](icorprofilerinfo-setenterleavefunctionhooks-method.md) method. Use the former to specify functions to be used as the newer versions of the enter/leave/tailcall callbacks, and the latter to specify functions to be used as the older versions of the enter/leave/tailcall callbacks.  
  
 Only one set of callbacks may be active at a time. Thus, if a profiler calls both `ICorProfilerInfo::SetEnterLeaveFunctionHooks` and `SetEnterLeaveFunctionHooks2`, `SetEnterLeaveFunctionHooks2` is used.  
  
 The `SetEnterLeaveFunctionHooks2` method may be called only from the profiler's [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
