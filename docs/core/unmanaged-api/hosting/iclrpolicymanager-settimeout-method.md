---
description: "Learn more about: ICLRPolicyManager::SetTimeout Method"
title: "ICLRPolicyManager::SetTimeout Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRPolicyManager.SetTimeout"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager::SetTimeout"
helpviewer_keywords: 
  - "SetTimeout method [.NET Framework hosting]"
  - "ICLRPolicyManager::SetTimeout method [.NET Framework hosting]"
ms.assetid: 954404fd-d52d-4e68-b582-8692f3a5f608
topic_type: 
  - "apiref"
---
# ICLRPolicyManager::SetTimeout Method

Sets a timeout value for the specified operation.  
  
## Syntax  
  
```cpp  
HRESULT SetTimeout (  
    [in] EClrOperation operation,  
    [in] DWORD dsMilliseconds  
);  
```  
  
## Parameters  

 `operation`  
 [in] One of the [EClrOperation](eclroperation-enumeration.md) values, indicating the common language runtime (CLR) operation for which to set a timeout. The following values are supported:  
  
- OPR_AppDomainUnload  
  
- OPR_ProcessExit  
  
- OPR_ThreadRudeAbortInCriticalRegion  
  
- OPR_ThreadRudeAbortInNonCriticalRegion  
  
 `dwMilliseconds`  
 [in] The new timeout value, in milliseconds. A value of INFINITE causes the operation never to time out.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetTimeout` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|A timeout cannot be set for the specified `operation`, or an invalid value was supplied for `operation`.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
