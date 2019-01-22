---
title: "IMetaDataEmit::DeletePinvokeMap Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DeletePinvokeMap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DeletePinvokeMap"
helpviewer_keywords: 
  - "IMetaDataEmit::DeletePinvokeMap method [.NET Framework metadata]"
  - "DeletePinvokeMap method [.NET Framework metadata]"
ms.assetid: 3c4f6b54-5ce7-4a2a-83e1-6dec16441f50
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::DeletePinvokeMap Method
Destroys the PInvoke mapping metadata for the object referenced by the specified token.  
  
## Syntax  
  
```  
HRESULT DeletePinvokeMap (   
    [in]  mdToken     tk   
);  
```  
  
#### Parameters  
 `tk`  
 [in] An `mdFieldDef` or `mdMethodDef` token that represents the object for which to delete the PInvoke mapping metadata.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
