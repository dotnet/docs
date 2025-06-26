---
description: "Learn more about: IHostCrst::Leave Method"
title: "IHostCrst::Leave Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostCrst.Leave"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostCrst::Leave"
helpviewer_keywords: 
  - "IHostCrst::Leave method [.NET Framework hosting]"
  - "Leave method [.NET Framework hosting]"
ms.assetid: dfc51d9e-b36d-4dba-9ea1-4f63fa0601ae
topic_type: 
  - "apiref"
---
# IHostCrst::Leave Method

Leaves the critical section that is represented by the current instance of [IHostCrst](ihostcrst-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT Leave ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Leave` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `Leave` allows the CLR to communicate directly with the host's threading implementation, rather than using the corresponding Win32 `LeaveCriticalSection` function. A thread that takes ownership of the critical section represented by the current `IHostCrst` instance must call `Leave` once for each time it enters that critical section.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostCrst Interface](ihostcrst-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
