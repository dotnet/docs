---
description: "Learn more about: ICorRuntimeHost::EnumDomains Method"
title: "ICorRuntimeHost::EnumDomains Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.EnumDomains"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::EnumDomains"
helpviewer_keywords: 
  - "ICorRuntimeHost::EnumDomains method [.NET Framework hosting]"
  - "EnumDomains method [.NET Framework hosting]"
ms.assetid: 96b74995-0cde-4876-b6df-7fc164e6a5d1
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::EnumDomains Method

Gets an enumerator for the domains in the current process.  
  
## Syntax  
  
```cpp  
HRESULT EnumDomains (  
    [out] HCORENUM *hEnum  
);  
```  
  
## Parameters  

 `hEnum`  
 [out] An enumerator for the domains.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Version:** 1.0, 1.1  
  
## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
