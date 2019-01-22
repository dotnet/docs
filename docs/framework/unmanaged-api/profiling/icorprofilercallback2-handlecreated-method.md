---
title: "ICorProfilerCallback2::HandleCreated Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback2.HandleCreated"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::HandleCreated"
helpviewer_keywords: 
  - "HandleCreated method [.NET Framework profiling]"
  - "ICorProfilerCallback2::HandleCreated method [.NET Framework profiling]"
ms.assetid: 6bbb7786-7c38-490f-9834-91aa2795c355
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback2::HandleCreated Method
Notifies the code profiler that a garbage collection handle has been created.  
  
## Syntax  
  
```  
HRESULT HandleCreated(  
    [in] GCHandleID handleId,  
    [in] ObjectID initialObjectId);  
```  
  
#### Parameters  
 `handleId`  
 [in] The ID of the handle for the garbage collection.  
  
 `initialObjectId`  
 [in] The ID of the object for which the garbage collection handle was created.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)
