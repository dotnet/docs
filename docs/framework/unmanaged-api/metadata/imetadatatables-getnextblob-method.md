---
title: "IMetaDataTables::GetNextBlob Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetNextBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetNextBlob"
helpviewer_keywords: 
  - "IMetaDataTables::GetNextBlob method [.NET Framework metadata]"
  - "GetNextBlob method [.NET Framework metadata]"
ms.assetid: 017c8ab4-4c09-4754-9935-5b0b49cabecb
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataTables::GetNextBlob Method
Gets the index of the next binary large object (BLOB) in the table.  
  
## Syntax  
  
```  
HRESULT GetNextBlob (  
    [in]  ULONG   ixBlob,  
    [out] ULONG   *pNext  
);  
```  
  
## Parameters  
 `ixBlob`  
 [in] The index, as returned from a column of BLOBs.  
  
 `pNext`  
 [out] A pointer to the index of the next BLOB.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
