---
description: "Learn more about: ICorProfilerCallback10::EventPipeProviderCreated Method"
title: "ICorProfilerCallback10::EventPipeProviderCreated Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerCallback10.EventPipeProviderCreated"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
ms.topic: article
---
# ICorProfilerCallback10::EventPipeProviderCreated method

Notifies the profiler whenever an EventPipe provider is created.

## Syntax

```cpp
HRESULT EventPipeProviderCreated([in] EVENTPIPE_PROVIDER provider);
```

## Parameters

`provider`\
[in] The provider that was created.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 5.0

## See also

- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo12.EventPipeAddProviderToSession Method](icorprofilerinfo12-eventpipeaddprovidertosession-method.md)
