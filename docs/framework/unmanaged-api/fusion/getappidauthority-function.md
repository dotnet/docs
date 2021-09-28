---
description: "Learn more about: GetAppIdAuthority Function"
title: "GetAppIdAuthority Function"
ms.date: "03/30/2017"
api_name: 
  - "GetAppIdAuthority"
api_location: 
  - "fusion.dll"
  - "clr.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetAppIdAuthority"
helpviewer_keywords: 
  - "GetAppIdAuthority function [.NET Framework fusion]"
ms.assetid: 9f968dad-0d09-47fb-bebc-94c39a0d16ad
topic_type: 
  - "apiref"
---
# GetAppIdAuthority Function

Gets a pointer to an [IAppIdAuthority](iappidauthority-interface.md) instance that manages keys for application identities and references.  
  
## Syntax  
  
```cpp  
HRESULT GetAppIdAuthority (  
    [out] IAppIdAuthority **ppIAppIdAuthority  
 );  
```  
  
## Parameters  

 `ppIAppIdAuthority`  
 [out] The returned `IAppIdAuthority` pointer.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAppIdAuthority Interface](iappidauthority-interface.md)
- [Fusion Global Static Functions](fusion-global-static-functions.md)
