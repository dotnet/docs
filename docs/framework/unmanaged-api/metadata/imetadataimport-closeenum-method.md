---
title: "IMetaDataImport::CloseEnum Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.CloseEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::CloseEnum"
helpviewer_keywords: 
  - "IMetaDataImport::CloseEnum method [.NET Framework metadata]"
  - "CloseEnum method, IMetaDataImport interface [.NET Framework metadata]"
ms.assetid: 727819d5-1dab-4ebb-ac25-950b4111dc72
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::CloseEnum Method
Closes the enumerator that is identified by the specified handle.  
  
## Syntax  
  
```cpp  
void CloseEnum (  
   [in] HCORENUM hEnum  
);  
```  
  
## Parameters  
 `hEnum`  
 [in] The handle for the enumerator to close.  
  
## Remarks  
 The handle specified by `hEnum` is obtained from a previous `Enum`*Name* call (for example, [IMetaDataImport::EnumTypeDefs](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-enumtypedefs-method.md)).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
