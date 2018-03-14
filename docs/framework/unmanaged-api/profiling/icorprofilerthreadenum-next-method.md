---
title: "ICorProfilerThreadEnum::Next Method"
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
  - "ICorProfilerThreadEnum.Next"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerThreadEnum::Next"
helpviewer_keywords: 
  - "ICorProfilerThreadEnum::Next method [.NET Framework profiling]"
  - "Next method, ICorProfilerThreadEnum interface [.NET Framework profiling]"
ms.assetid: f3535279-3c63-41a2-ab0e-a129dc5a01e8
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerThreadEnum::Next Method
Gets the specified number of contiguous threads from a sequential collection of threads, starting at the enumerator's current position in the sequence.  
  
## Syntax  
  
```  
HRESULT Next (    [in]  ULONG      celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
                    ThreadID ids[],  
    [out] ULONG *   pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of threads to retrieve.  
  
 `ids`  
 [out] An array of `ThreadID` values, each of which represents a retrieved thread.  
  
 `pceltFetched`  
 [out] A pointer to the number of threads actually returned in the `ids` array.  
  
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
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerThreadEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
