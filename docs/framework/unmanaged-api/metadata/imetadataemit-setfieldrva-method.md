---
title: "IMetaDataEmit::SetFieldRVA Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetFieldRVA"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetFieldRVA"
helpviewer_keywords: 
  - "IMetaDataEmit::SetFieldRVA method [.NET Framework metadata]"
  - "SetFieldRVA method [.NET Framework metadata]"
ms.assetid: 6dc37f9d-87ee-4cb3-9216-ced600184ce8
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::SetFieldRVA Method
Sets a global variable value for the relative virtual address of the field referenced by the specified token.  
  
## Syntax  
  
```  
HRESULT SetFieldRVA (   
    [in]  mdFieldDef  fd,   
    [in]  ULONG       ulRVA   
);  
```  
  
## Parameters  
 `fd`  
 [in] The token for the target field.  
  
 `ulRVA`  
 [in] The address of a code or data area.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
