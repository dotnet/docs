---
description: "Learn more about: ICorProfilerCallback6 Interface"
title: "ICorProfilerCallback6 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback6"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
ms.assetid: edc420b7-96d1-4dec-ace0-36d907f644bc
topic_type: 
  - "apiref"
---
# ICorProfilerCallback6 Interface

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 A subclass of [ICorProfilerCallback5](icorprofilercallback5-interface.md) that provides a callback method that the common language runtime uses to notify a profiler that an assembly is loading.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetAssemblyReferences Method](icorprofilercallback6-getassemblyreferences-method.md)|Notifies the profiler that an assembly is in a very early loading stage, when the common language runtime performs an assembly reference closure walk.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
