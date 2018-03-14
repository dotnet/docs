---
title: "ICorProfilerObjectEnum::Skip Method"
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
  - "ICorProfilerObjectEnum.Skip"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerObjectEnum::Skip"
helpviewer_keywords: 
  - "ICorProfilerObjectEnum::Skip method [.NET Framework profiling]"
  - "Skip method, ICorProfilerObjectEnum interface [.NET Framework profiling]"
ms.assetid: f8e498f8-f93a-4b82-bd22-55bdbf5e8d45
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerObjectEnum::Skip Method
Advances the cursor of this enumerator from its current position so that the specified number of elements are skipped.  
  
## Syntax  
  
```  
HRESULT Skip (  
    [in] ULONG   celt  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of elements to be skipped.  
  
## Remarks  
 The new position of this enumerator's cursor is: (current position) + `celt` .  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerObjectEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md)
