---
title: "COR_PRF_SUSPEND_REASON Enumeration"
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
  - "COR_PRF_SUSPEND_REASON"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_SUSPEND_REASON"
helpviewer_keywords: 
  - "COR_PRF_SUSPEND_REASON enumeration [.NET Framework profiling]"
ms.assetid: 75594833-bed3-47b2-a426-b75c5fe6fbcf
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_SUSPEND_REASON Enumeration
Indicates the reason that the runtime is suspended.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PRF_SUSPEND_OTHER                   = 0x00,  
    COR_PRF_SUSPEND_FOR_GC                  = 0x01,  
    COR_PRF_SUSPEND_FOR_APPDOMAIN_SHUTDOWN  = 0x02,  
    COR_PRF_SUSPEND_FOR_CODE_PITCHING       = 0x03,  
    COR_PRF_SUSPEND_FOR_SHUTDOWN            = 0x04,  
    COR_PRF_SUSPEND_FOR_INPROC_DEBUGGER     = 0x06,  
    COR_PRF_SUSPEND_FOR_GC_PREP             = 0x07,    COR_PRF_SUSPEND_FOR_REJIT               = 8  
} COR_PRF_SUSPEND_REASON;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_FIELD_SUSPEND_OTHER`|The runtime is suspended for an unspecified reason.|  
|`COR_PRF_FIELD_SUSPEND_FOR_GC`|The runtime is suspended to service a garbage collection request.<br /><br /> The garbage collection-related callbacks occur between the [ICorProfilerCallback::RuntimeSuspendFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimesuspendfinished-method.md) and [ICorProfilerCallback::RuntimeResumeStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimeresumestarted-method.md) callbacks.|  
|`COR_PRF_FIELD_SUSPEND_FOR_APPDOMAIN_SHUTDOWN`|The runtime is suspended so that an `AppDomain` can be shut down.<br /><br /> While the runtime is suspended, the runtime will determine which threads are in the `AppDomain` that is being shut down and set them to abort when they resume. There are no `AppDomain`-specific callbacks during this suspension.|  
|`COR_PRF_FIELD_SUSPEND_FOR_CODE_PITCHING`|The runtime is suspended so that code pitching can occur.<br /><br /> Code pitching ensues only when the just-in-time (JIT) compiler is active with code pitching enabled. Code pitching callbacks occur between the `ICorProfilerCallback::RuntimeSuspendFinished` and `ICorProfilerCallback::RuntimeResumeStarted` callbacks. **Note:**  The CLR JIT does not pitch functions in the .NET Framework version 2.0, so this value is not used in 2.0.|  
|`COR_PRF_FIELD_SUSPEND_FOR_SHUTDOWN`|The runtime is suspended so that it can shut down. It must suspend all threads to complete the operation.|  
|`COR_PRF_FIELD_SUSPEND_FOR_INPROC_DEBUGGER`|The runtime is suspended for in-process debugging.|  
|`COR_PRF_FIELD_SUSPEND_FOR_GC_PREP`|The runtime is suspended to prepare for a garbage collection.|  
|`COR_PRF_SUSPEND_FOR_REJIT`|The runtime is suspended for JIT recompilation.|  
  
## Remarks  
 All runtime threads that are in unmanaged code are permitted to continue running until they try to re-enter the runtime, at which point they will also be suspended until the runtime resumes. This also applies to new threads that enter the runtime. All threads within the runtime are either suspended immediately if they are in interruptible code, or asked to suspend when they do reach interruptible code.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
