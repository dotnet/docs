---
description: "Learn more about: IHostTaskManager::EnterRuntime Method"
title: "IHostTaskManager::EnterRuntime Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.EnterRuntime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::EnterRuntime"
helpviewer_keywords: 
  - "IHostTaskManager::EnterRuntime method [.NET Framework hosting]"
  - "EnterRuntime method [.NET Framework hosting]"
ms.assetid: 1aa7a4b1-636a-4f5e-b834-b406d72f7120
topic_type: 
  - "apiref"
---
# IHostTaskManager::EnterRuntime Method

Notifies the host that a call to an unmanaged method, such as a platform invoke method, is returning execution control to the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT EnterRuntime ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`EnterRuntime` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to complete the requested allocation.|  
  
## Remarks  

 `EnterRuntime` is called to notify the host that an unmanaged function, for which an earlier call to the [LeaveRuntime](ihosttaskmanager-leaveruntime-method.md) method was made, has finished executing, and is returning execution control to the runtime.  
  
> [!NOTE]
> [ReverseEnterRuntime](ihosttaskmanager-reverseenterruntime-method.md) is called to notify the host that an unmanaged function, for which an earlier call to `LeaveRuntime` was made, is making a call into managed code.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Advanced COM Interoperability](/previous-versions/dotnet/netframework-4.0/bd9cdfyx(v=vs.100))
- [How to: Call Native DLLs from Managed Code Using PInvoke](/cpp/dotnet/how-to-call-native-dlls-from-managed-code-using-pinvoke)
- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [LeaveRuntime Method](ihosttaskmanager-leaveruntime-method.md)
