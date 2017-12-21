---
title: "ICorProfilerInfo::GetThreadInfo Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetThreadInfo Method
Gets the current Win32 thread identity for the specified thread.  
  
## Syntax  
  
```  
HRESULT GetThreadInfo(  
    [in]  ThreadID threadId,  
    [out] DWORD    *pdwWin32ThreadId);  
```  
  
#### Parameters  
 `threadId`  
 [in] The ID of the thread for which to get the current Win32 ID.  
  
 `pdwWin32ThreadId`  
 [out] A pointer to the specified thread's current Win32 thread ID.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
