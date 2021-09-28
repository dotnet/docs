---
description: "Learn more about: ICorProfilerCallback::ModuleUnloadStarted Method"
title: "ICorProfilerCallback::ModuleUnloadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ModuleUnloadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleUnloadStarted"
helpviewer_keywords: 
  - "ModuleUnloadStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::ModuleUnloadStarted method [.NET Framework profiling]"
ms.assetid: 2debcaab-6005-4245-afdb-4268bb7e74bd
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ModuleUnloadStarted Method

Notifies the profiler that a module is being unloaded.  
  
## Syntax  
  
```cpp  
HRESULT ModuleUnloadStarted(  
    [in] ModuleID moduleId);
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module that is being unloaded.  
  
## Remarks  

 The value of `moduleId` is not valid for an information request after the `ModuleUnloadStarted` method returns — this is the profiler's last chance to get information about this module.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ModuleUnloadFinished Method](icorprofilercallback-moduleunloadfinished-method.md)
