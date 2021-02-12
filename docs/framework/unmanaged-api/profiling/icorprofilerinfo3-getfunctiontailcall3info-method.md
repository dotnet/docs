---
description: "Learn more about: ICorProfilerInfo3::GetFunctionTailcall3Info Method"
title: "ICorProfilerInfo3::GetFunctionTailcall3Info Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.GetFunctionTailcall3Info Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetFunctionTailcall3Info"
helpviewer_keywords: 
  - "ICorProfilerInfo3::GetFunctionTailcall3Info method [.NET Framework profiling]"
  - "GetFunctionTailcall3Info method [.NET Framework profiling]"
ms.assetid: afdb5ac9-5bf5-4b91-b7cb-f81db23d7da3
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::GetFunctionTailcall3Info Method

Provides the stack frame of the function that is being reported to the profiler by the [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md) function. This method can be called only during the `FunctionTailcall3WithInfo` callback.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionTailcall3Info(
            [in]  FunctionID functionId,
            [in]  COR_PRF_ELT_INFO eltInfo,  
            [out] COR_PRF_FRAME_INFO *pFrameInfo);  
```  
  
## Parameters  

 `functionId`  
 [in] The `FunctionID` of the function that is returning.  
  
 `eltInfo`  
 [in] An opaque handle that represents information about a given stack frame. The profiler should provide the same `eltInfo` that was given to the profiler by the `FunctionTailcall3WithInfo` function.  
  
 `pFrameInfo`  
 [out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the `FunctionTailcall3WithInfo` callback in which the profiler called the `GetFunctionTailcall3Info` method.  
  
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
