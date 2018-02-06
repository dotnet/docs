---
title: "EMemoryCriticalLevel Enumeration"
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
  - "EMemoryCriticalLevel"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EMemoryCriticalLevel"
helpviewer_keywords: 
  - "EMemoryCriticalLevel enumeration [.NET Framework hosting]"
ms.assetid: 2ca8a7a2-7b54-4ba3-8e73-277c7df485f3
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EMemoryCriticalLevel Enumeration
Contains values that indicate the impact of a failure when a specific memory allocation has been requested but cannot be satisfied.  
  
## Syntax  
  
```  
typedef enum {  
    eTaskCritical      = 0,  
    eAppDomainCritical = 1,  
    eProcessCritical   = 2  
} EMemoryCriticalLevel;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eAppDomainCritical`|Indicates that the allocation is critical for executing managed code in the domain that has requested the allocation. If memory cannot be allocated, the CLR cannot guarantee that the domain is still usable. The host decides what action to take when the allocation cannot be satisfied. It can instruct the CLR to abort the `AppDomain` automatically, or allow it to keep running by calling methods on [ICLRPolicyManager](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md).|  
|`eProcessCritical`|Indicates that the allocation is critical to the execution of managed code in the process. This value is used during startup and when running finalizers. If memory cannot be allocated, the CLR cannot operate in the process. If the allocation fails, the CLR is effectively disabled. All subsequent calls into the CLR fail with HOST_E_CLRNOTAVAILABLE.|  
|`eTaskCritical`|Indicates that the allocation is critical to running the task that has requested the allocation. If memory cannot be allocated, the CLR cannot guarantee that the task can be executed. In the event of failure, the CLR raises a <xref:System.Threading.ThreadAbortException> on the physical operation system thread.|  
  
## Remarks  
 The memory allocation methods defined in the [IHostMemoryManager](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md) and [IHostMAlloc](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-interface.md) interfaces take a parameter of this type. Depending upon the severity of a failure, a host can decide whether to fail the allocation request immediately or to wait until it can be satisfied.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRMemoryNotificationCallback Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmemorynotificationcallback-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
