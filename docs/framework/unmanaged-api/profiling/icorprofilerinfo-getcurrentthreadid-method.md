---
title: "ICorProfilerInfo::GetCurrentThreadID Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetCurrentThreadID"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetCurrentThreadID"
helpviewer_keywords: 
  - "GetCurrentThreadID method, ICorProfilerInfo interface [.NET Framework profiling]"
  - "ICorProfilerInfo::GetCurrentThreadID method [.NET Framework profiling]"
ms.assetid: 39bbdb30-6a7a-4202-8da3-67ae9a0ab3a8
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerInfo::GetCurrentThreadID Method
Gets the ID of the current thread, if it is a managed thread.  
  
## Syntax  
  
```  
HRESULT GetCurrentThreadID(  
    [out] ThreadID *pThreadId);  
```  
  
#### Parameters  
 `pThreadId`  
 [out] A pointer to the returned ID of the managed thread.  
  
## Remarks  
 If the current thread is an internal runtime thread or other unmanaged thread, `GetCurrentThreadID` returns CORPROF_E_NOT_MANAGED_THREAD as the HRESULT, and the returned value of the `pThreadId` parameter will be null.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
