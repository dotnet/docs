---
title: "ICorProfilerInfo::GetHandleFromThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetHandleFromThread"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetHandleFromThread"
helpviewer_keywords: 
  - "GetHandleFromThread method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetHandleFromThread method [.NET Framework profiling]"
ms.assetid: 36cdc9f5-7579-4cd2-aa36-fc05c741584c
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerInfo::GetHandleFromThread Method
Maps the ID of a thread to a Win32 thread handle.  
  
## Syntax  
  
```  
HRESULT GetHandleFromThread(  
    [in]  ThreadID threadId,  
    [out] HANDLE  *phThread);  
```  
  
#### Parameters  
 `threadId`  
 [in] The thread ID to be mapped.  
  
 `phThread`  
 [out] A pointer to a Win32 thread handle.  
  
## Remarks  
 The profiler must call the Win32 `DuplicateHandle` function on the handle before using it.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
