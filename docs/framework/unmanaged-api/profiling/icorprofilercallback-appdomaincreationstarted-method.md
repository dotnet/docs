---
description: "Learn more about: ICorProfilerCallback::AppDomainCreationStarted Method"
title: "ICorProfilerCallback::AppDomainCreationStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AppDomainCreationStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AppDomainCreationStarted"
helpviewer_keywords: 
  - "AppDomainCreationStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::AppDomainCreationStarted method [.NET Framework profiling]"
ms.assetid: b2a8240b-07fe-4859-bb2b-7d3adbfa0a9f
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::AppDomainCreationStarted Method

Notifies the profiler that an application domain is being created.  
  
## Syntax  
  
```cpp  
HRESULT AppDomainCreationStarted(  
    [in] AppDomainID appDomainId);  
```  
  
## Parameters

`appDomainId`
[in] Identifies the domain which is being created.
  
## Remarks  

 The ID is not valid for any information request until the [ICorProfilerCallback::AppDomainCreationFinished](icorprofilercallback-appdomaincreationfinished-method.md) method is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
