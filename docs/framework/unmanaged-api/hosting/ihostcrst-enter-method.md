---
description: "Learn more about: IHostCrst::Enter Method"
title: "IHostCrst::Enter Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostCrst.Enter"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostCrst::Enter"
helpviewer_keywords: 
  - "Enter method [.NET Framework hosting]"
  - "IHostCrst::Enter method [.NET Framework hosting]"
ms.assetid: 100dd7eb-7053-4295-9bb3-32ba47f6ec79
topic_type: 
  - "apiref"
---
# IHostCrst::Enter Method

Enters the critical section that is represented by the current [IHostCrst](ihostcrst-interface.md) instance.  
  
## Syntax  
  
```cpp  
HRESULT Enter (  
    [in] DWORD option  
);  
```  
  
## Parameters  

 `option`  
 [in] One of the [WAIT_OPTION](wait-option-enumeration.md) values, indicating what action the host should take if the operation blocks.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Enter` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `Enter` mirrors the Win32 `EnterCriticalSection` function.  
  
> [!NOTE]
> This method does not return until the critical section is entered.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostCrst Interface](ihostcrst-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
