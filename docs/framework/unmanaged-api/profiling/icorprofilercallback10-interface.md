---
description: "Learn more about: ICorProfilerCallback10 Interface"
title: "ICorProfilerCallback10 Interface"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerCallback10"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerCallback10 Interface

 A subclass of [ICorProfilerCallback9](icorprofilercallback9-interface.md) that provides callback methods to notify the profiler that EventPipe events have been delivered to the profiler's currently active session.
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EventPipeEventDelivered Method](icorprofilercallback10-eventpipeeventdelivered-method.md)|Notifies the profiler that an EventPipe event has been delivered to the session that the profiler has open.|
|[EventPipeProviderCreated Method](icorprofilercallback10-eventpipeprovidercreated-method.md)|Notifies the profiler that an EventPipe provider has been created, allowing the profiler to add that provider the their session.|  
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]  

## See also

- [EventPipe Overview](../../../core/diagnostics/eventpipe.md)
- [Well Known EventProviders](../../../core/diagnostics/well-known-event-providers.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo12.EventPipeStartSession method](icorprofilerinfo12-eventpipestartsession-method.md)
- [ICorProfilerInfo12.EventPipeStopSession method](icorprofilerinfo12-eventpipestopsession-method.md)
