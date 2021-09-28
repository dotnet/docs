---
description: "Learn more about: ICorRuntimeHost::NextDomain Method"
title: "ICorRuntimeHost::NextDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.NextDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::NextDomain"
helpviewer_keywords: 
  - "ICorRuntimeHost::NextDomain method [.NET Framework hosting]"
  - "NextDomain method [.NET Framework hosting]"
ms.assetid: fe07a05b-f6d6-44b5-ab01-b9a6eb15c350
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::NextDomain Method

Gets an interface pointer to the next domain in the enumeration.  
  
## Syntax  
  
```cpp  
HRESULT NextDomain (  
    [in] HCORENUM hEnum,  
    [out] void** pAppDomain  
);  
```  
  
## Parameters  

 `hEnum`  
 [in] The enumerator that was obtained through a call to [EnumDomains](icorruntimehost-enumdomains-method.md).  
  
 `pAppDomain`  
 [out] An interface pointer to the <xref:System._AppDomain?displayProperty=nameWithType> type that represents the next domain in the enumeration, or null, if no more domains exist.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete, or there are no more domains in the enumeration.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- <xref:System._AppDomain>
- <xref:System.AppDomain>
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
