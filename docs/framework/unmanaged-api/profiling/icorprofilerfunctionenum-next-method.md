---
title: "ICorProfilerFunctionEnum::Next Method"
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
  - "ICorProfilerFunctionEnum.Next Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionEnum::Next"
helpviewer_keywords: 
  - "ICorProfilerFunctionEnum::Next method [.NET Framework profiling]"
  - "Next method, ICorProfilerFunctionEnum interface [.NET Framework profiling]"
ms.assetid: 5ed4aa83-ce56-4b9f-9237-5da7587787fe
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerFunctionEnum::Next Method
Gets the specified number of contiguous functions from a sequential collection of functions, starting at the enumerator's current position in the sequence.  
  
## Syntax  
  
```  
HRESULT Next([in]  ULONG      celt,  
             [out, size_is(celt), length_is(*pceltFetched)]  
                    COR_PRF_FUNCTION ids[],  
             [out] ULONG *   pceltFetched);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of functions to retrieve.  
  
 `ids`  
 [out] An array of `COR_PRF_FUNCTION` values, each of which represents a retrieved function.  
  
 `pceltFetched`  
 [out] A pointer to the number of functions actually returned in the `ids` array.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`celt` elements were returned.|  
|S_FALSE|Fewer than `celt` elements were returned, which indicates that the enumeration is complete.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerFunctionEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctionenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
