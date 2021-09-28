---
description: "Learn more about: ICorProfilerCallback10::EventPipeEventDelivered Method"
title: "ICorProfilerCallback10::EventPipeEventDelivered Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerCallback10.EventPipeEventDelivered"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerCallback10::EventPipeEventDelivered Method

Notifies the profiler whenever an EventPipe event has been delivered to the profiler's currently active session.  
  
## Syntax  
  
```cpp  
    HRESULT EventPipeEventDelivered(
        [in] EVENTPIPE_PROVIDER provider,
        [in] DWORD eventId,
        [in] DWORD eventVersion,
        [in] ULONG cbMetadataBlob,
        [in, size_is(cbMetadataBlob)] LPCBYTE metadataBlob,
        [in] ULONG cbEventData,
        [in, size_is(cbEventData)] LPCBYTE eventData,
        [in] LPCGUID pActivityId,
        [in] LPCGUID pRelatedActivityId,
        [in] ThreadID eventThread,
        [in] ULONG numStackFrames,
        [in, length_is(numStackFrames)] UINT_PTR stackFrames[]);
```  
  
## Parameters

`provider`
[in] The provider that this event originated from.

`eventId`
[in] The ID of the event being delivered.

`eventVersion`
[in] The version of the event being delivered.

`cbMetadataBlob`
[in] The length, in bytes, of `metadataBlob`.

`metadataBlob`
[in] A pointer to the metadata blob for the event.

`cbEventData`
[in] The length, in bytes, of `eventData`.

`eventData`
[in] The payload for the event.

`pActivityId`
[in] A pointer to the GUID that represents the event's activity ID, or NULL.

`pRelatedActivityId`
[in] A pointer to the GUID that represents the event's related activity ID, or NULL.

`eventThread`
[in] The ID of the thread the event occurred on.

`numStackFrames`
[in] The number of elements in the `stackFrames` array.

`stackFrames`
[in] An array of code addresses representing the managed callstack of the event.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo12.EventPipeStartSession Method](icorprofilerinfo12-eventpipestartsession-method.md)
