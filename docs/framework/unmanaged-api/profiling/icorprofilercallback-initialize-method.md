---
description: "Learn more about: ICorProfilerCallback::Initialize Method"
title: "ICorProfilerCallback::Initialize Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.Initialize"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::Initialize"
helpviewer_keywords: 
  - "Initialize method, ICorProfilerCallback interface [.NET Framework profiling]"
  - "ICorProfilerCallback::Initialize method [.NET Framework profiling]"
ms.assetid: dc5fab2a-4b45-4b12-8727-b89c9915f23e
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::Initialize Method

Called to initialize the code profiler whenever a new common language runtime (CLR) application is started.  
  
## Syntax  
  
```cpp  
HRESULT Initialize(  
    [in] IUnknown     *pICorProfilerInfoUnk);  
```  
  
## Parameters

`pICorProfilerInfoUnk`
[in] Pointer to an [IUnknown](/cpp/atl/iunknown) interface that the profiler must query for an [ICorProfilerInfo](icorprofilerinfo-interface.md) interface pointer.  

## Remarks  

 The `Initialize` call is the only opportunity to enable (or disable) callbacks that are immutable. Once a callback is enabled by the `Initialize` call, it cannot be disabled later using [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md). The COR_PRF_MONITOR_IMMUTABLE value of the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration indicates which events are immutable.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [Shutdown Method](icorprofilercallback-shutdown-method.md)
