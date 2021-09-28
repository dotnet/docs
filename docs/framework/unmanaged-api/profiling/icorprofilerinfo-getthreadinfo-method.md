---
description: "Learn more about: ICorProfilerInfo::GetThreadInfo Method"
title: "ICorProfilerInfo::GetThreadInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetThreadInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetThreadInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetThreadInfo method [.NET Framework profiling]"
  - "GetThreadInfo method [.NET Framework profiling]"
ms.assetid: fc994fef-65c9-432a-84cb-66c8141147e7
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetThreadInfo Method

Gets the current Win32 thread identity for the specified thread.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadInfo(  
    [in]  ThreadID threadId,  
    [out] DWORD    *pdwWin32ThreadId);  
```  
  
## Parameters  

 `threadId`  
 [in] The ID of the thread for which to get the current Win32 ID.  
  
 `pdwWin32ThreadId`  
 [out] A pointer to the specified thread's current Win32 thread ID.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
