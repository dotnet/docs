---
title: "ICorRuntimeHost::CurrentDomain Method"
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
  - "ICorRuntimeHost.CurrentDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::CurrentDomain"
helpviewer_keywords: 
  - "ICorRuntimeHost::CreateDomain method [.NET Framework hosting]"
  - "CurrentDomain method [.NET Framework hosting]"
ms.assetid: dd2afb38-675b-4c3c-a9f3-8ab3b133eb02
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorRuntimeHost::CurrentDomain Method
Gets an interface pointer of type <xref:System.AppDomain?displayProperty=nameWithType> that represents the domain loaded on the current thread.  
  
## Syntax  
  
```  
HRESULT CurrentDomain (  
    [out] IUnknown** pAppDomain  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [out] A pointer of type <xref:System.AppDomain?displayProperty=nameWithType> that represents the thread's current application domain. This pointer is typed `IUnknown`, so callers should generally call `QueryInterface` to obtain a pointer of type <xref:System._AppDomain>.  
  
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
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See Also  
 <xref:System._AppDomain>  
 <xref:System.AppDomain>  
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)
