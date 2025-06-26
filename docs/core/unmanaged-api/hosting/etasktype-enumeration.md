---
description: "Learn more about: ETaskType Enumeration"
title: "ETaskType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ETaskType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ETaskType"
helpviewer_keywords: 
  - "ETaskType enumeration [.NET Framework hosting]"
ms.assetid: aa527b31-89d4-41f2-ad6f-63b76950b7df
topic_type: 
  - "apiref"
---
# ETaskType Enumeration

Contains values that indicate the type of task that is represented by either an [ICLRTask](iclrtask-interface.md) or an [IHostTask](ihosttask-interface.md) interface.  
  
## Syntax  
  
```cpp  
typedef enum ETaskType {  
    TT_DEBUGGERHELPER           = 0x1,  
    TT_GC                       = 0x2,  
    TT_FINALIZER                = 0x4,  
    TT_THREADPOOL_TIMER         = 0x8,  
    TT_THREADPOOL_GATE          = 0x10,  
    TT_THREADPOOL_WORKER        = 0x20,  
    TT_THREADPOOL_IOCOMPLETION  = 0x40,  
    TT_ADUNLOAD                 = 0x80,  
    TT_USER                     = 0x100,  
    TT_THREADPOOL_WAIT          = 0x200,  
    TT_UNKNOWN                  = 0x80000000  
} ETaskType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`TT_ADUNLOAD`|The interface represents an application domain unloading task.|  
|`TT_DEBUGGERHELPER`|The interface represents a debugger helper task.|  
|`TT_FINALIZER`|The interface represents a finalizer task.|  
|`TT_GC`|The interface represents a garbage collection task.|  
|`TT_THREADPOOL_GATE`|The interface represents a gate thread task.|  
|`TT_THREADPOOL_IOCOMPLETION`|The interface represents an I/O thread task or a completion port thread task.|  
|`TT_THREADPOOL_TIMER`|The interface represents a timer thread task.|  
|`TT_THREADPOOL_WAIT`|The interface represents a wait thread task.|  
|`TT_THREADPOOL_WORKER`|The interface represents a worker thread task.|  
|`TT_UNKNOWN`|The task is unknown.|  
|`TT_USER`|The interface represents a user task.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Enumerations](hosting-enumerations.md)
