---
description: "Learn more about: ITypeName::GetModifiers Method"
title: "ITypeName::GetModifiers Method"
ms.date: "03/30/2017"
api_name: 
  - "ITypeName.GetModifiers"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetModifiers"
helpviewer_keywords: 
  - "ITypeName::GetModifiers method [.NET Framework hosting]"
  - "GetModifiers method [.NET Framework hosting]"
ms.assetid: 75508c55-3e09-4135-80da-cc811003fa82
topic_type: 
  - "apiref"
---
# ITypeName::GetModifiers Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT GetModifiers (  
    [in] DWORD           count,  
    [out] DWORD*         rgModifiers,  
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
