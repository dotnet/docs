---
description: "Learn more about: IHostSecurityManager Interface"
title: "IHostSecurityManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostSecurityManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager"
helpviewer_keywords: 
  - "IHostSecurityManager interface [.NET Framework hosting]"
ms.assetid: c3be2cbd-2d93-438b-9888-9a0251b63c03
topic_type: 
  - "apiref"
---
# IHostSecurityManager Interface

Provides methods that allow access to and control over the security context of the currently executing thread.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetSecurityContext Method](ihostsecuritymanager-getsecuritycontext-method.md)|Gets the requested [IHostSecurityContext](ihostsecuritycontext-interface.md) from the host.|  
|[ImpersonateLoggedOnUser Method](ihostsecuritymanager-impersonateloggedonuser-method.md)|Requests that code be executed using the credentials of the current user identity.|  
|[OpenThreadToken Method](ihostsecuritymanager-openthreadtoken-method.md)|Opens the discretionary access token associated with the current thread.|  
|[RevertToSelf Method](ihostsecuritymanager-reverttoself-method.md)|Terminates impersonation of the current user identity and returns the original thread token.|  
|[SetSecurityContext Method](ihostsecuritymanager-setsecuritycontext-method.md)|Sets the security context for the currently executing thread.|  
|[SetThreadToken Method](ihostsecuritymanager-setthreadtoken-method.md)|Sets a handle for the currently executing thread.|  
  
## Remarks  

 A host can control all code access to thread tokens by both the common language runtime (CLR) and user code. It can also ensure that complete security context information is passed across asynchronous operations or code points with restricted code access. `IHostSecurityContext` encapsulates this security context information, which is opaque to the CLR.  
  
 The CLR handles managed thread context internally. It queries the process-specific `IHostSecurityManager` in the following situations:  
  
- On the finalizer thread, during finalizer execution.  
  
- During class and module constructor execution.  
  
- At asynchronous points on the worker thread, in calls to the [IHostThreadPoolManager::QueueUserWorkItem](ihostthreadpoolmanager-queueuserworkitem-method.md) method.  
  
- In servicing of I/O completion ports.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
