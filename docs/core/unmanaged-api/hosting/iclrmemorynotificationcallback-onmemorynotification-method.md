---
description: "Learn more about: ICLRMemoryNotificationCallback::OnMemoryNotification Method"
title: "ICLRMemoryNotificationCallback::OnMemoryNotification Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMemoryNotificationCallback.OnMemoryNotification"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMemoryNotificationCallback::OnMemoryNotification"
helpviewer_keywords: 
  - "ICLRMemoryNotificationCallback::OnMemoryNotification method [.NET Framework hosting]"
  - "OnMemoryNotification method [.NET Framework hosting]"
ms.assetid: 5612a44d-56cc-4f34-af31-8c9809ba9431
topic_type: 
  - "apiref"
---
# ICLRMemoryNotificationCallback::OnMemoryNotification Method

Notifies the common language runtime (CLR) of the memory load on the computer.  
  
## Syntax  
  
```cpp  
HRESULT OnMemoryNotification (  
    [in] EMemoryAvailable eMemoryAvailable  
);  
```  
  
## Parameters  

 `eMemoryAvailable`  
 [in] One of the [EMemoryAvailable](ememoryavailable-enumeration.md) values, indicating the memory pressure the computer is currently experiencing.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`OnMemoryNotification` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR registers a callback to `OnMemoryNotification` by using a call to the [IHostMemoryManager::RegisterMemoryNotificationCallback](ihostmemorymanager-registermemorynotificationcallback-method.md) method. The runtime uses the information returned in the callback to free additional memory when the host reports that memory resources are running low.  
  
> [!NOTE]
> Calls to `OnMemoryNotification` never block. They always return immediately.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
- [RegisterMemoryNotificationCallback Method](ihostmemorymanager-registermemorynotificationcallback-method.md)
- [ICLRMemoryNotificationCallback Interface](iclrmemorynotificationcallback-interface.md)
