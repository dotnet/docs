---
title: "IMetaDataImport::IsValidToken Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.IsValidToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::IsValidToken"
helpviewer_keywords: 
  - "IMetaDataImport::IsValidToken method [.NET Framework metadata]"
  - "IsValidToken method [.NET Framework metadata]"
ms.assetid: aeb0fc63-9eff-4384-9284-cb9900572d74
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::IsValidToken Method
Gets a value indicating whether the specified token holds a valid reference to a code object.  
  
## Syntax  
  
```  
BOOL IsValidToken (  
   [in] mdToken     tk  
);  
```  
  
#### Parameters  
 `tk`  
 [in] The token to check the reference validity for.  
  
## Return Value  
 `true` if `tk` is a valid metadata token within the current scope. Otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
