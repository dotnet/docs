---
description: "Learn more about: ITypeName::GetTypeArguments Method"
title: "ITypeName::GetTypeArguments Method"
ms.date: "03/30/2017"
api_name: 
  - "ITypeName.GetTypeArguments"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetTypeArguments"
helpviewer_keywords: 
  - "ITypeName::GetTypeArguments method [.NET Framework hosting]"
  - "GetTypeArguments method [.NET Framework hosting]"
ms.assetid: 638d77df-ff9c-40d9-88ee-930f5f87ada1
topic_type: 
  - "apiref"
---
# ITypeName::GetTypeArguments Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeArguments (  
    [in] DWORD           count,  
    [out] ITypeName**    rgpArguments,  
    [out, retval] DWORD* pCount  
);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
