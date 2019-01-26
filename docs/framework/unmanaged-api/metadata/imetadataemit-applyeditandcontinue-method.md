---
title: "IMetaDataEmit::ApplyEditAndContinue Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.ApplyEditAndContinue"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::ApplyEditAndContinue"
helpviewer_keywords: 
  - "ApplyEditAndContinue method [.NET Framework metadata]"
  - "IMetaDataEmit::ApplyEditAndContinue method [.NET Framework metadata]"
ms.assetid: 35991289-f389-495d-8caa-a6384fb1d557
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::ApplyEditAndContinue Method
Updates the current assembly scope with the changes made in the specified metadata.  
  
## Syntax  
  
```  
HRESULT ApplyEditAndContinue (   
    [in]  IUnknown    *pImport  
);  
```  
  
#### Parameters  
 `pImport`  
 \[in\] Pointer to an [IUnknown](/cpp/atl/iunknown) object that represents the delta metadata from the portable executable (PE) file.
  
 The delta metadata is the block of metadata that includes the changes that were made to the copy of the module's actual metadata.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
