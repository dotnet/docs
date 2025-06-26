---
description: "Learn more about: ICorRuntimeHost::CreateEvidence Method"
title: "ICorRuntimeHost::CreateEvidence Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.CreateEvidence"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::CreateEvidence"
helpviewer_keywords: 
  - "CreateEvidence method [.NET Framework hosting]"
  - "ICorRuntimeHost::CreateEvidence method [.NET Framework hosting]"
ms.assetid: e235ea80-b84c-4442-a4c3-fc96c25a8eb9
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::CreateEvidence Method

Gets an interface pointer of type <xref:System.Security.Principal.IIdentity?displayProperty=nameWithType>, which allows the host to create security evidence to pass to the [CreateDomain](icorruntimehost-createdomain-method.md) or [CreateDomainEx](icorruntimehost-createdomainex-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT CreateEvidence (  
    [out] IUnknown** pEvidence  
);  
```  
  
## Parameters  

 `pEvidence`  
 [out] A interface pointer to an <xref:System.Security.Principal.IIdentity?displayProperty=nameWithType> instance used to create security evidence. This pointer is typed `IUnknown`, so callers should typically call `QueryInterface` on this interface to obtain a pointer to an <xref:System.Security.Principal.IIdentity?displayProperty=nameWithType>.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Remarks  

 This method returns an empty collection that cannot be populated from native code. You should use the <xref:System.Security.Policy.Evidence> method instead.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Version:** 1.0, 1.1  
  
## See also

- <xref:System._AppDomain>
- <xref:System.AppDomain>
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
