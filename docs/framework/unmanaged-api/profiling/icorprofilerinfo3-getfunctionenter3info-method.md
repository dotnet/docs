---
title: "ICorProfilerInfo3::GetFunctionEnter3Info Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorProfilerInfo3.GetFunctionEnter3Info Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetFunctionEnter3Info"
helpviewer_keywords: 
  - "GetFunctionEnter3Info method [.NET Framework profiling]"
  - "ICorProfilerInfo3::GetFunctionEnter3Info method [.NET Framework profiling]"
ms.assetid: 542c7c65-dd56-4651-b76f-5db2465e4a15
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo3::GetFunctionEnter3Info Method
Provides the stack frame and argument information of the function that is being reported to the profiler by the [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionenter3withinfo-function.md) function. This method can be called only during the `FunctionEnter3WithInfo` callback.  
  
## Syntax  
  
```  
HRESULT GetFunctionEnter3Info(  
            [in]  FunctionID functionId,   
            [in]  COR_PRF_ELT_INFO eltInfo,  
            [out] COR_PRF_FRAME_INFO *pFrameInfo,  
            [in, out] ULONG *pcbArgumentInfo,  
            [out, size_is(*pcbArgumentInfo)]  
                  COR_PRF_FUNCTION_ARGUMENT_INFO *pArgumentInfo);  
```  
  
#### Parameters  
 `functionId`  
 [in] The `FunctionID` of the function that is being entered.  
  
 `eltInfo`  
 [in] An opaque handle that represents information about a given stack frame. The profiler should provide the same `eltInfo` that it was given by the [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionenter3withinfo-function.md) function.  
  
 `pFrameInfo`  
 [out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the `FunctionEnter3WithInfo` callback in which the profiler called the `GetFunctionEnter3Info` method.  
  
 `pcbArgumentInfo`  
 [in, out] A pointer to the total size, in bytes, of the [COR_PRF_FUNCTION_ARGUMENT_INFO](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-info-structure.md) structure (plus any additional [COR_PRF_FUNCTION_ARGUMENT_RANGE](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-range-structure.md) structures for the argument ranges pointed to by `pArgumentInfo`). If the specified size is not enough, ERROR_INSUFFICIENT_BUFFER is returned and the expected size is stored in `pcbArgumentInfo`. To call `GetFunctionEnter3Info` just to retrieve the expected value for `*pcbArgumentInfo`, set `*pcbArgumentInfo`=0 and `pArgumentInfo`=NULL.  
  
 `pArgumentInfo`  
 [out] A pointer to a [COR_PRF_FUNCTION_ARGUMENT_INFO](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-info-structure.md) structure that describes the locations of the function's arguments in memory, in left-to-right order.  
  
## Remarks  
 The profiler must allocate sufficient space for the `COR_PRF_FUNCTION_ARGUMENT_INFO` structure of the function that is being inspected, and must indicate the size in the `pcbArgumentInfo` parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionenter3withinfo-function.md)  
 [FunctionLeave3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionleave3withinfo-function.md)  
 [FunctionTailcall3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3withinfo-function.md)  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
