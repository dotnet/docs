---
description: "Learn more about: ICorProfilerInfo::SetFunctionIDMapper Method"
title: "ICorProfilerInfo::SetFunctionIDMapper Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.SetFunctionIDMapper"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::SetFunctionIDMapper"
helpviewer_keywords: 
  - "ICorProfilerInfo::SetFunctionIDMapper method [.NET Framework profiling]"
  - "SetFunctionIDMapper method [.NET Framework profiling]"
ms.assetid: 1a6e5dae-d366-4497-9c02-7b5b1f43f9ec
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::SetFunctionIDMapper Method

Specifies the profiler-implemented function that will be called to map `FunctionID` values to alternative values, which are passed to the profiler's function entry/exit hooks.  
  
## Syntax  
  
```cpp  
HRESULT SetFunctionIDMapper (  
    [in] FunctionIDMapper *pFunc);  
```  
  
## Parameters  

 `pFunc`  
 [in] A pointer to the [FunctionIDMapper](functionidmapper-function.md) implementation that will be called to map the `FunctionID` values to their alternative values.  
  
## Remarks  

 The alternatives for the `FunctionID` values will be passed to the profiler's function entry/exit hooks ([FunctionEnter2](functionenter2-function.md), [FunctionLeave2](functionleave2-function.md), and [FunctionTailcall2](functiontailcall2-function.md)) that are specified by the [ICorProfilerInfo2::SetEnterLeaveFunctionHooks2](icorprofilerinfo2-setenterleavefunctionhooks2-method.md) method.  
  
 The `FunctionIDMapper` can be set only once and it is recommended that you set it in the [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
