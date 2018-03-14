---
title: "ICorProfilerCallback::JITCachedFunctionSearchFinished Method"
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
  - "ICorProfilerCallback.JITCachedFunctionSearchFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITCachedFunctionSearchFinished"
helpviewer_keywords: 
  - "JITCachedFunctionSearchFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITCachedFunctionSearchFinished method [.NET Framework profiling]"
ms.assetid: 3c325c82-cddd-4b00-b3da-e450c36abf62
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::JITCachedFunctionSearchFinished Method
Notifies the profiler that a search has finished for a function that was compiled previously using the Native Image Generator (NGen.exe).  
  
## Syntax  
  
```  
HRESULT JITCachedFunctionSearchFinished(  
    [in] FunctionID        functionId,  
    [in] COR_PRF_JIT_CACHE result);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function for which the search was performed.  
  
 `result`  
 [in] A value of the [COR_PRF_JIT_CACHE](../../../../docs/framework/unmanaged-api/profiling/cor-prf-jit-cache-enumeration.md) enumeration that indicates the result of the search.  
  
## Remarks  
 In the .NET Framework version 2.0, the [ICorProfilerCallback::JITCachedFunctionSearchStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcachedfunctionsearchstarted-method.md) and `JITCachedFunctionSearchFinished` callbacks will not be made for all functions in regular NGen images. Only NGen images optimized for a profiler will generate callbacks for all functions in the image. However, due to the additional overhead, a profiler should request profiler-optimized NGen images only if it intends to use these callbacks to force a function to be compiled just-in-time (JIT). Otherwise, the profiler should use a lazy strategy for gathering function information.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
