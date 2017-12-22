---
title: "ICorProfilerCallback4::ReJITCompilationFinished Method"
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
  - "ICorProfilerCallback4.ReJITCompilationFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4::ReJITCompilationFinished"
helpviewer_keywords: 
  - "ICorProfilerCallback4::ReJITCompilationFinished method [.NET Framework profiling]"
  - "ReJITCompilationFinished method, ICorProfilerCallback4 interface [.NET Framework profiling]"
ms.assetid: 3b5cff02-2005-44eb-a2bc-50214c4b0e1d
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback4::ReJITCompilationFinished Method
Notifies the profiler that the just-in-time (JIT) compiler has finished recompiling a function.  
  
## Syntax  
  
```  
HRESULT ReJITCompilationFinished(  
    [in] FunctionID functionId,    [in] ReJITID rejitId,  
    [in] HRESULT    hrStatus,  
    [in] BOOL       fIsSafeToBlock);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that was recompiled.  
  
 `rejitId`  
 [in] The identity of the JIT-recompiled function.  
  
 `hrStatus`  
 [in] A value that indicates whether the JIT recompilation was successful.  
  
 `fIsSafeToBlock`  
 [in] `true` to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; `false` to indicate that blocking will not affect the operation of the runtime.  
  
 A value of `true` does not harm the runtime, but can affect the profiling results.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)  
 [JITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationstarted-method.md)  
 [ReJITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejitcompilationstarted-method.md)
