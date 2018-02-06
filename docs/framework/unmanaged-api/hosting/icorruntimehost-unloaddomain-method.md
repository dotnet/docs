---
title: "ICorRuntimeHost::UnloadDomain Method"
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
  - "ICorRuntimeHost.UnloadDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::UnloadDomain"
helpviewer_keywords: 
  - "ICorRuntimeHost::UnloadDomain method [.NET Framework hosting]"
  - "UnloadDomain method [.NET Framework hosting]"
ms.assetid: dd9e9204-a80d-44f3-8192-779224b35056
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorRuntimeHost::UnloadDomain Method
Unloads the specified application domain from the current process.  
  
## Syntax  
  
```  
HRESULT UnloadDomain (  
    [in] IUnknown* pAppDomain  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer of type <xref:System._AppDomain?displayProperty=nameWithType> that represents the domain to be unloaded.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Version:** 1.0, 1.1  
  
## See Also  
 <xref:System._AppDomain>  
 <xref:System.AppDomain>  
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)
