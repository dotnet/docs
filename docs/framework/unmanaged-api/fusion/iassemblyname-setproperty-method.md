---
title: "IAssemblyName::SetProperty Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyName.SetProperty"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::SetProperty"
helpviewer_keywords: 
  - "IAssemblyName::SetProperty method [.NET Framework fusion]"
  - "SetProperty method [.NET Framework fusion]"
ms.assetid: 496c3add-f60b-4073-943f-d1bcf33330cb
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IAssemblyName::SetProperty Method
Sets the value of the property referenced by the specified property identifier.  
  
## Syntax  
  
```  
HRESULT SetProperty (  
    [in] DWORD  PropertyId,  
    [in] LPVOID pvProperty,  
    [in] DWORD  cbProperty  
);  
```  
  
#### Parameters  
 `PropertyId`  
 [in] The unique identifier of the property whose value will be set.  
  
 `pvProperty`  
 [in] The value to which to set the property referenced by `PropertyId`.  
  
 `cbProperty`  
 [in] The size, in bytes, of `pvProperty`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)
