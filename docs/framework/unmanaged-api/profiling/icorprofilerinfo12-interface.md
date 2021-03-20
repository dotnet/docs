---
description: "Learn more about: ICorProfilerInfo12 Interface"
title: "ICorProfilerInfo12 Interface"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12 Interface

 A subclass of [ICorProfilerInfo11](icorprofilerinfo11-interface.md) that provides methods to create EventPipe sessions, events, and providers.
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EventPipeStartSession Method](icorprofilerinfo12-eventpipestartsession-method.md)|Starts a profiler EventPipe session.|
|[EventPipeAddProviderToSession Method](icorprofilerinfo12-eventpipeaddprovidertosession-method.md)|Adds a provider to an existing EventPipe session.|
|[EventPipeStopSession Method](icorprofilerinfo12-eventpipestopsession-method.md)|Stops an EventPipe session.|
|[EventPipeCreateProvider Method](icorprofilerinfo12-eventpipecreateprovider-method.md)|Creates an EventPipe provider.|  
|[EventPipeGetProviderInfo Method](icorprofilerinfo12-eventpipegetproviderinfo-method.md)|Gets the name of an EventPipe provider from its ID.|
|[EventPipeDefineEvent Method](icorprofilerinfo12-eventpipedefineevent-method.md)|Defines an event on an existing EventPipe provider.|  
|[EventPipeWriteEvent Method](icorprofilerinfo12-eventpipewriteevent-method.md)|Writes an EventPipe event.|
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]  

## See also

- [EventPipe Overview](../../../core/diagnostics/eventpipe.md)
- [Well Known EventProviders](../../../core/diagnostics/well-known-event-providers.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
