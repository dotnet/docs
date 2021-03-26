---
description: "Learn more about: ICorProfilerInfo4::EnumThreads Method"
title: "ICorProfilerInfo4::EnumThreads Method"
ms.date: "03/30/2017"
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
---
# ICorProfilerInfo4::EnumThreads Method

Returns an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.  
  
## Syntax  
  
```cpp  
HRESULT EnumThreads([out]  
            ICorProfilerThreadEnum** ppEnum);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to an [ICorProfilerThreadEnum](icorprofilerthreadenum-interface.md) interface.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerThreadEnum Interface](icorprofilerthreadenum-interface.md)
- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
