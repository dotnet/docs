---
description: "Learn more about: ICorProfilerInfo2::EnumModuleFrozenObjects Method"
title: "ICorProfilerInfo2::EnumModuleFrozenObjects Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.EnumModuleFrozenObjects"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::EnumModuleFrozenObjects"
helpviewer_keywords: 
  - "EnumModuleFrozenObjects method [.NET Framework profiling]"
  - "ICorProfilerInfo2::EnumModuleFrozenObjects method [.NET Framework profiling]"
ms.assetid: 920b6483-7064-4d64-8613-fcc38ccf9b1e
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::EnumModuleFrozenObjects Method

Gets an enumerator that allows iteration over the frozen objects in the specified module.This method is obsolete.  
  
## Syntax  
  
```cpp  
HRESULT EnumModuleFrozenObjects(  
    [in] ModuleID moduleID,  
    [out] ICorProfilerObjectEnum** ppEnum);  
```  
  
## Parameters  

 `moduleID`  
 [in] The ID of the module that contains the frozen objects to be enumerated.  
  
 `ppEnum`  
 [out] A pointer to the address of an [ICorProfilerObjectEnum](icorprofilerobjectenum-interface.md) interface, which enumerates the frozen objects.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
