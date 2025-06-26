---
description: "Learn more about: IHostTaskManager::ReverseEnterRuntime Method"
title: "IHostTaskManager::ReverseEnterRuntime Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.ReverseEnterRuntime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::ReverseEnterRuntime"
helpviewer_keywords: 
  - "IHostTaskManager::ReverseEnterRuntime method [.NET Framework hosting]"
  - "ReverseEnterRuntime method [.NET Framework hosting]"
ms.assetid: b1e26bff-d3ea-436e-9867-29720df999f4
topic_type: 
  - "apiref"
---
# IHostTaskManager::ReverseEnterRuntime Method

Notifies the host that a call is being made into the common language runtime (CLR) from unmanaged code.  
  
## Syntax  
  
```cpp  
HRESULT ReverseEnterRuntime ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ReverseEnterRuntime` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory is available to complete the requested resource allocation.|  
  
## Remarks  

 If the call into the CLR is made from a sequence that originated in managed code, each call to `ReverseEnterRuntime` corresponds to a call to [ReverseLeaveRuntime](ihosttaskmanager-reverseleaveruntime-method.md).  
  
> [!NOTE]
> Calls can originate from unmanaged code without being nested. In this case, there is no call to [EnterRuntime](ihosttaskmanager-enterruntime-method.md), [LeaveRuntime](ihosttaskmanager-leaveruntime-method.md), or `ReverseLeaveRuntime`, and the number of calls to `ReverseEnterRuntime` does not equal the number of calls to `ReverseLeaveRuntime`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
