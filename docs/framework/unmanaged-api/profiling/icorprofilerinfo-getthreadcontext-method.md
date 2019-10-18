---
title: "ICorProfilerInfo::GetThreadContext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetThreadContext"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetThreadContext"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetThreadContext method [.NET Framework profiling]"
  - "GetThreadContext method, ICorProfilerInfo interface [.NET Framework profiling]"
ms.assetid: 79446216-4b8b-484c-8fe3-e87dbf9df2fd
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerInfo::GetThreadContext Method
Gets the context identity currently associated with the specified thread.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadContext(  
    [in]  ThreadID  threadId,  
    [out] ContextID *pContextId);  
```  
  
## Parameters  
 `threadId`  
 [in] The ID of the thread.  
  
 `pContextId`  
 [out] A pointer to the context ID currently associated with the specified thread. If the thread has no context currently associated with it, this function will return CORPROF_E_DATAINCOMPLETE.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
