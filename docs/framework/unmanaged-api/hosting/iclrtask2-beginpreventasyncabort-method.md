---
title: "ICLRTask2::BeginPreventAsyncAbort Method"
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
  - "ICLRTask2.BeginPreventAsyncAbort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask2::BeginPreventAsyncAbort"
helpviewer_keywords: 
  - "ICLRTask2::BeginPreventAsyncAbort method [.NET Framework hosting]"
  - "BeginPreventAsyncAbort method [.NET Framework hosting]"
ms.assetid: 75754c2f-38c7-4707-85fe-559db4542729
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRTask2::BeginPreventAsyncAbort Method
Delays new thread abort requests from resulting in thread aborts on the current thread.  
  
## Syntax  
  
```  
HRESULT BeginPreventAsyncAbort();  
```  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|HOST_E_INVALIDOPERATION|The method was called on a thread which is not the current thread.|  
  
## Remarks  
 Calling this method increments the delay-thread-abort counter for the current thread by one.  
  
 Calls to `BeginPreventAsyncAbort` and [ICLRTask2::EndPreventAsyncAbort](../../../../docs/framework/unmanaged-api/hosting/iclrtask2-endpreventasyncabort-method.md) can be nested. As long as the counter is greater than zero, thread aborts for the current thread are delayed. If this call is not paired with a call to the `EndPreventAsyncAbort` method, it is possible to reach a state in which thread aborts cannot be delivered to the current thread.  
  
 The delay is not honored for a thread that aborts itself.  
  
 The functionality that is exposed by this feature is used internally by the virtual machine (VM). Misuse of these methods may cause unspecified behavior in the VM. For example, calling `EndPreventAsyncAbort` without first calling `BeginPreventAsyncAbort` could set the counter to zero when the VM has previously incremented it. Similarly, the internal counter is not checked for overflow. If it exceeds its integral limit because it is incremented by both the host and the VM, the resulting behavior is unspecified.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [EndPreventAsyncAbort Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask2-endpreventasyncabort-method.md)  
 [ICLRTask2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask2-interface.md)  
 [ICLRTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtaskmanager-interface.md)  
 [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md)  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
