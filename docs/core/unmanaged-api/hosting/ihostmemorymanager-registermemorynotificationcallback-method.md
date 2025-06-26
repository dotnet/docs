---
description: "Learn more about: IHostMemoryManager::RegisterMemoryNotificationCallback Method"
title: "IHostMemoryManager::RegisterMemoryNotificationCallback Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostMemoryManager.RegisterMemoryNotificationCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::RegisterMemoryNotificationCallback"
helpviewer_keywords: 
  - "IHostMemoryManager::RegisterMemoryNotificationCallback method [.NET Framework hosting]"
  - "RegisterMemoryNotificationCallback method [.NET Framework hosting]"
ms.assetid: 65d301f6-4dbb-4b5f-8eff-82540e2b6465
topic_type: 
  - "apiref"
---
# IHostMemoryManager::RegisterMemoryNotificationCallback Method

Registers a pointer to a callback function that the host invokes to notify the common language runtime (CLR) of the current memory load on the computer.  
  
## Syntax  
  
```cpp  
HRESULT RegisterMemoryNotificationCallback (  
    [in] ICLRMemoryNotificationCallback* pCallback  
);  
```  
  
## Parameters  

 `pCallback`  
 [in] An interface pointer to an [ICLRMemoryNotificationCallback](iclrmemorynotificationcallback-interface.md) instance that is implemented by the CLR.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`RegisterMemoryNotificationCallback` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 Because the `ICLRMemoryNotificationCallback` interface defines only one method ([ICLRMemoryNotificationCallback::OnMemoryNotification](iclrmemorynotificationcallback-onmemorynotification-method.md)), and because `pCallback` is a pointer to an `ICLRMemoryNotificationCallback` instance provided by the CLR, the registration is effectively for the callback function itself. The host invokes `OnMemoryNotification` to report memory pressure conditions, rather than using the standard Win32 `CreateMemoryResourceNotification` function. For more information, see the Windows Platform documentation.  
  
> [!NOTE]
> Calls to `OnMemoryNotification` never block. They always return immediately.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRMemoryNotificationCallback Interface](iclrmemorynotificationcallback-interface.md)
- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
