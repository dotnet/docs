---
description: "Learn more about: ICorProfilerCallback4 Interface"
title: "ICorProfilerCallback4 Interface"
ms.date: "03/30/2017"
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
---
# ICorProfilerCallback4 Interface

Provides callback methods that the common language runtime (CLR) uses to communicate information to the profiler.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReJITParameters Method](icorprofilercallback4-getrejitparameters-method.md)|Allows the code profiler to set alternate code generation flags for a new recompiled method body.|  
|[MovedReferences2 Method](icorprofilercallback4-movedreferences2-method.md)|Reports the new layout of objects in the heap as a result of a compacting garbage collection.|  
|[ReJITCompilationFinished Method](icorprofilercallback4-rejitcompilationfinished-method.md)|Notifies the profiler that the just-in-time (JIT) compiler has finished the recompilation of a function.|  
|[ReJITCompilationStarted Method](icorprofilercallback4-rejitcompilationstarted-method.md)|Notifies the profiler that the just-in-time (JIT) compiler has started to recompile a function.|  
|[ReJITError Method](icorprofilercallback4-rejiterror-method.md)|Reports an error encountered while processing a recompile request.|  
|[SurvivingReferences2 Method](icorprofilercallback4-survivingreferences2-method.md)|Reports the layout of objects in the heap as a result of a non-compacting garbage collection.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
