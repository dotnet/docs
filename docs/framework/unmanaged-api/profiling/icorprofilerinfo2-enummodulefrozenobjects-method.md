---
title: "ICorProfilerInfo2::EnumModuleFrozenObjects Method"
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
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::EnumModuleFrozenObjects Method
Gets an enumerator that allows iteration over the frozen objects in the specified module.This method is obsolete.  
  
## Syntax  
  
```  
HRESULT EnumModuleFrozenObjects(  
    [in] ModuleID moduleID,  
    [out] ICorProfilerObjectEnum** ppEnum);  
```  
  
#### Parameters  
 `moduleID`  
 [in] The ID of the module that contains the frozen objects to be enumerated.  
  
 `ppEnum`  
 [out] A pointer to the address of an [ICorProfilerObjectEnum](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md) interface, which enumerates the frozen objects.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
