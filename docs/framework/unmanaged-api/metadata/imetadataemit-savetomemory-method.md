---
title: "IMetaDataEmit::SaveToMemory Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SaveToMemory"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SaveToMemory"
helpviewer_keywords: 
  - "IMetaDataEmit::SaveToMemory method [.NET Framework metadata]"
  - "SaveToMemory method [.NET Framework metadata]"
ms.assetid: d5237628-2675-45ed-a39e-65c0731b6a56
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SaveToMemory Method
Saves all metadata in the current scope to the specified area of memory.  
  
## Syntax  
  
```cpp  
HRESULT SaveToMemory (   
    [out]  void        *pbData,   
    [in]   ULONG       cbData   
);  
```  
  
## Parameters  
 `pbData`  
 [out] The address at which to begin writing metadata.  
  
 `cbData`  
 [in] The size, in bytes, of the allocated memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
