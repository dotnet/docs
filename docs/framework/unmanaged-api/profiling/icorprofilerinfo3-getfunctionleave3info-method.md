---
description: "Learn more about: ICorProfilerInfo3::GetFunctionLeave3Info Method"
title: "ICorProfilerInfo3::GetFunctionLeave3Info Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.GetFunctionLeave3Info Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetFunctionLeave3Info"
helpviewer_keywords: 
  - "GetFunctionLeave3Info method [.NET Framework profiling]"
  - "ICorProfilerInfo3::GetFunctionLeave3Info method [.NET Framework profiling]"
ms.assetid: df7083d2-fd43-44c7-9ce5-912c25cef0ff
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::GetFunctionLeave3Info Method

Provides the stack frame and return value of the function that is being reported to the profiler by the [FunctionLeave3WithInfo function](functionleave3withinfo-function.md) function. This method can be called only during the `FunctionLeave3WithInfo` callback.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionLeave3Info(  
            [in]  FunctionID functionId,  
            [in]  COR_PRF_ELT_INFO eltInfo,  
            [out] COR_PRF_FRAME_INFO *pFrameInfo,  
            [out] COR_PRF_FUNCTION_ARGUMENT_RANGE *pRetvalRange);  
```  
  
## Parameters  

 `functionId`  
 [in] The `FunctionID` of the function that is returning.  
  
 `eltInfo`  
 [in] An opaque handle that represents information about a given stack frame. The profiler should provide the same `eltInfo` that was given to the profiler by the [FunctionLeave3WithInfo](functionleave3withinfo-function.md) function.  
  
 `pFrameInfo`  
 [out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the `FunctionLeave3WithInfo` callback in which the profiler called the `GetFunctionLeave3Info` method.  
  
 `pRetvalRange`  
 [out] A pointer to a [COR_PRF_FUNCTION_ARGUMENT_RANGE](cor-prf-function-argument-range-structure.md) structure that contains the value that is returned from the function. To access return value information, the `COR_PRF_ENABLE_FUNCTION_RETVAL` flag must be set. The profiler can use the [ICorProfilerInfo::SetEventMask method](icorprofilerinfo-seteventmask-method.md) to set the event flags.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [FunctionEnter3WithInfo](functionenter3withinfo-function.md)
- [FunctionLeave3WithInfo](functionleave3withinfo-function.md)
- [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
