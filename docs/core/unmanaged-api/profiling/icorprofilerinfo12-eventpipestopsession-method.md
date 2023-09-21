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
# ICorProfilerInfo12::EventPipeStopSession method

Stops an EventPipe session, preventing any future events from being written to the session.

## Syntax

```cpp
    HRESULT EventPipeStopSession(
        [in] EVENTPIPE_SESSION session);
```

## Parameters

`session`\
[in] The ID of the session to stop.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** Available since .NET 5.0

## See also

- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
