---
description: "Learn more about: ICorProfilerCallback3 Interface"
title: "ICorProfilerCallback3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback3"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback3"
helpviewer_keywords: 
  - "ICorProfilerCallback3 interface [.NET Framework profiling]"
ms.assetid: be83af41-3dec-4c77-8529-9dd6b8042af6
topic_type: 
  - "apiref"
---
# ICorProfilerCallback3 Interface

Provides callback methods that the common language runtime (CLR) uses to communicate attach and detach state information to the profiler.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[InitializeForAttach Method](icorprofilercallback3-initializeforattach-method.md)|Called by the CLR to give the profiler an opportunity to initialize its state after an attach operation.|  
|[ProfilerAttachComplete Method](icorprofilercallback3-profilerattachcomplete-method.md)|Called by the CLR to indicate that the profiler can now call the catch-up methods.|  
|[ProfilerDetachSucceeded Method](icorprofilercallback3-profilerdetachsucceeded-method.md)|Notifies the profiler that the common language runtime (CLR) is about to unload the profiler DLL.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
- [ICorProfilerCallback4 Interface](icorprofilercallback4-interface.md)
