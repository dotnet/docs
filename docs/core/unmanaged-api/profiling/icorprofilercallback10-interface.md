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
# ICorProfilerCallback10 interface

A subclass of [ICorProfilerCallback9](../../../framework/unmanaged-api/profiling/icorprofilercallback9-interface.md) that provides callback methods to notify the profiler that EventPipe events have been delivered to the profiler's currently active session.

## Methods

|Method|Description|
|------------|-----------------|
|[EventPipeEventDelivered Method](icorprofilercallback10-eventpipeeventdelivered-method.md)|Notifies the profiler that an EventPipe event has been delivered to the session that the profiler has open.|
|[EventPipeProviderCreated Method](icorprofilercallback10-eventpipeprovidercreated-method.md)|Notifies the profiler that an EventPipe provider has been created, allowing the profiler to add that provider to their session.|

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** Available since .NET 5.0

## See also

- [EventPipe Overview](../../../core/diagnostics/eventpipe.md)
- [Well Known EventProviders](../../../core/diagnostics/well-known-event-providers.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo12.EventPipeStartSession method](icorprofilerinfo12-eventpipestartsession-method.md)
- [ICorProfilerInfo12.EventPipeStopSession method](icorprofilerinfo12-eventpipestopsession-method.md)
