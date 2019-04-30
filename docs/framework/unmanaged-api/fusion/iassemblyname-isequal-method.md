---
title: "IAssemblyName::IsEqual Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyName.IsEqual"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::IsEqual"
helpviewer_keywords: 
  - "IsEqual method [.NET Framework fusion]"
  - "IAssemblyName::IsEqual method [.NET Framework fusion]"
ms.assetid: 6dfc220f-d0d4-45b3-bfce-5829f817766f
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IAssemblyName::IsEqual Method
Determines whether a specified [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) object is equal to this `IAssemblyName`, based on the specified comparison flags.  
  
## Syntax  
  
```  
HRESULT IsEqual (  
    [in] IAssemblyName  *pName,  
    [in] DWORD          dwCmpFlags  
);  
```  
  
## Parameters  
 `pName`  
 [in] The `IAssemblyName` object to which to compare this `IAssemblyName`.  
  
 `dwCmpFlags`  
 [in] A bitwise combination of [ASM_CMP_FLAGS](../../../../docs/framework/unmanaged-api/fusion/asm-cmp-flags-enumeration.md) values that influence the comparison.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)
- [Fusion Enumerations](../../../../docs/framework/unmanaged-api/fusion/fusion-enumerations.md)
