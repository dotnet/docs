---
title: "IAppDomainBinding::OnAppDomain Method"
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
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAppDomainBinding::OnAppDomain Method
Called by the common language runtime (CLR) to notify the host that an application domain has been created.  
  
## Syntax  
  
```  
HRESULT OnAppDomain (  
    [in] IUnknown* pAppdomain  
);  
```  
  
#### Parameters  
 `pAppdomain`  
 [in] A pointer to an [IUnknown](https://msdn.microsoft.com/library/94as6ehy(v=vs.110).aspx) interface object that represents the new application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAppDomainBinding Interface](../../../../docs/framework/unmanaged-api/hosting/iappdomainbinding-interface.md)
