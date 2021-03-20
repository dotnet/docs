---
description: "Learn more about: ICorProfilerInfo12::EventPipeGetProviderInfo Method"
title: "ICorProfilerInfo12::EventPipeGetProviderInfo Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12.EventPipeGetProviderInfo"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12::EventPipeGetProviderInfo Method

Creates an EventPipe provider that the profiler can use to write events for other EventPipe listeners to receive.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeGetProviderInfo(
                [in] EVENTPIPE_PROVIDER provider,
                [in]  ULONG      cchName,
                [out] ULONG      *pcchName,
                [out, annotation("_Out_writes_to_(cchName, *pcchName)")]
                      WCHAR      providerName[]);
```  
  
## Parameters

`provider`
[in] The ID of the provider to provide the name for.

`cchName`
[in] The size, in characters, of `providerName`.

`pcchName`
[out] A pointer to the total character length of `providerName`.

`providerName`
[out] A caller provided wide character buffer. When the function returns the buffer will contain the name of the provider.

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
