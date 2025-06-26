---
description: "Learn more about: ICorRuntimeHost::GetDefaultDomain Method"
title: "ICorRuntimeHost::GetDefaultDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.GetDefaultDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::GetDefaultDomain"
helpviewer_keywords: 
  - "ICorRuntimeHost::GetDefaultDomain method [.NET Framework hosting]"
  - "GetDefaultDomain method [.NET Framework hosting]"
ms.assetid: 5e17a6fc-f335-4aae-9bb0-c3e1271a9426
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::GetDefaultDomain Method

Gets an interface pointer of type <xref:System._AppDomain?displayProperty=nameWithType> that represents the default domain for the current process.  
  
## Syntax  
  
```cpp  
HRESULT GetDefaultDomain (  
    [out] IUnknown** pAppDomain  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [out] An interface pointer of type <xref:System._AppDomain?displayProperty=nameWithType> to the <xref:System.AppDomain> instance that represents the default application domain for the process.  
  
 This pointer is typed `IUnknown`, so callers should generally call `QueryInterface` to obtain an interface pointer of type <xref:System._AppDomain?displayProperty=nameWithType>.  
  
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
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- <xref:System._AppDomain>
- <xref:System.AppDomain>
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
