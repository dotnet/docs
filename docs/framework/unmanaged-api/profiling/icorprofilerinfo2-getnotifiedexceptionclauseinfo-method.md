---
description: "Learn more about: ICorProfilerInfo2::GetNotifiedExceptionClauseInfo Method"
title: "ICorProfilerInfo2::GetNotifiedExceptionClauseInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetNotifiedExceptionClauseInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetNotifiedExceptionClauseInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetNotifiedExceptionCaluseInfo method [.NET Framework profiling]"
  - "GetNotifiedExceptionCaluseInfo method [.NET Framework profiling]"
ms.assetid: f9594a7e-cb0c-4c48-accb-29f762aa0c21
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetNotifiedExceptionClauseInfo Method

Gets the native address and frame information for the exception clause (`catch`/`finally`/`filter`) that is about to be run or has just been run.  
  
## Syntax  
  
```cpp  
HRESULT GetNotifiedExceptionClauseInfo(  
    [out] COR_PRF_EX_CLAUSE_INFO *pinfo);  
```  
  
## Parameters  

 `pinfo`  
 [out] A pointer to a [COR_PRF_EX_CLAUSE_INFO](cor-prf-ex-clause-info-structure.md) structure that describes the current exception clause instance and its associated frame.  
  
## Remarks  

 When an exception notification is received, `GetNotifiedExceptionClauseInfo` can be used to get the native address and frame information for the exception clause (`catch`/`finally`/`filter`) that is about to be run ([ICorProfilerCallback::ExceptionCatcherEnter](icorprofilercallback-exceptioncatcherenter-method.md), [ICorProfilerCallback::ExceptionUnwindFinallyEnter](icorprofilercallback-exceptionunwindfinallyenter-method.md), or [ICorProfilerCallback::ExceptionSearchFilterEnter](icorprofilercallback-exceptionsearchfilterenter-method.md) callback is received by the profiler) or has just been run ([ICorProfilerCallback::ExceptionCatcherLeave](icorprofilercallback-exceptioncatcherleave-method.md), [ICorProfilerCallback::ExceptionUnwindFinallyLeave](icorprofilercallback-exceptionunwindfinallyleave-method.md), or [ICorProfilerCallback::ExceptionSearchFilterLeave](icorprofilercallback-exceptionsearchfilterleave-method.md) callback is received by the profiler).  
  
 This call can be made at any time after one of the Enter callbacks above until either the matching Leave callback is received or a nested exception is thrown in the current clause, in which case there is no Leave notification for that clause. Note that it is not possible for a thrown exception to escape a `filter` exception clause, so there is always a Leave notification in that case.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
