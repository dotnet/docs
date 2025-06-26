---
description: "Learn more about: IHostIoCompletionManager::SetCLRIoCompletionManager Method"
title: "IHostIoCompletionManager::SetCLRIoCompletionManager Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostIoCompletionManager.SetCLRIoCompletionManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostIoCompletionManager::SetCLRIoCompletionManager"
helpviewer_keywords: 
  - "IHostIoCompletionManager::SetCLRIoCompletionManager method [.NET Framework hosting]"
  - "SetCLRIoCompletionManager method [.NET Framework hosting]"
ms.assetid: 4254bb01-3a14-4f34-a3be-60ff1f5072b5
topic_type: 
  - "apiref"
---
# IHostIoCompletionManager::SetCLRIoCompletionManager Method

Provides the host with an interface pointer to the [ICLRIoCompletionManager](iclriocompletionmanager-interface.md) instance implemented by the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT SetCLRIoCompletionManager (  
    [in] ICLRIoCompletionManager *pManager  
);  
```  
  
## Parameters  

 `pManager`  
 [in] An interface pointer to an `ICLRIoCompletionManager` instance provided by the CLR.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetCLRIoCompletionManager` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 After the CLR has called `SetCLRIoCompletionManager`, the host must call [ICLRIoCompletionManager::OnComplete](iclriocompletionmanager-oncomplete-method.md) to notify the CLR when an I/O request has been completed.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)
- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
