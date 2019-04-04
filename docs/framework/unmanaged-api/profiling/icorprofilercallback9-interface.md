---
title: "ICorProfilerCallback9 Interface"
ms.date: "04/10/2018"
api_name: 
  - "ICorProfilerCallback9"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorProfilerCallback9 Interface
[Supported in the .NET Framework 4.7.2 and later versions]  

 A subclass of [ICorProfilerCallback8](icorprofilercallback8-interface.md) that provides a callback method used by the common language runtime to notify the profiler that a dynamic method has been garbage collected and subsequently unloaded.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DynamicMethodUnloaded Method](ICorProfilerCallback9-dynamicmethodunloaded-method.md)|Notifies the profiler that a dynamic method has been garbage collected and subsequently unloaded.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  

## See also
- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback8 Interface](icorprofilercallback9-interface.md)
- [ICorProfilerCallback8.DynamicMethodJITCompilationStarted method](icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md)
- [ICorProfilerCallback8.DynamicMethodJITCompilationFinished method](icorprofilercallback8-dynamicmethodjitcompilationfinished-method.md)
