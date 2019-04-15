---
title: "IMetaDataEmit::DeleteFieldMarshal Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DeleteFieldMarshal"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DeleteFieldMarshal"
helpviewer_keywords: 
  - "IMetaDataEmit::DeleteFieldMarshal method [.NET Framework metadata]"
  - "DeleteFieldMarshal method [.NET Framework metadata]"
ms.assetid: 7c75aef9-c742-4b33-a14b-56ff94b0f725
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::DeleteFieldMarshal Method
Destroys the PInvoke marshaling metadata signature for the object referenced by the specified token.  
  
## Syntax  
  
```  
HRESULT DeleteFieldMarshal (  
    [in]  mdToken     tk  
);  
```  
  
## Parameters  
 `tk`  
 [in] An `mdFieldDef` or `mdParamDef` token that represents the field or parameter for which to delete the marshaling metadata signature.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
