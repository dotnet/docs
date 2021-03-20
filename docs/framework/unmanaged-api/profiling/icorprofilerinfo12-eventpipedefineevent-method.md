---
description: "Learn more about: ICorProfilerInfo12::EventPipeDefineEvent Method"
title: "ICorProfilerInfo12::EventPipeDefineEvent Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo12.EventPipeDefineEvent"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo12::EventPipeDefineEvent Method

Defines an EventPipe event on an existing provider. This provider can be used to write EventPipe events that other listeners can receive.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeDefineEvent(
                [in] EVENTPIPE_PROVIDER     provider,
                [in, string] const WCHAR   *eventName,
                [in] UINT32                 eventID,
                [in] UINT64                 keywords,
                [in] UINT32                 eventVersion,
                [in] UINT32                 level,
                [in] UINT8                  opcode,
                [in] BOOL                   needStack,
                [in] UINT32                 cParamDescs,
                [in, size_is(cParamDescs)]
                     COR_PRF_EVENTPIPE_PARAM_DESC pParamDescs[],
                [out] EVENTPIPE_EVENT      *pEvent);
```  
  
## Parameters

`provider`
[in] The ID of the provider to define an event on.

`eventName`
[in] A pointer to a null terminated wide character string that contains the event name.

`eventID`
[in] The ID of the event being defined.

`keywords`
[in] The keywords of the event being defined.

`eventVersion`
[in] The version of the event being defined.

`level`
[in] The level of the event being defined.

`opcode`
[in] The opcode of the event being defined.

`needStack`
[in] A `BOOL` indicating whether managed stacks should be collected each time this event fires.

`cParamDescs`
[in] The count of the number of parameters in `pParamDescs`.

`pParamDescs`
[in] An array of `COR_PRF_EVENTPIPE_PARAM_DESC` defining the parameter types to the event being defined.

`pEvent`
[out] A caller provided pointer that will be filled with the ID of the event being defined when the function returns.

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
- [COR_PRF_EVENTPIPE_PARAM_DESC Structure](cor-prf-eventpipe-param-desc-structure.md)
