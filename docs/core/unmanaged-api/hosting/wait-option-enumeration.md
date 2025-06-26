---
description: "Learn more about: WAIT_OPTION Enumeration"
title: "WAIT_OPTION Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "WAIT_OPTION"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "WAIT_OPTION"
helpviewer_keywords: 
  - "WAIT_OPTION enumeration [.NET Framework hosting]"
ms.assetid: 962fc293-8ded-4b3b-90ce-2c21a4f1b244
topic_type: 
  - "apiref"
---
# WAIT_OPTION Enumeration

Contains values that indicate the action a host should take if an operation requested by the common language runtime (CLR) blocks.  
  
## Syntax  
  
```cpp  
typedef enum {  
    WAIT_MSGPUMP       = 0x1,  
    WAIT_ALERTABLE     = 0x2,  
    WAIT_NOTINDEADLOCK = 0x4,  
} WAIT_OPTION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`WAIT_ALERTABLE`|Notifies the host that the task should be awakened if the CLR calls the [IHostTask::Alert](ihosttask-alert-method.md) method.|  
|`WAIT_MSGPUMP`|Notifies the host that it must pump messages on the current OS thread if the thread becomes blocked. The runtime specifies this value only on an <xref:System.Threading.ApartmentState.STA> thread.|  
|`WAIT_NOTINDEADLOCK`|Notifies the host that the specified synchronization request cannot be broken by a host. That is, the host cannot return `HOST_E_DEADLOCK`.|  
  
## Remarks  

 The [IHostTaskManager::Sleep](ihosttaskmanager-sleep-method.md) and [IHostTaskManager::SwitchToTask](ihosttaskmanager-switchtotask-method.md) methods both take a parameter of this type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Enumerations](hosting-enumerations.md)
