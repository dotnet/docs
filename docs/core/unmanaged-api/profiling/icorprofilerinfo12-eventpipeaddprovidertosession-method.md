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
# ICorProfilerInfo12::EventPipeAddProviderToSession method

Adds a provider to an existing EventPipe session.

## Syntax

```cpp
    HRESULT EventPipeAddProviderToSession(
        [in] EVENTPIPE_SESSION                 session,
        [in] COR_PRF_EVENTPIPE_PROVIDER_CONFIG providerConfig);
```

## Parameters

`session`\
[in] The ID of the session to add the provider to.

`providerConfig`\
[in] A `COR_PRF_EVENTPIPE_PROVIDER_CONFIG` describing the provider to add to the session.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 5.0

## See also

- [EventPipe Overview](../../../core/diagnostics/eventpipe.md)
- [Well Known EventProviders](../../../core/diagnostics/well-known-event-providers.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [COR_PRF_EVENTPIPE_PROVIDER_CONFIG Structure](cor-prf-eventpipe-provider-config-structure.md)
