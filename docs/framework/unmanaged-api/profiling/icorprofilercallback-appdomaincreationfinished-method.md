---
title: "ICorProfilerCallback::AppDomainCreationFinished Method"
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
  - "ICorProfilerCallback.AppDomainCreationFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AppDomainCreationFinished"
helpviewer_keywords: 
  - "AppDomainCreationFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::AppDomainCreationFinished method [.NET Framework profiling]"
ms.assetid: dbab7d90-d515-4dc9-8195-294d5d04bab6
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::AppDomainCreationFinished Method
Notifies the profiler that an application domain has been created.  
  
## Syntax  
  
```  
HRESULT AppDomainCreationFinished(  
    [in] AppDomainID appDomainId,  
    [in] HRESULT     hrStatus);   
```  
  
#### Parameters  
 `appDomainId`  
 [in] Identifies the domain which has been created.  
  
 `hrStatus`  
 [in] An HRESULT that indicates whether creation of the application domain completed successfully.  
  
## Remarks  
 The application ID is not valid for any information request until the `AppDomainCreationFinished` method is called.  
  
 Some parts of loading the application domain might continue after the `AppDomainCreationFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of creating the application domain has succeeded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
