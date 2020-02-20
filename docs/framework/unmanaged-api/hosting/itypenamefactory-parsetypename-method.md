---
title: "ITypeNameFactory::ParseTypeName Method"
ms.date: "03/30/2017"
api_name: 
  - "ITypeNameFactory.ParseTypeName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ParseTypeName"
helpviewer_keywords: 
  - "ITypeNameFactory::ParseTypeName method [.NET Framework hosting]"
  - "ParseTypeName method [.NET Framework hosting]"
ms.assetid: 13c9f063-371c-4911-a5e7-e1e0b88ae382
topic_type: 
  - "apiref"
---
# ITypeNameFactory::ParseTypeName Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT ParseTypeName (  
    [in]  LPCWSTR             szName,  
    [out] DWORD*              pError,  
    [out, retval] ITypeName** ppTypeName  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
