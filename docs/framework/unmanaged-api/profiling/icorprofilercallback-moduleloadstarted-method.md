---
description: "Learn more about: ICorProfilerCallback::ModuleLoadStarted Method"
title: "ICorProfilerCallback::ModuleLoadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ModuleLoadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleLoadStarted"
helpviewer_keywords: 
  - "ModuleLoadStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::ModuleLoadStarted method [.NET Framework profiling]"
ms.assetid: 9cd2fe75-408a-400f-a6b1-9979624a2fe2
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ModuleLoadStarted Method

Notifies the profiler that a module is being loaded.  
  
## Syntax  
  
```cpp  
HRESULT ModuleLoadStarted(  
    [in] ModuleID moduleId);  
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module that is being loaded.  
  
## Remarks  

 The value of `moduleId` is not valid for an information request until the [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) method is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
