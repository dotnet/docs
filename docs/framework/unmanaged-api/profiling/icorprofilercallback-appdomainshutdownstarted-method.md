---
title: "ICorProfilerCallback::AppDomainShutdownStarted Method"
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
  - "ICorProfilerCallback.AppDomainShutdownStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AppDomainShutdownStarted"
helpviewer_keywords: 
  - "AppDomainShutdownStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::AppDomainShutdownStarted method [.NET Framework profiling]"
ms.assetid: d23a3408-b525-4aec-a186-2ac7ca65d7a4
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::AppDomainShutdownStarted Method
Notifies the profiler that an application domain is being unloaded from a process.  
  
## Syntax  
  
```  
HRESULT AppDomainShutdownStarted(  
    [in] AppDomainID appDomainId);  
```  
  
#### Parameters  
 `appDomainId`  
 [in] Identifies the domain in which the application's assemblies are stored.  
  
## Remarks  
 The value of `appDomainId` is not valid for any information request after the `AppDomainShutdownStarted` method returns — this is the profiler's last chance to get information about this application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
