---
title: "ICLRControl::SetAppDomainManagerType Method"
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
  - "ICLRControl.SetAppDomainManagerType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRControl::SetAppDomainManagerType"
helpviewer_keywords: 
  - "SetAppDomainManagerType method, ICLRControl interface [.NET Framework hosting]"
  - "ICLRControl::SetAppDomainManagerType method [.NET Framework hosting]"
ms.assetid: ec57828b-2aad-496d-a35a-e45d4bd7fe77
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRControl::SetAppDomainManagerType Method
Sets a type derived from <xref:System.AppDomainManager> as the type for application domain managers.  
  
## Syntax  
  
```  
HRESULT SetAppDomainManagerType (  
    [in] LPCWSTR pwzAppDomainManagerAssembly,  
    [in] LPCWSTR pwzAppDomainManagerType  
);  
```  
  
#### Parameters  
 `pwzAppDomainManagerAssembly`  
 [in] The name of the assembly in which the requested type derived from <xref:System.AppDomainManager> is implemented.  
  
 `pwzAppDomainManagerType`  
 [in] The name of the type implemented in the `pwzAppDomainManagerAssembly` parameter that implements the capabilities of <xref:System.AppDomainManager>.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [IHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-interface.md)
