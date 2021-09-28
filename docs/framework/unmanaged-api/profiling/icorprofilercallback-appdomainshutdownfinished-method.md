---
description: "Learn more about: ICorProfilerCallback::AppDomainShutdownFinished Method"
title: "ICorProfilerCallback::AppDomainShutdownFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AppDomainShutdownFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AppDomainShutdownFinished"
helpviewer_keywords: 
  - "AppDomainShutdownFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::AppDomainShutdownFinished method [.NET Framework profiling]"
ms.assetid: 52794819-0a59-4bb1-a265-0f158cd5cd65
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::AppDomainShutdownFinished Method

Notifies the profiler that an application domain has been unloaded from a process.  
  
## Syntax  
  
```cpp  
HRESULT AppDomainShutdownFinished(  
    [in] AppDomainID appDomainId,  
    [in] HRESULT     hrStatus);  
```  
  
## Parameters

`appDomainId`
[in] Identifies the domain in which the application's assemblies are stored.

`hrStatus`
[in] An HRESULT that indicates whether the application domain was unloaded successfully.

## Remarks  

 The value of `appDomainId` is not valid for an information request after the [ICorProfilerCallback::AppDomainShutdownStarted](icorprofilercallback-appdomainshutdownstarted-method.md) method returns.  
  
 Some parts of unloading the application domain might continue after the `AppDomainCreationFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of unloading the application domain has succeeded.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
