---
title: "ICorProfilerCallback8::DynamicMethodJITCompilationFinished Method"
ms.date: "04/10/2018"
api_name: 
  - "ICorProfilerCallback8.DynamicMethodJITCompilationFinished"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorProfilerCallback8::DynamicMethodJITCompilationFinished Method
[Supported in the .NET Framework 4.7 and later versions]  
  
Notifies the profiler whenever JIT compilation of a dynamic method has completed.  
  
## Syntax  
  
```  
HRESULT DynamicMethodJITCompilationFinished(  
     [in]  FunctionID  functionId,   
     [in]  BOOL        hrStatus,   
     [in]  BOOL        fIsSafeToBlock   
);  
```  
  
#### Parameters  
[in] `functionId`  
The identifier of the in-memory function for which JIT compilation is started.   

[in] `hrStatus`   
A value that indicates whether the JIT compilation was successful.

[in] `fIsSafeToBlock`   
`true` to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; `false` to indicate that blocking will not affect the operation of the runtime.  

## Remarks  

This callback is triggered whenever JIT compilation of a dynamic method has finished. This includes various IL stubs and LCG methods. Its goal is to provide profiler writers with enough information to identify the compiled method to users.

> [!NOTE]
> `functionId` values cannot be used to resolve to their metadata tokens, because dynamic methods have no metadata.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  
  
## See also
- [DynamicMethodJITCompilationStarted Method](icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md)
- [ICorProfilerCallback8 Interface](icorprofilercallback8-interface.md)
