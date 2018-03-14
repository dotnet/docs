---
title: "ICLRRuntimeHost::ExecuteInAppDomain Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICLRRuntimeHost.ExecuteInAppDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::ExecuteInAppDomain"
helpviewer_keywords: 
  - "ICLRRuntimeHost::ExecuteInAppDomain method [.NET Framework hosting]"
  - "ExecuteInAppDomain method [.NET Framework hosting]"
ms.assetid: e2b0e2db-3fae-4b56-844e-d30a125a660c
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeHost::ExecuteInAppDomain Method
Specifies the <xref:System.AppDomain> in which to execute the specified managed code.  
  
## Syntax  
  
```  
HRESULT ExecuteInAppDomain(  
    [in] DWORD AppDomainId,   
    [in] FExecuteInDomainCallback pCallback,   
    [in] void* cookie  
);  
```  
  
#### Parameters  
 `AppDomainId`  
 [in] The numeric ID of the <xref:System.AppDomain> in which to execute the specified method.  
  
 `pCallback`  
 [in] A pointer to the function to execute within the specified <xref:System.AppDomain>.  
  
 `cookie`  
 [in] A pointer to opaque caller-allocated memory. This parameter is passed by the common language runtime (CLR) to the domain callback. It is not runtime-managed heap memory; both the allocation and lifetime of this memory are controlled by the caller.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ExecuteInAppDomain` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `ExecuteInAppDomain` allows the host to exercise control over which managed <xref:System.AppDomain> the specified managed method should be executed in. You can get the value of an application domain's identifier, which corresponds to the value of the <xref:System.AppDomain.Id%2A> property, by calling [GetCurrentAppDomainId Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-getcurrentappdomainid-method.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md)
