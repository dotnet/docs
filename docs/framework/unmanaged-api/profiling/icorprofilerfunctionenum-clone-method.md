---
description: "Learn more about: ICorProfilerFunctionEnum::Clone Method"
title: "ICorProfilerFunctionEnum::Clone Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerFunctionEnum.Clone Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionEnum::Clone"
helpviewer_keywords: 
  - "ICorProfilerFunctionEnum::Clone method [.NET Framework profiling]"
  - "Clone method, ICorProfilerFunctionEnum interface [.NET Framework profiling]"
ms.assetid: 0c3d4835-e111-4e82-af6d-53f140b8f2c9
topic_type: 
  - "apiref"
---
# ICorProfilerFunctionEnum::Clone Method

Gets an interface pointer to a copy of this [ICorProfilerFunctionEnum](icorprofilerfunctionenum-interface.md) interface.  
  
## Syntax  
  
```cpp  
HRESULT Clone([out] ICorProfilerFunctionEnum **ppEnum);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the interface pointer, which, in turn, points to the copy of this [ICorProfilerFunctionEnum](icorprofilerfunctionenum-interface.md) interface. The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the copy's initial cursor position is the same as this enumerator's current cursor position.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerFunctionEnum Interface](icorprofilerfunctionenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
