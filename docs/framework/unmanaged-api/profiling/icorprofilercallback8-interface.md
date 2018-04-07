---
title: "ICorProfilerCallback8 Interface"
ms.custom: ""
ms.date: "04/10/2018"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
api_name: 
  - "ICorProfilerCallback8"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback8 Interface
[Supported in the .NET Framework 4.7.1 and later versions]  

 A subclass of [ICorProfilerCallback7](icorprofilercallback7-interface.md) that provides callback methods used by the common language runtime to notify the profiler that JIT compilation of a dynamic method has started and finished. 
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DynamicMethodJITCompilationStarted Method](icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md)|Notifies the profiler that JIT compilation of a dynamic method has started.|  
|[DynamicMethodJITCompilationFinished Method](icorprofilercallback8-dynamicmethodjitcompilationfinished-method.md)|Notifies the profiler that JIT compilation of a dynamic method has finished.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
**.NET Framework Versions:** [!INCLUDE[net_current_v471plus](../../../../includes/net-current-v471plus.md)]  

## See Also  
[Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)   
[ICorProfilerCallback9 Interface](icorprofilercallback9-interface.md)
