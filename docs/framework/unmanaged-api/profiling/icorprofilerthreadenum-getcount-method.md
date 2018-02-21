---
title: "ICorProfilerThreadEnum::GetCount Method"
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
  - "ICorProfilerThreadEnum.GetCount"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerThreadEnum::GetCount"
helpviewer_keywords: 
  - "ICorProfilerThreadEnum::GetCount method [.NET Framework profiling]"
  - "GetCount method, ICorProfilerThreadEnum interface [.NET Framework profiling]"
ms.assetid: d6dbdc4a-6115-455d-a3f3-704a81d3646b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerThreadEnum::GetCount Method
Gets the number of threads that are used by the application.  
  
## Syntax  
  
```  
HRESULT GetCount (    [out] ULONG * pcelt  
);  
```  
  
#### Parameters  
 `celt`  
 [out] The number of threads used by the application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerThreadEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
