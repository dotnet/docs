---
title: "IMetaDataEmit::Merge Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.Merge"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::Merge"
helpviewer_keywords: 
  - "IMetaDataEmit::Merge method [.NET Framework metadata]"
  - "Merge method [.NET Framework metadata]"
ms.assetid: 7596220c-f699-4b6c-8ae7-c83220610650
topic_type: 
  - "apiref"
---
# IMetaDataEmit::Merge Method
Adds the specified imported scope to the list of scopes to be merged.  
  
## Syntax  
  
```cpp  
HRESULT Merge (   
    [in]  IMetaDataImport  *pImport,   
    [in]  IMapToken        *pHostMapToken,   
    [in]  IUnknown         *pHandler   
);  
```  
  
## Parameters  
 `pImport`  
 [in] A pointer to an [IMetaDataImport](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md) object that identifies the imported scope to be merged.  
  
 `pIMap`  
 [in] A pointer to an [IMapToken](../../../../docs/framework/unmanaged-api/metadata/imaptoken-interface.md) object that specifies the token re-map.  
  
 `pHandler`  
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) object that specifies the errors.  
  
## Remarks  
 Call [IMetaDataEmit::MergeEnd](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-mergeend-method.md) to trigger the merger of metadata into a single scope.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
