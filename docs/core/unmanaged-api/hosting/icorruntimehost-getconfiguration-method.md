---
description: "Learn more about: ICorRuntimeHost::GetConfiguration Method"
title: "ICorRuntimeHost::GetConfiguration Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.GetConfiguration"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::GetConfiguration"
helpviewer_keywords: 
  - "ICorRuntimeHost::GetConfiguration method [.NET Framework hosting]"
  - "GetConfiguration method [.NET Framework hosting]"
ms.assetid: c431617a-b055-44a0-8730-48b7a86d9610
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::GetConfiguration Method

Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT GetConfiguration(  
    [out] ICorConfiguration** pConfiguration  
);  
```  
  
## Parameters  

 `pConfiguration`  
 [out] A pointer to the address of an [ICorConfiguration](icorconfiguration-interface.md) object that can be used to configure the CLR.  
  
## Remarks  

 The CLR must be configured prior to its initialization; otherwise, the `GetConfiguration` method returns an HRESULT indicating an error.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
