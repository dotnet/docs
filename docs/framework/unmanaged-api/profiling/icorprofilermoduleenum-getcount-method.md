---
description: "Learn more about: ICorProfilerModuleEnum::GetCount Method"
title: "ICorProfilerModuleEnum::GetCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerModuleEnum.GetCount Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum::GetCount"
helpviewer_keywords: 
  - "ICorProfilerModuleEnum::GetCount method [.NET Framework profiling]"
  - "GetCount method, ICorProfilerModuleEnum interface [.NET Framework profiling]"
ms.assetid: f0a4a5e0-4689-474b-b0f4-37ca0639c918
topic_type: 
  - "apiref"
---
# ICorProfilerModuleEnum::GetCount Method

Gets the number of managed modules that were loaded into the application.  
  
## Syntax  
  
```cpp  
HRESULT GetCount([out] ULONG * pcelt);  
```  
  
## Parameters  

 `celt`  
 [out] The number of runtime modules in the collection.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerModuleEnum Interface](icorprofilermoduleenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
