---
title: "ICorProfilerCallback2::ThreadNameChanged Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback2.ThreadNameChanged"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::ThreadNameChanged"
helpviewer_keywords: 
  - "ThreadNameChanged method [.NET Framework profiling]"
  - "ICorProfilerCallback2::ThreadNameChanged method [.NET Framework profiling]"
ms.assetid: c8bbd76d-a9ff-44f2-87a6-be052819da36
topic_type: 
  - "apiref"
---
# ICorProfilerCallback2::ThreadNameChanged Method
Notifies the code profiler that the name of a thread has changed.  
  
## Syntax  
  
```cpp  
HRESULT ThreadNameChanged(  
    [in] ThreadID threadId,  
    [in] ULONG cchName,  
    [in] WCHAR name[]);  
```  
  
## Parameters  
 `threadId`  
 [in] The ID of the thread.  
  
 `cchName`  
 [in] The length of the new name of the thread.  
  
 `name`  
 [in] The new name of the thread. The name is not null-terminated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)
