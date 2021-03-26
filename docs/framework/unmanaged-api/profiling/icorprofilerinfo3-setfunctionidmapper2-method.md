---
description: "Learn more about: ICorProfilerInfo3::SetFunctionIDMapper2 Method"
title: "ICorProfilerInfo3::SetFunctionIDMapper2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.SetFunctionIDMapper2 Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::SetFunctionIDMapper2"
helpviewer_keywords: 
  - "SetFunctionIDMapper2 method [.NET Framework profiling]"
  - "ICorProfilerInfo3::SetFunctionIDMapper2 method [.NET Framework profiling]"
ms.assetid: 8cdb1188-952a-4ba8-9f05-bfebc18cdd29
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::SetFunctionIDMapper2 Method

Specifies the profiler-implemented function that will be called to map `FunctionID` values to alternative values, which are passed to the profiler's function entry/exit hooks. This method extends the [ICorProfilerInfo::SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md) method with an additional data parameter, which profilers may use to disambiguate among runtimes.  
  
## Syntax  
  
```cpp  
HRESULT SetFunctionIDMapper2(  
       [in] FunctionIDMapper2 *pFunc,  
       [in] void *clientData);  
```  
  
## Parameters  

 `pFunc`  
 [in] A pointer to a [FunctionIDMapper2](functionidmapper2-function.md) implementation that will be called to map the `FunctionID` values to their alternative values.  
  
 `clientData`  
 [in] A pointer that is passed to every [FunctionIDMapper2](functionidmapper2-function.md) function call made by the current runtime. The profiler can use this information to disambiguate among runtimes.  
  
## Return Value  
  
## Remarks  

 The alternatives for the FunctionID values will be passed to the profiler's function entry/exit hooks ([FunctionEnter3](functionenter3-function.md), [FunctionLeave3](functionleave3-function.md), and [FunctionTailcall3](functiontailcall3-function.md); or [FunctionEnter3WithInfo](functionenter3withinfo-function.md), [FunctionLeave3WithInfo](functionleave3withinfo-function.md), and [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)) that are specified by the [SetEnterLeaveFunctionHooks3](icorprofilerinfo3-setenterleavefunctionhooks3-method.md) or [SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md) method.  
  
 The `FunctionIDMapper2` method can be set only once; we recommend that you set it in the [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
