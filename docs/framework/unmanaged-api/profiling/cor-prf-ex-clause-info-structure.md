---
description: "Learn more about: COR_PRF_EX_CLAUSE_INFO Structure"
title: "COR_PRF_EX_CLAUSE_INFO Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_EX_CLAUSE_INFO"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_EX_CLAUSE_INFO"
helpviewer_keywords: 
  - "COR_PRF_EX_CLAUSE_INFO structure [.NET Framework profiling]"
ms.assetid: 7d0d6fb7-bc9d-40f0-8163-c0d162eaba7d
topic_type: 
  - "apiref"
---
# COR_PRF_EX_CLAUSE_INFO Structure

Stores information about a specific exception clause instance and its associated frame.  
  
## Syntax  
  
```cpp  
typedef struct COR_PRF_EX_CLAUSE_INFO {  
    COR_PRF_CLAUSE_TYPE clauseType;  
    UINT_PTR programCounter;  
    UINT_PTR framePointer;  
    UINT_PTR shadowStackPointer;  
} COR_PRF_EX_CLAUSE_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`clauseType`|A value of the [COR_PRF_CLAUSE_TYPE](cor-prf-clause-type-enumeration.md) enumeration that specifies the type of exception clause the code just entered or left.|  
|`programCounter`|The native entry point of the clause handler — for example, the contents of the X86 EIP register.|  
|`framePointer`|The pointer to the logical frame for the clause handler — for example, the contents of the X86 EBP register.|  
|`shadowStackPointer`|The pointer to the shadow stack. This value is the contents of the BSP register and applies only to IA64.|  
  
## Remarks  

 When an exception notification is received, [ICorProfilerInfo2::GetNotifiedExceptionClauseInfo](icorprofilerinfo2-getnotifiedexceptionclauseinfo-method.md) can be used to get the native address and frame information for the exception clause (`catch`/`finally`/filter) that is about to be run or has just been run.  
  
 Execution of an exception clause involves these callbacks from the common language runtime (CLR):  
  
- [ICorProfilerCallback::ExceptionCatcherEnter](icorprofilercallback-exceptioncatcherenter-method.md)  
  
- [ICorProfilerCallback::ExceptionUnwindFinallyEnter](icorprofilercallback-exceptionunwindfinallyenter-method.md)  
  
- [ICorProfilerCallback::ExceptionSearchFilterEnter](icorprofilercallback-exceptionsearchfilterenter-method.md)  
  
- [ICorProfilerCallback::ExceptionCatcherLeave](icorprofilercallback-exceptioncatcherleave-method.md)  
  
- [ICorProfilerCallback::ExceptionUnwindFinallyLeave](icorprofilercallback-exceptionunwindfinallyleave-method.md)  
  
- [ICorProfilerCallback::ExceptionSearchFilterLeave](icorprofilercallback-exceptionsearchfilterleave-method.md)  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Structures](profiling-structures.md)
