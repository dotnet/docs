---
description: "Learn more about: ICorProfilerThreadEnum::GetCount Method"
title: "ICorProfilerThreadEnum::GetCount Method"
ms.date: "03/30/2017"
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
---
# ICorProfilerThreadEnum::GetCount Method

Gets the number of threads that are used by the application.  
  
## Syntax  
  
```cpp  
HRESULT GetCount (    [out] ULONG * pcelt  
);  
```  
  
## Parameters  

 `celt`  
 [out] The number of threads used by the application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerThreadEnum Interface](icorprofilerthreadenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
