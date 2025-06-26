---
description: "Learn more about: ICLRRuntimeHost::UnloadAppDomain Method"
title: "ICLRRuntimeHost::UnloadAppDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeHost.UnloadAppDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::UnloadAppDomain"
helpviewer_keywords: 
  - "ICLRRuntimeHost::UnloadAppDomain method [.NET Framework hosting]"
  - "UnloadAppDomain method [.NET Framework hosting]"
ms.assetid: 571912bc-3429-4ff8-8eb2-ea993ffbd901
topic_type: 
  - "apiref"
---
# ICLRRuntimeHost::UnloadAppDomain Method

Unloads the managed <xref:System.AppDomain> that corresponds to the specified numeric identifier.  
  
## Syntax  
  
```cpp  
HRESULT UnloadAppDomain(  
    [in] DWORD dwAppDomainId  
    [in] BOOL  fWaitUntilDone  
);  
```  
  
## Parameters  

 `dwAppDomainId`  
 [in] The numeric identifier of the application domain to unload.  
  
 `fWaitUntilDone`  
 [in] `true` to indicate that the common language runtime( CLR) must wait until it has finished executing the application's current thread before attempting to unload the application domain.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`UnloadAppDomain` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 You can get the numeric identifier of the application domain in which the current thread is executing by calling [GetCurrentAppDomainId](iclrruntimehost-getcurrentappdomainid-method.md). This identifier corresponds to the <xref:System.AppDomain.Id%2A> property of the managed <xref:System.AppDomain> type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
