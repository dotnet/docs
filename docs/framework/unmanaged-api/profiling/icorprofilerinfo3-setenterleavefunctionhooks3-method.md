---
description: "Learn more about: ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 Method"
title: "ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.SetEnterLeaveFunctionHooks3 Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::SetEnterLeaveFunctionHooks3"
helpviewer_keywords: 
  - "SetEnterLeaveFunctionHooks3 method [.NET Framework profiling]"
  - "ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 method [.NET Framework profiling]"
ms.assetid: f0621465-b84f-40ab-a4e5-56a7abc776a7
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::SetEnterLeaveFunctionHooks3 Method

Specifies the profiler-implemented functions that will be called on the [FunctionEnter3](functionenter3-function.md), [FunctionLeave3](functionleave3-function.md), and [FunctionTailcall3](functiontailcall3-function.md) functions.  
  
## Syntax  
  
```cpp  
HRESULT SetEnterLeaveFunctionHooks3(  
            [in] FunctionEnter3    *pFuncEnter3,  
            [in] FunctionLeave3    *pFuncLeave3,  
            [in] FunctionTailcall3 *pFuncTailcall3);  
```  
  
## Parameters  

 `pFuncEnter3`  
 [in] A pointer to the implementation to be used as the `FunctionEnter3` callback.  
  
 `pFuncLeave3`  
 [in] A pointer to the implementation to be used as the `FunctionLeave3` callback.  
  
 `pFuncTailcall3`  
 [in] A pointer to the implementation to be used as the `FunctionTailcall3` callback.  
  
## Remarks  

 [FunctionEnter3](functionenter3-function.md), [FunctionLeave3](functionleave3-function.md), and [FunctionTailcall3](functiontailcall3-function.md) hooks do not provide stack frame and argument inspection. To access that information, the `COR_PRF_ENABLE_FUNCTION_ARGS`, `COR_PRF_ENABLE_FUNCTION_RETVAL`, and/or  `COR_PRF_ENABLE_FRAME_INFO` flags have to be set. The profiler can use the [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md) method to set the event flags, and then use the [ICorProfilerInfo3::SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md) method to register your implementation of this function.  
  
 Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore, if a profiler calls both the [SetEnterLeaveFunctionHooks2 Method](icorprofilerinfo2-setenterleavefunctionhooks2-method.md) and the `SetEnterLeaveFunctionHooks3` method, `SetEnterLeaveFunctionHooks3` is used.  
  
 The `SetEnterLeaveFunctionHooks3` method may be called only from the profiler's [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [SetEnterLeaveFunctionHooks3WithInfo](icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)
- [FunctionEnter3](functionenter3-function.md)
- [FunctionLeave3](functionleave3-function.md)
- [FunctionTailcall3](functiontailcall3-function.md)
- [FunctionEnter3WithInfo](functionenter3withinfo-function.md)
- [FunctionLeave3WithInfo](functionleave3withinfo-function.md)
- [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)
- [Profiling Global Static Functions](profiling-global-static-functions.md)
- [ICorProfilerInfo3](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
