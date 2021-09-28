---
description: "Learn more about: ICorProfilerCallback2::HandleDestroyed Method"
title: "ICorProfilerCallback2::HandleDestroyed Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback2.HandleDestroyed"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::HandleDestroyed"
helpviewer_keywords: 
  - "ICorProfilerCallback2::HandleDestroyed method [.NET Framework profiling]"
  - "HandleDestroyed method [.NET Framework profiling]"
ms.assetid: ab4f4bbd-40c7-4667-bfde-60cd73803110
topic_type: 
  - "apiref"
---
# ICorProfilerCallback2::HandleDestroyed Method

Notifies the code profiler that a garbage collection handle has been destroyed.  
  
## Syntax  
  
```cpp  
HRESULT HandleDestroyed(  
    [in] GCHandleID handleId);  
```  
  
## Parameters  

 `handleId`  
 [in] The ID of the handle for the garbage collection.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
