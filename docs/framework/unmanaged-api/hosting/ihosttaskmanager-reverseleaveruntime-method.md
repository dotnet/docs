---
description: "Learn more about: IHostTaskManager::ReverseLeaveRuntime Method"
title: "IHostTaskManager::ReverseLeaveRuntime Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.ReverseLeaveRuntime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::ReverseLeaveRuntime"
helpviewer_keywords: 
  - "IHostTaskManager::ReverseLeaveRuntime method [.NET Framework hosting]"
  - "ReverseLeaveRuntime method [.NET Framework hosting]"
ms.assetid: 4837d398-16a1-4e32-902c-022cd1aad3ca
topic_type: 
  - "apiref"
---
# IHostTaskManager::ReverseLeaveRuntime Method

Notifies the host that control is leaving the common language runtime (CLR) and entering an unmanaged function that was, in turn, called from managed code.  
  
## Syntax  
  
```cpp  
HRESULT ReverseLeaveRuntime ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ReverseLeaveRuntime` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory is available to complete the requested resource allocation.|  
  
## Remarks  

 The CLR calls `ReverseLeaveRuntime` to inform the host that the currently executing task is returning control to an unmanaged function that was, in turn, called from managed code through platform invoke. Each call to `ReverseLeaveRuntime` matches a corresponding call to [ReverseEnterRuntime](ihosttaskmanager-reverseenterruntime-method.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [CallNeedsHostHook Method](ihosttaskmanager-callneedshosthook-method.md)
- [EnterRuntime Method](ihosttaskmanager-enterruntime-method.md)
- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [LeaveRuntime Method](ihosttaskmanager-leaveruntime-method.md)
- [A Closer Look at Platform Invoke](/previous-versions/dotnet/netframework-4.0/0h9e9t7d(v=vs.100))
