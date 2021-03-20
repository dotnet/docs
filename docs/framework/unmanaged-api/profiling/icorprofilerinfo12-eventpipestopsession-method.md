---
description: "Learn more about: ICorProfilerInfo12::EventPipeStopSession Method"
title: "ICorProfilerInfo12::EventPipeStopSession Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12.EventPipeStopSession"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12::EventPipeStopSession Method

Stops an EventPipe session, preventing any future events from being written to the session.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeStopSession(
        [in] EVENTPIPE_SESSION session);
```  
  
## Parameters

`session`
[in] The ID of the session to stop.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
