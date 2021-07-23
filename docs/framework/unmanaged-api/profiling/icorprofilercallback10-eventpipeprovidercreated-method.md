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
---
# ICorProfilerCallback10::EventPipeProviderCreated Method

Notifies the profiler whenever an EventPipe provider is created.
  
## Syntax  
  
```cpp  
    HRESULT EventPipeProviderCreated([in] EVENTPIPE_PROVIDER provider);
```  
  
## Parameters

`provider`
[in] The provider that was created.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo12 Interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo12.EventPipeAddProviderToSession Method](icorprofilerinfo12-eventpipeaddprovidertosession-method.md)
