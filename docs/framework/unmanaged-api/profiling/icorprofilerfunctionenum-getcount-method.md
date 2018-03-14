---
title: "ICorProfilerFunctionEnum::GetCount Method"
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
  - "ICorProfilerFunctionEnum.GetCount Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionEnum::GetCount"
helpviewer_keywords: 
  - "ICorProfilerFunctionEnum::GetCount method [.NET Framework profiling]"
  - "GetCount method, ICorProfilerFunctionEnum interface [.NET Framework profiling]"
ms.assetid: 62ec65e3-3e9d-400b-ae61-d24b8963995b
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerFunctionEnum::GetCount Method
Gets the number of functions that were loaded by the application or forcibly loaded by the profiler.  
  
## Syntax  
  
```  
HRESULT GetCount([out] ULONG * pcelt);  
```  
  
#### Parameters  
 `celt`  
 [out] The number of functions that were loaded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerFunctionEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctionenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
