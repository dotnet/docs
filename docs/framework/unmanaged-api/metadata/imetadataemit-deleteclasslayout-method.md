---
title: "IMetaDataEmit::DeleteClassLayout Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DeleteClassLayout"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DeleteClassLayout"
helpviewer_keywords: 
  - "DeleteClassLayout method [.NET Framework metadata]"
  - "IMetaDataEmit::DeleteClassLayout method [.NET Framework metadata]"
ms.assetid: 65a4ad49-fa49-4b36-8ed1-76dd6a185ab4
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DeleteClassLayout Method
Destroys the class layout metadata signature for the type represented by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT DeleteClassLayout (  
    [in]  mdTypeDef   td  
);  
```  
  
## Parameters  
 `td`  
 [in] An `mdTypeDef` metadata token that represents the type for which the class layout will be deleted.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
