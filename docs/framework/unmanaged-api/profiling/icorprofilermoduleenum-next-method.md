---
title: "ICorProfilerModuleEnum::Next Method"
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
  - "ICorProfilerModuleEnum.Next Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum::Next"
helpviewer_keywords: 
  - "ICorProfilerModuleEnum::Next method [.NET Framework profiling]"
  - "Next method, ICorProfilerModuleEnum interface [.NET Framework profiling]"
ms.assetid: a3cea59d-7622-4323-897a-0a464c40f77f
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerModuleEnum::Next Method
Gets the specified number of contiguous modules from a sequential collection of modules, starting at the enumerator's current position in the sequence.  
  
## Syntax  
  
```  
HRESULT Next([in]  ULONG      celt,  
             [out, size_is(celt), length_is(*pceltFetched)]  
                    ModuleID ids[],  
             [out] ULONG *   pceltFetched);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of modules to retrieve.  
  
 `ids`  
 [out] An array of `ModuleID` values, each of which represents a retrieved module.  
  
 `pceltFetched`  
 [out] A pointer to the number of elements actually returned in the `ids` array.  
  
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
 [ICorProfilerModuleEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
