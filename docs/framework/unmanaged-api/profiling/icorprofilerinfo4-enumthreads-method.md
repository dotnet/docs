---
title: "ICorProfilerInfo4::EnumThreads Method"
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
  - "ICorProfilerInfo4.EnumThreads"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::EnumThreads"
helpviewer_keywords: 
  - "ICorProfilerInfo4::EnumThreads method [.NET Framework profiling]"
  - "EnumThreads method, ICorProfilerInfo4 interface [.NET Framework profiling]"
ms.assetid: bca7a5b4-c207-4894-918c-0733926296dd
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo4::EnumThreads Method
Returns an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.  
  
## Syntax  
  
```  
HRESULT EnumThreads([out]  
            ICorProfilerThreadEnum** ppEnum);  
```  
  
#### Parameters  
 `ppEnum`  
 [out] A pointer to an [ICorProfilerThreadEnum](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-interface.md) interface.  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerThreadEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-interface.md)  
 [ICorProfilerInfo4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
