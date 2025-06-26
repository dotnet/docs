---
description: "Learn more about: IHostCrst::SetSpinCount Method"
title: "IHostCrst::SetSpinCount Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostCrst.SetSpinCount"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostCrst::SetSpinCount"
helpviewer_keywords: 
  - "IHostCrst::SetSpinCount method [.NET Framework hosting]"
  - "SetSpinCount method [.NET Framework hosting]"
ms.assetid: 863fc8ce-9b8a-477e-8dd8-75c8544bb43a
topic_type: 
  - "apiref"
---
# IHostCrst::SetSpinCount Method

Sets the spin count for the current [IHostCrst](ihostcrst-interface.md) instance.  
  
## Syntax  
  
```cpp  
HRESULT SetSpinCount (  
    [in] DWORD dwSpinCount  
);  
```  
  
## Parameters  

 `dwSpinCount`  
 [in] The new spin count for the current `IHostCrst` instance.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetSpinCount` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 On multi-processor systems, if the critical section represented by the current `IHostCrst` instance is unavailable, a calling thread spins `dwSpinCount` times before calling [IHostSemaphore::Wait](ihostsemaphore-wait-method.md) on a semaphore associated with the critical section. If the critical section becomes free during the spin operation, the calling thread avoids the wait operation.  
  
 The usage of `dwSpinCount` is identical to the usage of the parameter of the same name in the Win32 `InitializeCriticalSectionAndSpinCount` function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostCrst Interface](ihostcrst-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
