---
description: "Learn more about: ICorProfilerInfo12::EventPipeWriteEvent Method"
title: "ICorProfilerInfo12::EventPipeWriteEvent Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo12.EventPipeWriteEvent"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# ICorProfilerInfo12::EventPipeWriteEvent method

Writes an EventPipe event to any listeners who have enabled this event.

## Syntax

```cpp
    HRESULT EventPipeWriteEvent(
                [in] EVENTPIPE_EVENT    event,
                [in] UINT32             cData,
                [in, size_is(cData)]
                     COR_PRF_EVENT_DATA data[],
                [in] LPCGUID            pActivityId,
                [in] LPCGUID            pRelatedActivityId);
```

## Parameters

`event`\
[in] The ID of the event being written.

`cData`\
[in] The number of elements in `data`.

`data`\
[in] An array of `COR_PRF_EVENT_DATA` containing the event arguments.

`pActivityId`\
[in] A pointer to a GUID specifying the event's activity ID.

`pRelatedActivityId`\
[in] A pointer to a GUID specifying the event's related activity ID.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 5.0

## See also

- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [COR_PRF_EVENT_DATA Structure](cor-prf-event-data-structure.md)
