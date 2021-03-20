---
description: "Learn more about: ICorProfilerInfo12::EventPipeAddProviderToSession Method"
title: "ICorProfilerInfo12::EventPipeAddProviderToSession Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12.EventPipeAddProviderToSession"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12::EventPipeAddProviderToSession Method

Adds a provider to an existing EventPipe session.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeAddProviderToSession(
        [in] EVENTPIPE_SESSION                 session,
        [in] COR_PRF_EVENTPIPE_PROVIDER_CONFIG providerConfig);
```  
  
## Parameters

`session`
[in] The ID of the session to add the provider to.

`providerConfig`
[in] A `COR_PRF_EVENTPIPE_PROVIDER_CONFIG` describing the provider to add to the session.

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
- [COR_PRF_EVENTPIPE_PROVIDER_CONFIG Structure](cor-prf-eventpipe-provider-config-structure.md)
