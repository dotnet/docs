---
description: "Learn more about: IHostSecurityManager::SetSecurityContext Method"
title: "IHostSecurityManager::SetSecurityContext Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSecurityManager.SetSecurityContext"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager::SetSecurityContext"
helpviewer_keywords: 
  - "SetSecurityContext method [.NET Framework hosting]"
  - "IHostSecurityManager::SetSecurityContext method [.NET Framework hosting]"
ms.assetid: e4372384-ee69-48d7-97e0-8fab7866597a
topic_type: 
  - "apiref"
---
# IHostSecurityManager::SetSecurityContext Method

Sets the security context of the currently executing thread.  
  
## Syntax  
  
```cpp  
HRESULT SetSecurityContext (  
    [in]  EContextType eContextType,  
    [out] IHostSecurityContext** ppSecurityContext  
);  
```  
  
## Parameters  

 `eContextType`  
 [in] One of the [EContextType](econtexttype-enumeration.md) values, indicating what type of context the common language runtime (CLR) is placing on the host.  
  
 `ppSecurityContext`  
 [out] A pointer to the address of a new [IHostSecurityContext](ihostsecuritycontext-interface.md) object.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetSecurityContext` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR calls `SetSecurityContext` in several scenarios. Before it executes class and module constructors and finalizers, the CLR calls `SetSecurityContext` to protect the host from execution failures. It then resets the security context to its original state after execution of the constructor or finalizer, by using another call to `SetSecurityContext`. A similar pattern occurs with I/O completion. If the host implements [IHostIoCompletionManager](ihostiocompletionmanager-interface.md), the CLR calls `SetSecurityContext` after the host calls [ICLRIoCompletionManager::OnComplete](iclriocompletionmanager-oncomplete-method.md).  
  
 At asynchronous points in worker threads, the CLR calls `SetSecurityContext` within <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> or within [IHostThreadPoolManager::QueueUserWorkItem](ihostthreadpoolmanager-queueuserworkitem-method.md), depending on whether the host or the CLR is implementing the thread pool.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Threading.ThreadPool?displayProperty=nameWithType>
- [EContextType Enumeration](econtexttype-enumeration.md)
- [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)
- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
