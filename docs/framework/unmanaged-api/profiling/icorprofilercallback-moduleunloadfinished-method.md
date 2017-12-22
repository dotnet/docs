---
title: "ICorProfilerCallback::ModuleUnloadFinished Method"
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
  - "ICorProfilerCallback.ModuleUnloadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleUnloadFinished"
helpviewer_keywords: 
  - "ModuleUnloadFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::ModuleUnloadFinished method [.NET Framework profiling]"
ms.assetid: 185e3327-9f9c-44bc-8a5c-febea9a6bb5b
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ModuleUnloadFinished Method
Notifies the profiler that a module has finished unloading.  
  
## Syntax  
  
```  
HRESULT ModuleUnloadFinished(  
    [in] ModuleID moduleId,  
    [in] HRESULT  hrStatus);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The ID of the module that was unloaded.  
  
 `hrStatus`  
 [in] An HRESULT that indicates whether the module was unloaded successfully.  
  
## Remarks  
 The value of `moduleId` is not valid for an information request after the [ICorProfilerCallback::ModuleUnloadStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleunloadstarted-method.md) method returns.  
  
 Some parts of unloading the class might continue after the `ModuleUnloadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of unloading the module has succeeded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
