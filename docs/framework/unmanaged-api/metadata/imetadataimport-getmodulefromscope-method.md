---
title: "IMetaDataImport::GetModuleFromScope Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetModuleFromScope"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetModuleFromScope"
helpviewer_keywords: 
  - "GetModuleFromScope method [.NET Framework metadata]"
  - "IMetaDataImport::GetModuleFromScope method [.NET Framework metadata]"
ms.assetid: add68d3f-45fd-4bef-af94-eb5273f26b11
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::GetModuleFromScope Method
Gets a metadata token for the module referenced in the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT GetModuleFromScope (  
   [out] mdModule    *pmd  
);  
```  
  
## Parameters  
 `pmd`  
 [out] A pointer to the token representing the module referenced in the current metadata scope.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
