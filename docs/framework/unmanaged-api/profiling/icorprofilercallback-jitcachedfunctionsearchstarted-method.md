---
title: "ICorProfilerCallback::JITCachedFunctionSearchStarted Method"
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
  - "ICorProfilerCallback.JITCachedFunctionSearchStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITCachedFunctionSearchStarted"
helpviewer_keywords: 
  - "JITCachedFunctionSearchStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITCachedFunctionSearchStarted method [.NET Framework profiling]"
ms.assetid: 5cba642c-0d80-48ee-889d-198c5044d821
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::JITCachedFunctionSearchStarted Method
Notifies the profiler that a search has started for a function that was compiled previously using the Native Image Generator (NGen.exe).  
  
## Syntax  
  
```  
HRESULT JITCachedFunctionSearchStarted(  
    [in]  FunctionID functionId,  
    [out] BOOL *pbUseCachedFunction);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function for which the search is being performed.  
  
 `pbUseCachedFunction`  
 [out] `true` if the execution engine should use the cached version of a function (if available); otherwise `false`. If the value is `false`, the execution engine JIT-compiles the function instead of using a version that is not JIT-compiled.  
  
## Remarks  
 In the .NET Framework version 2.0, the `JITCachedFunctionSearchStarted` and [ICorProfilerCallback::JITCachedFunctionSearchFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcachedfunctionsearchfinished-method.md) callbacks will not be made for all functions in regular NGen images. Only NGen images optimized for a profile will generate callbacks for all functions in the image. However, due to the additional overhead, a profiler should request profiler-optimized NGen images only if it intends to use these callbacks to force a function to be compiled just-in-time (JIT). Otherwise, the profiler should use a lazy strategy for gathering function information.  
  
 Profilers must support cases where multiple threads of a profiled application are calling the same method simultaneously. For example, thread A calls `JITCachedFunctionSearchStarted` and the profiler responds by setting *pbUseCachedFunction*to FALSE to force JIT compilation. Thread A then calls [ICorProfilerCallback::JITCompilationStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationstarted-method.md) and [ICorProfilerCallback::JITCompilationFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationfinished-method.md).  
  
 Now thread B calls `JITCachedFunctionSearchStarted` for the same function. Even though the profiler has stated its intention to JIT-compile the function, the profiler receives the second callback because thread B sends the callback before the profiler has responded to thread A's call to `JITCachedFunctionSearchStarted`. The order in which the threads make calls depends on how the threads are scheduled.  
  
 When the profiler receives duplicate callbacks, it must set the value referenced by `pbUseCachedFunction` to the same value for all the duplicate callbacks. That is, when `JITCachedFunctionSearchStarted` is called multiple times with the same `functionId` value, the profiler must respond the same each time.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
