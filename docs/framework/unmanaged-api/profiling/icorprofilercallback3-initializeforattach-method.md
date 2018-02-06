---
title: "ICorProfilerCallback3::InitializeForAttach Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback3::InitializeForAttach Method
Called by the common language runtime (CLR) to give the profiler an opportunity to initialize its state after an attach operation.  
  
## Syntax  
  
```  
HRESULT InitializeForAttach(  
            [in] IUnknown * pCorProfilerInfoUnk,  
            [in] void * pvClientData,  
            [in] UINT cbClientData);  
```  
  
#### Parameters  
 `pCorProfilerInfoUnk`  
 [in] An interface pointer for the `ICorProfilerInfo*` interface.  
  
 `pvClientData`  
 [in] A pointer to the data passed to the [IClrProfiling::AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md) method in its `pvClientData` parameter. If this parameter is null, `cbClientData` will be 0 (zero). The CLR frees this memory when it returns from `InitializeForAttach`.  
  
 `cbClientData`  
 [in] The size, in bytes, of the data that `pvClientData` points to.  
  
## Remarks  
 The CLR calls `InitializeForAttach` to give the profiler an opportunity to request callbacks.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
