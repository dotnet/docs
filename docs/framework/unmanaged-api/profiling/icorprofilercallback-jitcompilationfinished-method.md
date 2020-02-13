---
title: "ICorProfilerCallback::JITCompilationFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.JITCompilationFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITCompilationFinished"
helpviewer_keywords: 
  - "JITCompilationFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITCompilationFinished method [.NET Framework profiling]"
ms.assetid: 8dcd7537-d0c6-498c-8a56-2c060310ef65
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::JITCompilationFinished Method
Notifies the profiler that the just-in-time (JIT) compiler has finished compiling a function.  
  
## Syntax  
  
```cpp  
HRESULT JITCompilationFinished(  
    [in] FunctionID functionId,  
    [in] HRESULT    hrStatus,  
    [in] BOOL       fIsSafeToBlock);  
```  
  
## Parameters  
 `functionId`  
 [in] The ID of the function that was compiled.  
  
 `hrStatus`  
 [in] A value indicating whether compilation was successful.  
  
 `fIsSafeToBlock`  
 [in] A value indicating to the profiler whether blocking will affect the operation of the runtime. The value is `true` if blocking may cause the runtime to wait for the calling thread to return from this callback; otherwise, `false`.  
  
 Although a value of `true` will not harm the runtime, it can skew the profiling results.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [JITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationstarted-method.md)
