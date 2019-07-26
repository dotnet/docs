---
title: "COR_PRF_TRANSITION_REASON Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_TRANSITION_REASON"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_TRANSITION_REASON"
helpviewer_keywords: 
  - "COR_PRF_TRANSITION_REASON enumeration [.NET Framework profiling]"
ms.assetid: da941118-01b7-4197-ae5b-9f2f8adcd623
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# COR_PRF_TRANSITION_REASON Enumeration
Indicates the reason for a transition from managed to unmanaged code, or vice versa.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_TRANSITION_CALL,  
    COR_PRF_TRANSITION_RETURN  
} COR_PRF_TRANSITION_REASON;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_TRANSITION_CALL`|The transition is due to a call into a function.|  
|`COR_PRF_TRANSITION_RETURN`|The transition is due to a return from a function.|  
  
## Remarks  
 When a transition occurs, the profiler receives an [ICorProfilerCallback::ManagedToUnmanagedTransition](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-managedtounmanagedtransition-method.md) or [ICorProfilerCallback::UnmanagedToManagedTransition](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-unmanagedtomanagedtransition-method.md) callback, either of which provides a value of the `COR_PRF_TRANSITION_REASON` enumeration to indicate the reason for the transition.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
