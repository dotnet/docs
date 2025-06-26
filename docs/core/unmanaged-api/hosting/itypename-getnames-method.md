---
description: "Learn more about: ITypeName::GetNames Method"
title: "ITypeName::GetNames Method"
ms.date: "03/30/2017"
api_name: 
  - "ITypeName.GetNames"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetNames"
helpviewer_keywords: 
  - "ITypeName::GetNames method [.NET Framework hosting]"
  - "GetNames method [.NET Framework hosting]"
ms.assetid: e2a3637b-d1e9-4d93-9e9b-0555fbff793d
topic_type: 
  - "apiref"
---
# ITypeName::GetNames Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT GetNames (  
    [in] DWORD           count,  
    [out] BSTR*          rgbszNames,  
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
