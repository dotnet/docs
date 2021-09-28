---
description: "Learn more about: ICorRuntimeHost::CloseEnum Method"
title: "ICorRuntimeHost::CloseEnum Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.CloseEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::CloseEnum"
helpviewer_keywords: 
  - "CloseEnum method, ICorRuntimeHost interface [.NET Framework hosting]"
  - "ICorRuntimeHost::CloseEnum method [.NET Framework hosting]"
ms.assetid: f7ce7e8c-0a3e-4587-a180-063e2b85940e
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::CloseEnum Method

Resets a domain enumerator back to the beginning of the domain list.  
  
## Syntax  
  
```cpp  
HRESULT CloseEnum (  
    [in] HCORENUM hEnum  
);  
```  
  
## Parameters  

 `hEnum`  
 [in] The enumerator to reset.  
  
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

- [CorBindToRuntimeEx Function](corbindtoruntimeex-function.md)
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
