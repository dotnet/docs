---
title: "IMetaDataEmit::SetRVA Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetRVA"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetRVA"
helpviewer_keywords: 
  - "IMetaDataEmit::SetRVA method [.NET Framework metadata]"
  - "SetRVA method [.NET Framework metadata]"
ms.assetid: 4d69fb6d-ee35-4318-8224-5eea2bd16818
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::SetRVA Method
Sets the relative virtual address of the specified method.  
  
## Syntax  
  
```  
HRESULT SetRVA (  
    [in]  mdMethodDef  md,   
    [in]  ULONG        ulRVA   
);  
```  
  
## Parameters  
 `md`  
 [in] The token for the target method or method implementation.  
  
 `ulRVA`  
 [in] The address of the code or data area.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
