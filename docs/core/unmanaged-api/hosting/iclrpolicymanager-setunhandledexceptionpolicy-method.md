---
description: "Learn more about: ICLRPolicyManager::SetUnhandledExceptionPolicy Method"
title: "ICLRPolicyManager::SetUnhandledExceptionPolicy Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRPolicyManager.SetUnhandledExceptionPolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager::SetUnhandledExceptionPolicy"
helpviewer_keywords: 
  - "ICLRPolicyManager::SetUnhandledExceptionPolicy method [.NET Framework hosting]"
  - "SetUnhandledExceptionPolicy method [.NET Framework hosting]"
ms.assetid: 5268480e-280a-4931-b7a3-dc3ffdf7f78f
topic_type: 
  - "apiref"
---
# ICLRPolicyManager::SetUnhandledExceptionPolicy Method

Specifies the behavior of the common language runtime (CLR) when an unhandled exception occurs.  
  
## Syntax  
  
```cpp  
HRESULT SetUnhandledExceptionPolicy (  
    [in] EClrUnhandledExceptionPolicy policy  
);  
```  
  
## Parameters  

 `policy`  
 [in] One of the [EClrUnhandledException](eclrunhandledexception-enumeration.md) values, indicating whether the behavior is set by the CLR or the host.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetUnhandledExceptionPolicy` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 By default, the CLR is the final handler for all unhandled exceptions, and its default behavior is to tear down the process. The host can change this behavior by setting the `policy` value to eHostDeterminedPolicy. This value allows the host to implement its own default behavior, as with earlier versions of the CLR.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrUnhandledException Enumeration](eclrunhandledexception-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
