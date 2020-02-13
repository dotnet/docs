---
title: "ICorProfilerModuleEnum::Clone Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerModuleEnum.Clone Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum::Clone"
helpviewer_keywords: 
  - "Clone method, ICorProfilerModuleEnum interface [.NET Framework profiling]"
  - "ICorProfilerModuleEnum::Clone method [.NET Framework profiling]"
ms.assetid: 7dec7e36-8d88-416d-b437-abf98b76c1df
topic_type: 
  - "apiref"
---
# ICorProfilerModuleEnum::Clone Method
Gets an interface pointer to a copy of this [ICorProfilerModuleEnum](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-interface.md) interface.  
  
## Syntax  
  
```cpp  
HRESULT Clone([out] ICorProfilerObjectEnum **ppEnum);  
```  
  
## Parameters  
 `ppEnum`  
 [out] A pointer to the interface pointer that in turn points to the copy of this [ICorProfilerModuleEnum](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-interface.md) interface. The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the copy's initial cursor position is the same as this enumerator's current cursor position.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerModuleEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-interface.md)
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
