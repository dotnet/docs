---
title: "IMetaDataTables2::GetMetaDataStreamInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables2.GetMetaDataStreamInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables2::GetMetaDataStreamInfo"
helpviewer_keywords: 
  - "GetMetaDataStreamInfo method [.NET Framework metadata]"
  - "IMetaDataTables2::GetMetaDataStreamInfo method [.NET Framework metadata]"
ms.assetid: 8b280627-cc74-4789-95da-1fefc966de05
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataTables2::GetMetaDataStreamInfo Method
Gets the name, size, and contents of the metadata stream at the specified index.  
  
## Syntax  
  
```  
HRESULT GetMetaDataStreamInfo (  
   [in]  ULONG        ix,  
   [out] const char   **ppchName,  
   [out] const void   **ppv,  
   [out] ULONG        *pcb  
);  
```  
  
#### Parameters  
 `ix`  
 [in] The index of the requested metadata stream.  
  
 `ppchName`  
 [out] A pointer to the name of the stream.  
  
 `ppv`  
 [out] A pointer to the metadata stream.  
  
 `pcb`  
 [out] The size, in bytes, of `ppv`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
