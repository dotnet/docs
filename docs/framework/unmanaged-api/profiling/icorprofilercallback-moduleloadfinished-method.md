---
description: "Learn more about: ICorProfilerCallback::ModuleLoadFinished Method"
title: "ICorProfilerCallback::ModuleLoadFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ModuleLoadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleLoadFinished"
helpviewer_keywords: 
  - "ModuleLoadFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::ModuleLoadFinished method [.NET Framework profiling]"
ms.assetid: 050649e5-ffc0-4458-a0a4-d9ee128a219e
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ModuleLoadFinished Method

Notifies the profiler that a module has finished loading.  
  
## Syntax  
  
```cpp  
HRESULT ModuleLoadFinished(  
    [in] ModuleID moduleId,  
    [in] HRESULT  hrStatus);  
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module that has finished loading.  
  
 `hrStatus`  
 [in] An HRESULT that indicates whether the module was loaded successfully.  
  
## Remarks  

 The value of `moduleId` is not valid for an information request until the `ModuleLoadFinished` method is called.  
  
 Some parts of loading the module might continue after the `ModuleLoadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of loading the module has succeeded.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ModuleLoadStarted Method](icorprofilercallback-moduleloadstarted-method.md)
