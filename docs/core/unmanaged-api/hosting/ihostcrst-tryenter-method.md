---
description: "Learn more about: IHostCrst::TryEnter Method"
title: "IHostCrst::TryEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostCrst.TryEnter"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostCrst::TryEnter"
helpviewer_keywords: 
  - "IHostCrst::TryEnter method [.NET Framework hosting]"
  - "TryEnter method [.NET Framework hosting]"
ms.assetid: a922fa98-beab-4f09-a342-cc94fc65687f
topic_type: 
  - "apiref"
---
# IHostCrst::TryEnter Method

Attempts to enter the critical section represented by the current [IHostCrst](ihostcrst-interface.md) instance.  
  
## Syntax  
  
```cpp  
HRESULT TryEnter (  
    [in]  DWORD  option,  
    [out] BOOL   *pbSucceeded  
);  
```  
  
## Parameters  

 `option`  
 [in] One of the [WAIT_OPTION](wait-option-enumeration.md) values, indicating what action the host should take if the operation blocks.  
  
 `pbSucceeded`  
 [out] `true` if the critical section can be entered; otherwise, `false`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`TryEnter` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `TryEnter` returns immediately and indicates whether the calling thread entered the critical section. This method mirrors the Wind32 `TryEnterCriticalSection` function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostCrst Interface](ihostcrst-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
