---
title: "ICorProfilerCallback8 Interface"
ms.date: "04/10/2018"
api_name: 
  - "ICorProfilerCallback8"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerCallback8 Interface
[Supported in the .NET Framework 4.7 and later versions]  

 A subclass of [ICorProfilerCallback7](icorprofilercallback7-interface.md) that provides callback methods used by the common language runtime to notify the profiler that JIT compilation of a dynamic method has started and finished. 
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DynamicMethodJITCompilationStarted Method](icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md)|Notifies the profiler that JIT compilation of a dynamic method has started.|  
|[DynamicMethodJITCompilationFinished Method](icorprofilercallback8-dynamicmethodjitcompilationfinished-method.md)|Notifies the profiler that JIT compilation of a dynamic method has finished.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback9 Interface](icorprofilercallback9-interface.md)
