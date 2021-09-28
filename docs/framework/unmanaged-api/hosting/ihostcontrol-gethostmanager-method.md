---
description: "Learn more about: IHostControl::GetHostManager Method"
title: "IHostControl::GetHostManager Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostControl.GetHostManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostControl::GetHostManager"
helpviewer_keywords: 
  - "GetHostManager method [.NET Framework hosting]"
  - "IHostControl::GetHostManager method [.NET Framework hosting]"
ms.assetid: 0fa34bca-ed18-4626-9e78-d33684d18edb
topic_type: 
  - "apiref"
---
# IHostControl::GetHostManager Method

Gets an interface pointer to the host's implementation of the interface with the specified `IID`.  
  
## Syntax  
  
```cpp  
HRESULT GetHostManager (  
    [in] REFIID riid,  
    [out, iid_is(riid)] void** ppObject  
);  
```  
  
## Parameters  

 `riid`  
 [in] The `IID` of the interface that the common language runtime (CLR) is querying for.  
  
 `ppObject`  
 [out] A pointer to the host-implemented interface, or null if the host does not support this interface.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetHostManager` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|The requested `IID` is not valid.|  
|E_NOINTERFACE|The requested interface is not supported.|  
  
## Remarks  

 The CLR queries the host to determine whether it supports one or more of the following interfaces:  
  
- [IHostMemoryManager](ihostmemorymanager-interface.md)  
  
- [IHostTaskManager](ihosttaskmanager-interface.md)  
  
- [IHostThreadPoolManager](ihostthreadpoolmanager-interface.md)  
  
- [IHostIoCompletionManager](ihostiocompletionmanager-interface.md)  
  
- [IHostSyncManager](ihostsyncmanager-interface.md)  
  
- [IHostAssemblyManager](ihostassemblymanager-interface.md)  
  
- [IHostGCManager](ihostgcmanager-interface.md)  
  
- [IHostPolicyManager](ihostpolicymanager-interface.md)  
  
- [IHostSecurityManager](ihostsecuritymanager-interface.md)  
  
 If the host supports the specified interface, it sets `ppObject` to its implementation of that interface. Otherwise, it sets `ppObject` to null.  
  
 The CLR does not call `Release` on host managers, even when you shut it down.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostControl Interface](ihostcontrol-interface.md)
