---
title: "ICorProfilerObjectEnum::Clone Method"
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
  - "ICorProfilerObjectEnum.Clone"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerObjectEnum::Clone"
helpviewer_keywords: 
  - "Clone method, ICorProfilerObjectEnum interface [.NET Framework profiling]"
  - "ICorProfilerObjectEnum::Clone method [.NET Framework profiling]"
ms.assetid: b0b2facd-5991-4f4c-932d-c4937f45cef9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerObjectEnum::Clone Method
Gets an interface pointer to a copy of this [ICorProfilerObjectEnum](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md) interface.  
  
## Syntax  
  
```  
HRESULT Clone (  
    [out] ICorProfilerObjectEnum   **ppEnum);  
```  
  
#### Parameters  
 `ppEnum`  
 [out] A pointer to the interface pointer that in turn points to the copy of this `ICorProfilerObjectEnum` interface. The copy maintains its own enumeration state separately from this one. However, the copy's initial cursor position will be the same as this enumerator's current cursor position.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerObjectEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md)
