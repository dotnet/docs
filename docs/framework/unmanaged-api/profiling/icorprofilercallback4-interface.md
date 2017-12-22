---
title: "ICorProfilerCallback4 Interface"
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
  - "ICorProfilerCallback4"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4"
helpviewer_keywords: 
  - "ICorProfilerCallback4 interface [.NET Framework profiling]"
ms.assetid: 665f3cfc-cd6f-4880-906c-ea65ad384783
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback4 Interface
Provides callback methods that the common language runtime (CLR) uses to communicate information to the profiler.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReJITParameters Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-getrejitparameters-method.md)|Allows the code profiler to set alternate code generation flags for a new recompiled method body.|  
|[MovedReferences2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-movedreferences2-method.md)|Reports the new layout of objects in the heap as a result of a compacting garbage collection.|  
|[ReJITCompilationFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejitcompilationfinished-method.md)|Notifies the profiler that the just-in-time (JIT) compiler has finished the recompilation of a function.|  
|[ReJITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejitcompilationstarted-method.md)|Notifies the profiler that the just-in-time (JIT) compiler has started to recompile a function.|  
|[ReJITError Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejiterror-method.md)|Reports an error encountered while processing a recompile request.|  
|[SurvivingReferences2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-survivingreferences2-method.md)|Reports the layout of objects in the heap as a result of a non-compacting garbage collection.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
