---
description: "Learn more about: ICorProfilerInfo::SetEnterLeaveFunctionHooks Method"
title: "ICorProfilerInfo::SetEnterLeaveFunctionHooks Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.SetEnterLeaveFunctionHooks"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::SetEnterLeaveFunctionHooks"
helpviewer_keywords: 
  - "SetEnterLeaveFunctionHooks method [.NET Framework profiling]"
  - "ICorProfilerInfo::SetEnterLeaveFunctionHooks method [.NET Framework profiling]"
ms.assetid: 72399636-c219-4ffd-8ac8-39432c9d4641
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::SetEnterLeaveFunctionHooks Method

Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.  
  
## Syntax  
  
```cpp  
HRESULT SetEnterLeaveFunctionHooks(  
    [in] FunctionEnter    *pFuncEnter,  
    [in] FunctionLeave    *pFuncLeave,  
    [in] FunctionTailcall *pFuncTailcall);  
```  
  
## Parameters  

 `pFuncEnter`  
 [in] A pointer to the implementation to be used as the [FunctionEnter](functionenter-function.md) callback.  
  
 `pFuncLeave`  
 [in] A pointer to the implementation to be used as the [FunctionLeave](functionleave-function.md) callback.  
  
 `pFuncTailcall`  
 [in] A pointer to the implementation to be used as the [FunctionTailcall](functiontailcall-function.md) callback.  
  
## Remarks  

 In the .NET Framework version 1.0, each function pointer can be null to disable that corresponding callback.  
  
 Only one set of callbacks can be active at a time. Thus, if a profiler calls both `SetEnterLeaveFunctionHooks` and [ICorProfilerInfo2::SetEnterLeaveFunctionHooks2](icorprofilerinfo2-setenterleavefunctionhooks2-method.md), then `SetEnterLeaveFunctionHooks2` takes precedence.  
  
 The `SetEnterLeaveFunctionHooks` method can be called only from the profiler's [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
