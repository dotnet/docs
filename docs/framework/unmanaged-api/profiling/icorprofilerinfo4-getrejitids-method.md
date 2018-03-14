---
title: "ICorProfilerInfo4::GetReJITIDs Method"
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
  - "ICorProfilerInfo4.GetReJITIDs"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::GetReJITIDs"
helpviewer_keywords: 
  - "GetReJITIDs method, ICorProfilerInfo4 interface [.NET Framework profiling]"
  - "ICorProfilerInfo4::GetReJITIDs method [.NET Framework profiling]"
ms.assetid: 634ac28c-a5b7-4fc3-af84-256c24ca8177
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo4::GetReJITIDs Method
Returns an array of IDs that identify all JIT-recompiled versions of the specified function that are still allocated. This includes JIT-recompiled versions of functions that have been subsequently reverted but not yet freed (for example, when the application domain that contains the reverted function is still in use).  
  
## Syntax  
  
```  
HRESULT GetReJITIDs (  
     [in]  FunctionID          functionId,  
     [in]  ULONG               cReJitIds,  
     [out] ULONG *             pcReJitIds,  
     [out, size_is(cReJitIds), length_is(*pcReJitIds)]   ReJITID        reJitIds[]);  
```  
  
#### Parameters  
 `functionId`  
 [in] The `FunctionID` of the function instance for which to enumerate versions.  
  
 `cReJitIds`  
 [in] The number of JIT-recompiled IDs allocated in the `reJitIds` array.  
  
 `pcReJitIds`  
 [out] The actual number of JIT-recompiled IDs.  
  
 `reJitIds`  
 [out] A caller-allocated array that will contain the JIT-recompiled IDs for the specified function.  
  
## Remarks  
 `GetReJITIDs` enumerates the active JIT-recompiled IDs for a given function instance. It follows the same usage pattern as other `ICorProfilerInfo` functions that accept caller-allocated buffers.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
