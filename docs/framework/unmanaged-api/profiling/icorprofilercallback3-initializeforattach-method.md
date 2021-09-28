---
description: "Learn more about: ICorProfilerCallback3::InitializeForAttach Method"
title: "ICorProfilerCallback3::InitializeForAttach Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback3.InitializeForAttach Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback3::InitializeForAttach"
helpviewer_keywords: 
  - "InitializeForAttach method [.NET Framework profiling]"
  - "ICorProfilerCallback3::InitializeForAttach method [.NET Framework profiling]"
ms.assetid: bed097b3-6d52-46c9-bee7-ac7910b6fc3f
topic_type: 
  - "apiref"
---
# ICorProfilerCallback3::InitializeForAttach Method

Called by the common language runtime (CLR) to give the profiler an opportunity to initialize its state after an attach operation.  
  
## Syntax  
  
```cpp  
HRESULT InitializeForAttach(  
            [in] IUnknown * pCorProfilerInfoUnk,  
            [in] void * pvClientData,  
            [in] UINT cbClientData);  
```  
  
## Parameters  

 `pCorProfilerInfoUnk`  
 [in] An interface pointer for the `ICorProfilerInfo*` interface.  
  
 `pvClientData`  
 [in] A pointer to the data passed to the [IClrProfiling::AttachProfiler](iclrprofiling-attachprofiler-method.md) method in its `pvClientData` parameter. If this parameter is null, `cbClientData` will be 0 (zero). The CLR frees this memory when it returns from `InitializeForAttach`.  
  
 `cbClientData`  
 [in] The size, in bytes, of the data that `pvClientData` points to.  
  
## Remarks  

 The CLR calls `InitializeForAttach` to give the profiler an opportunity to request callbacks.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
