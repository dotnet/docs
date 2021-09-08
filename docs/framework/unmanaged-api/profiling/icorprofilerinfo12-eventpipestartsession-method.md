---
description: "Learn more about: ICorProfilerInfo12::EventPipeStartSession Method"
title: "ICorProfilerInfo12::EventPipeStartSession Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12.EventPipeStartSession"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12::EventPipeStartSession Method

Starts an EventPipe session. The session can be used by the profiler to write events which can be listened to by any EventPipe consumer.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeStartSession(
        [in]  UINT32                            cProviderConfigs,
        [in, size_is(cProviderConfigs)]
              COR_PRF_EVENTPIPE_PROVIDER_CONFIG pProviderConfigs[],
        [in]  BOOL                              requestRundown,
        [out] EVENTPIPE_SESSION*                pSession);
```  
  
## Parameters

`cProviderConfigs`
[in] The number of providers in `pProviderConfigs`.

`pProviderConfigs`
[in] An array of `COR_PRF_EVENTPIPE_PROVIDER_CONFIG` used to specify what providers should be enabled for the session.

`requestRundown`
[in] A `BOOL` indicating whether to emit rundown events when the session is closed.

`pSession`
[out] A caller provided pointer that will be filled with the session ID when the method returns.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [EventPipe Overview](../../../core/diagnostics/eventpipe.md)
- [Well Known EventProviders](../../../core/diagnostics/well-known-event-providers.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
