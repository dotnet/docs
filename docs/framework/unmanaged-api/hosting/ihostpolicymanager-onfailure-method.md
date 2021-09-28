---
description: "Learn more about: IHostPolicyManager::OnFailure Method"
title: "IHostPolicyManager::OnFailure Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostPolicyManager.OnFailure"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostPolicyManager::OnFailure"
helpviewer_keywords: 
  - "OnFailure method [.NET Framework hosting]"
  - "IHostPolicyManager::OnFailure method [.NET Framework hosting]"
ms.assetid: 77d3f31e-9a53-4349-9c02-610a71736d42
topic_type: 
  - "apiref"
---
# IHostPolicyManager::OnFailure Method

Notifies the host that the common language runtime (CLR) is about to take the action specified by a call to the [ICLRPolicyManager::SetActionOnFailure](iclrpolicymanager-setactiononfailure-method.md) method in response to a resource allocation or reclamation failure.  
  
## Syntax  
  
```cpp  
HRESULT OnFailure(  
    [in] EClrFailure   failure,  
    [in] EPolicyAction action  
);  
```  
  
## Parameters  

 `failure`  
 [in] One of the [EClrFailure](eclrfailure-enumeration.md) values, indicating the kind of failure to which the CLR is responding.  
  
 `action`  
 [in] One of the [EPolicyAction](epolicyaction-enumeration.md) values, indicating the action the CLR is taking in response to `failure`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`OnFailure` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
