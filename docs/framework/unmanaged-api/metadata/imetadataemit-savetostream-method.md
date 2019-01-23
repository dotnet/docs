---
title: "IMetaDataEmit::SaveToStream Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SaveToStream"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SaveToStream"
helpviewer_keywords: 
  - "IMetaDataEmit::SaveToStream method [.NET Framework metadata]"
  - "SaveToStream method [.NET Framework metadata]"
ms.assetid: e0290a49-3818-4a43-ad46-3014faa34f97
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::SaveToStream Method
Saves all metadata in the current scope to the specified `IStream`.  
  
## Syntax  
  
```  
HRESULT SaveToStream (   
    [in]  IStream     *pIStream,  
    [in]  DWORD       dwSaveFlags  
);  
```  
  
#### Parameters  
 `pIStream`  
 [in] The writable stream to save to.  
  
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
