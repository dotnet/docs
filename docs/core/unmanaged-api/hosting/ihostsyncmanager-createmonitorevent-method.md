---
description: "Learn more about: IHostSyncManager::CreateMonitorEvent Method"
title: "IHostSyncManager::CreateMonitorEvent Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSyncManager.CreateMonitorEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSyncManager::CreateMonitorEvent"
helpviewer_keywords: 
  - "CreateMonitorEvent method [.NET Framework hosting]"
  - "IHostSyncManager::CreateMonitorEvent method [.NET Framework hosting]"
ms.assetid: 524c7fd3-9b5c-46e7-99ba-555fd2fe33f0
topic_type: 
  - "apiref"
---
# IHostSyncManager::CreateMonitorEvent Method

Creates a monitored auto-reset event object.  
  
## Syntax  
  
```cpp  
HRESULT CreateMonitorEvent (  
    [in]  SIZE_T cookie,  
    [out] IHostAutoEvent **ppEvent  
);  
```  
  
## Parameters  

 `cookie`  
 [in] A cookie to associate with the event object.  
  
 `ppEvent`  
 [out] A pointer to the address of an [IHostAutoEvent](ihostautoevent-interface.md) instance, or null if the event object could not be created.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`CreateMonitorEvent` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to create the requested event object.|  
  
## Remarks  

 `CreateMonitorEvent` returns an `IHostAutoEvent` that the CLR uses in its implementation of the managed <xref:System.Threading.Monitor?displayProperty=nameWithType> type. This method mirrors the Win32 `CreateEvent` function, with a value of `false` specified for the `bManualReset` parameter.  
  
 The host can use the cookie to determine which task is waiting on the monitor by calling the [ICLRSyncManager::GetMonitorOwner](iclrsyncmanager-getmonitorowner-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- <xref:System.Threading.Monitor>
