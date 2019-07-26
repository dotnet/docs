---
title: "ICorProfilerCallback::ClassUnloadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ClassUnloadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ClassUnloadStarted"
helpviewer_keywords: 
  - "ClassUnloadStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::ClassUnloadStarted method [.NET Framework profiling]"
ms.assetid: bc93bead-f3a9-415c-b919-ddd3ca80facc
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::ClassUnloadStarted Method
Notifies the profiler that a class is being unloaded.  
  
## Syntax  
  
```cpp  
HRESULT ClassUnloadStarted(  
    [in] ClassID classId);  
```  
  
## Parameters  
 `classId`  
 [in] Identifies the class that is being unloaded.  
  
## Remarks  
 The value of `classId` is not valid for an information request after the `ClassUnloadStarted` method returns — this is the profiler's last chance to obtain information about this class.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ClassUnloadFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-classunloadfinished-method.md)
