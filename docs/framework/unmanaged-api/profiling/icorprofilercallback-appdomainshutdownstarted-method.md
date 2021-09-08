---
description: "Learn more about: ICorProfilerCallback::AppDomainShutdownStarted Method"
title: "ICorProfilerCallback::AppDomainShutdownStarted Method"
ms.date: "03/30/2017"
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
---
# ICorProfilerCallback::AppDomainShutdownStarted Method

Notifies the profiler that an application domain is being unloaded from a process.  
  
## Syntax  
  
```cpp  
HRESULT AppDomainShutdownStarted(  
    [in] AppDomainID appDomainId);  
```  
  
## Parameters

`appDomainId`
[in] Identifies the domain in which the application's assemblies are stored.

## Remarks  

 The value of `appDomainId` is not valid for any information request after the `AppDomainShutdownStarted` method returns — this is the profiler's last chance to get information about this application domain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
