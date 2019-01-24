---
title: "IMetaDataTables::GetNumTables Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetNumTables"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetNumTables"
helpviewer_keywords: 
  - "GetNumTables method [.NET Framework metadata]"
  - "IMetaDataTables::GetNumTables method [.NET Framework metadata]"
ms.assetid: 8196f2a3-bbf2-45d3-a6cd-74502c356644
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataTables::GetNumTables Method
Gets the number of tables in the scope of the current `IMetaDataTables` instance.  
  
## Syntax  
  
```  
HRESULT GetNumTables (  
    [out]  ULONG   *pcTables  
);  
```  
  
#### Parameters  
 `pcTables`  
 [out] A pointer to the number of tables in the current instance scope.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
