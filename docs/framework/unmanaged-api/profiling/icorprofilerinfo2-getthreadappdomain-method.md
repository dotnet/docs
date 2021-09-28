---
description: "Learn more about: ICorProfilerInfo2::GetThreadAppDomain Method"
title: "ICorProfilerInfo2::GetThreadAppDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetThreadAppDomain"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetThreadAppDomain"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetThreadAppDomain method [.NET Framework profiling]"
  - "GetThreadAppDomain method [.NET Framework profiling]"
ms.assetid: 4a11b264-8540-4732-aa35-bc2d95b95b8e
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetThreadAppDomain Method

Gets the ID of the application domain in which the specified thread is currently executing code.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadAppDomain(  
    [in]  ThreadID threadId,  
    [out] AppDomainID *pAppDomainId);  
```  
  
## Parameters  

 `threadId`  
 [in] The ID specifying the thread.  
  
 `pAppDomainId`  
 [out] A pointer to the ID of the application domain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
