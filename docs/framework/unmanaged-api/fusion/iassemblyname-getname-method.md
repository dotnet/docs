---
description: "Learn more about: IAssemblyName::GetName Method"
title: "IAssemblyName::GetName Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyName.GetName"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::GetName"
helpviewer_keywords: 
  - "GetName method, IAssemblyName interface [.NET Framework debugging]"
  - "IAssemblyName::GetName method [.NET Framework fusion]"
ms.assetid: 1dee9781-1cf3-48a9-a376-d18ea1f73280
topic_type: 
  - "apiref"
---
# IAssemblyName::GetName Method

Gets the simple, unencrypted name of the assembly referenced by this [IAssemblyName](iassemblyname-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetName (  
    [in, out] LPDWORD lpcwBuffer,  
    [out]     WCHAR *pwzName  
);  
```  
  
## Parameters  

 `lpcwBuffer`  
 [in, out] The size of `pwzName` in wide characters, including the null terminator character.  
  
 `pwzName`  
 [out] A buffer to hold the name of the referenced assembly.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)
