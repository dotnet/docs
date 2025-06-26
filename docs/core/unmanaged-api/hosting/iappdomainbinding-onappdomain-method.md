---
description: "Learn more about: IAppDomainBinding::OnAppDomain Method"
title: "IAppDomainBinding::OnAppDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "IAppDomainBinding.OnAppDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "OnAppDomain"
helpviewer_keywords: 
  - "IAppDomainBinding::OnAppDomain method [.NET Framework hosting]"
  - "OnAppDomain method [.NET Framework hosting]"
ms.assetid: b419dcc9-e8aa-484b-af0d-0f40358edb99
topic_type: 
  - "apiref"
---
# IAppDomainBinding::OnAppDomain Method

Called by the common language runtime (CLR) to notify the host that an application domain has been created.  
  
## Syntax  
  
```cpp  
HRESULT OnAppDomain (  
    [in] IUnknown* pAppdomain  
);  
```  
  
## Parameters  

 `pAppdomain`  
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) interface object that represents the new application domain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAppDomainBinding Interface](iappdomainbinding-interface.md)
