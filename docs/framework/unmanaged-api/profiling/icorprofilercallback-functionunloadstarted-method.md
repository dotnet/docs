---
title: "ICorProfilerCallback::FunctionUnloadStarted Method"
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
  - "ICorProfilerCallback.FunctionUnloadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::FunctionUnloadStarted"
helpviewer_keywords: 
  - "FunctionUnloadStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::FunctionUnloadStarted method [.NET Framework profiling]"
ms.assetid: d6a5fa8b-09c6-47a5-b60e-6cf2e355df30
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::FunctionUnloadStarted Method
Notifies the profiler that the runtime has started to unload a function.  
  
## Syntax  
  
```  
HRESULT FunctionUnloadStarted(  
    [in] FunctionID functionId);   
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that is being unloaded.  
  
## Remarks  
 The value of the `functionId` parameter is no longer valid after this method returns to the caller.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
