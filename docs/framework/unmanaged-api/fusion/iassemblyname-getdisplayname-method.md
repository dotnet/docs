---
description: "Learn more about: IAssemblyName::GetDisplayName Method"
title: "IAssemblyName::GetDisplayName Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyName.GetDisplayName"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::GetDisplayName"
helpviewer_keywords: 
  - "GetDisplayName method, IAssemblyName interface [.NET Framework fusion]"
  - "IAssemblyName::GetDisplayName method [.NET Framework fusion]"
ms.assetid: 9a26547a-9a34-4284-a463-78a7d4b496cf
topic_type: 
  - "apiref"
---
# IAssemblyName::GetDisplayName Method

Gets the human-readable name of the assembly referenced by this [IAssemblyName](iassemblyname-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetDisplayName (  
        [out]      LPOLESTR  szDisplayName,  
        [in, out]  LPDWORD   pccDisplayName,  
        [in]       DWORD     dwDisplayFlags  
);  
```  
  
## Parameters  

 `szDisplayName`  
 [out] The string buffer that contains the name of the referenced assembly.  
  
 `pccDisplayName`  
 [in, out] The size of `szDisplayName` in wide characters, including a null terminator character.  
  
 `dwDisplayFlags`  
 [in] A bitwise combination of [ASM_DISPLAY_FLAGS](asm-display-flags-enumeration.md) values that influence the features of `szDisplayName`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Enumerations](fusion-enumerations.md)
