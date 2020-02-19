---
title: "IMetaDataEmit::Save Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.Save"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::Save"
helpviewer_keywords: 
  - "Save method, IMetaDataEmit interface [.NET Framework metadata]"
  - "IMetaDataEmit::Save method [.NET Framework metadata]"
ms.assetid: c1de8400-adfe-4a71-b828-a1d0cc1ea505
topic_type: 
  - "apiref"
---
# IMetaDataEmit::Save Method
Saves all metadata in the current scope to the file at the specified address.  
  
## Syntax  
  
```cpp  
HRESULT Save (   
    [in]  LPCWSTR     szFile,   
    [in]  DWORD       dwSaveFlags  
);  
```  
  
## Parameters  
 `wzFile`  
 [in] The name of the file to save to. If this value is null, the in-memory copy will be saved to the last location that was used.  
  
 `dwSaveFlags`  
 [in] Reserved. Must be zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
