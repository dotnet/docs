---
title: "ICorProfilerCallback7 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback7"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
ms.assetid: a0be019e-aaa1-4036-990f-565f114d4b5c
---
# ICorProfilerCallback7 Interface
[Supported in the .NET Framework 4.6.1 and later versions]  
  
 A subclass of [ICorProfilerCallback6](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-interface.md) that provides a callback method that the common language runtime uses to notify the profiler that the symbol stream associated with an in-memory module is updated.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ModuleInMemorySymbolsUpdated Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback7-moduleinmemorysymbolsupdated-method.md)|Notifies the profiler that the symbol stream associated with an in-memory module is updated.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v461plus](../../../../includes/net-current-v461plus-md.md)]  
  
## See also

- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
