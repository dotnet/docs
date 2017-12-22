---
title: "ICorProfilerFunctionEnum::Skip Method"
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
  - "ICorProfilerFunctionEnum.Skip Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionEnum::Skip"
helpviewer_keywords: 
  - "Skip method, ICorProfilerFunctionEnum interface [.NET Framework profiling]"
  - "ICorProfilerFunctionEnum::Skip method [.NET Framework profiling]"
ms.assetid: 051465b9-e479-494a-804b-c880323b4cbe
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerFunctionEnum::Skip Method
Advances the enumerator's cursor from its current position so that the specified number of elements are skipped.  
  
## Syntax  
  
```  
HRESULT Skip([in] ULONG celt);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of elements to be skipped.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`celt` elements were skipped.|  
|S_FALSE|Fewer than `celt` elements were skipped, which indicates that there are no more elements.|  
  
## Remarks  
 The new position of this enumerator's cursor is (current position) + `celt`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerFunctionEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctionenum-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
