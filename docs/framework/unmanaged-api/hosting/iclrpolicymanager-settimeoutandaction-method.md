---
description: "Learn more about: ICLRPolicyManager::SetTimeoutAndAction Method"
title: "ICLRPolicyManager::SetTimeoutAndAction Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRPolicyManager.SetTimeoutAndAction"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager::SetTimeoutAndAction"
helpviewer_keywords: 
  - "ICLRPolicyManager::SetTimeoutAndAction method [.NET Framework hosting]"
  - "SetTimeoutAndAction method [.NET Framework hosting]"
ms.assetid: 60454f91-d855-4ddf-bb6d-60a02f5eabab
topic_type: 
  - "apiref"
---
# ICLRPolicyManager::SetTimeoutAndAction Method

Sets a timeout value for the specified operation, and specifies the policy action the common language runtime (CLR) should take when the operation occurs.  
  
## Syntax  
  
```cpp  
HRESULT SetTimeoutAndAction (  
    [in] EClrOperation operation,  
    [in] DWORD dwMilliseconds,  
    [in] EPolicyAction action  
);  
```  
  
## Parameters  

 `operation`  
 [in] One of the [EClrOperation](eclroperation-enumeration.md) values, indicating the operation for which to set the timeout and policy `action`. The following values are supported:  
  
- OPR_AppDomainUnload  
  
- OPR_ProcessExit  
  
- OPR_ThreadRudeAbortInCriticalRegion  
  
- OPR_ThreadRudeAbortInNonCriticalRegion  
  
 `dwMilliseconds`  
 [in] The new timeout value, in milliseconds. A value of INFINITE causes `operation` never to time out.  
  
 `action`  
 [in] One of the [EPolicyAction](epolicyaction-enumeration.md) values, indicating the policy action that the CLR should take when `operation` occurs.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetTimeoutAndAction` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|A timeout cannot be set for the specified `operation`, or an invalid value was supplied for `action`.|  
  
## Remarks  

 `SetTimeoutAndAction` encapsulates the capabilities of the [ICLRPolicyManager::SetTimeout](iclrpolicymanager-settimeout-method.md) and [ICLRPolicyManager::SetActionOnTimeout](iclrpolicymanager-setactionontimeout-method.md) methods, and can be called in place of sequential calls to these two methods.  
  
> [!IMPORTANT]
> Not all policy action values can be specified as the timeout behavior for CLR operations. See the Remarks sections of the topics for these two methods for valid values.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [SetActionOnTimeout Method](iclrpolicymanager-setactionontimeout-method.md)
- [ICLRPolicyManager::SetTimeoutAndAction](iclrpolicymanager-settimeoutandaction-method.md)
