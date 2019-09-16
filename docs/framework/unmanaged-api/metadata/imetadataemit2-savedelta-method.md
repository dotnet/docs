---
title: "IMetaDataEmit2::SaveDelta Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit2.SaveDelta"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::SaveDelta"
helpviewer_keywords: 
  - "IMetaDataEmit2::SaveDelta method [.NET Framework metadata]"
  - "SaveDelta method [.NET Framework metadata]"
ms.assetid: b95739fe-d2fa-4776-ae0d-31d9707ef799
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit2::SaveDelta Method
Saves changes from the current edit-and-continue session to the specified file.  
  
## Syntax  
  
```cpp  
HRESULT SaveDelta (  
    [in] LPCWSTR     szFile,   
    [in] DWORD       dwSaveFlags  
);  
```  
  
## Parameters  
 `szFile`  
 [in] The file name under which to save changes.  
  
 `dwSaveFlags`  
 [in] Reserved. Must be zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
