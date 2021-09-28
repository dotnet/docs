---
description: "Learn more about: ICorProfilerInfo3::EnumModules Method"
title: "ICorProfilerInfo3::EnumModules Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.EnumModules Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::EnumModules"
helpviewer_keywords: 
  - "ICorProfilerInfo3::EnumModules method [.NET Framework profiling]"
  - "EnumModules method [.NET Framework profiling]"
ms.assetid: 1bf00b42-69da-4019-91b3-bf88026e83fb
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::EnumModules Method

Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.  
  
## Syntax  
  
```cpp  
HRESULT EnumModules([out] ICorProfilerModuleEnum** ppEnum);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to an [ICorProfilerModuleEnum](icorprofilermoduleenum-interface.md) interface.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerFunctionEnum Interface](icorprofilerfunctionenum-interface.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
