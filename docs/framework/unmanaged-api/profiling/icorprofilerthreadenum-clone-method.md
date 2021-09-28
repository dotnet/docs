---
description: "Learn more about: ICorProfilerThreadEnum::Clone Method"
title: "ICorProfilerThreadEnum::Clone Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerThreadEnum.Clone"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerThreadEnum::Clone"
helpviewer_keywords: 
  - "Clone method, ICorProfilerThreadEnum interface [.NET Framework profiling]"
  - "ICorProfilerThreadEnum::Clone method [.NET Framework profiling]"
ms.assetid: 5a278bc9-88e2-4c69-b035-9d550dd77081
topic_type: 
  - "apiref"
---
# ICorProfilerThreadEnum::Clone Method

Gets an interface pointer to a copy of this [ICorProfilerThreadEnum](icorprofilerthreadenum-interface.md) interface.  
  
## Syntax  
  
```cpp  
HRESULT Clone (    [out] ICorProfilerThreadEnum **ppEnum  
);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the interface pointer, which, in turn, points to the copy of this [ICorProfilerThreadEnum](icorprofilerthreadenum-interface.md) interface. The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the initial cursor position of the copy is the same as this current cursor position of the enumerator.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerThreadEnum](icorprofilerthreadenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
