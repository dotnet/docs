---
title: "ICorProfilerCallback::ModuleLoadStarted Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorProfilerCallback.ModuleLoadStarted"
apilocation: 
  - "mscorwks.dll"
apitype: "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleLoadStarted"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ModuleLoadStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::ModuleLoadStarted method [.NET Framework profiling]"
ms.assetid: 9cd2fe75-408a-400f-a6b1-9979624a2fe2
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICorProfilerCallback::ModuleLoadStarted Method
Notifies the profiler that a module is being loaded.  
  
## Syntax  
  
```  
HRESULT ModuleLoadStarted(  
    [in] ModuleID moduleId);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The ID of the module that is being loaded.  
  
## Remarks  
 The value of `moduleId` is not valid for an information request until the [ICorProfilerCallback::ModuleLoadFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleloadfinished-method.md) method is called.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)