---
title: "IMetaDataTables::GetBlob Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "IMetaDataTables.GetBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetBlob"
helpviewer_keywords: 
  - "GetBlob method [.NET Framework metadata]"
  - "IMetaDataTables::GetBlob method [.NET Framework metadata]"
ms.assetid: 94667c1c-6d58-4aa7-b74e-530b11e2a276
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetBlob Method
Gets a pointer to the binary large object (BLOB) at the specified column index.  
  
## Syntax  
  
```  
HRESULT GetBlob (  
    [in]  ULONG          ixBlob,  
    [out] ULONG          *pcbData,  
    [out] const void     **ppData  
);  
```  
  
#### Parameters  
 `ixBlob`  
 [in] The memory address from which to get `ppData`.  
  
 `pcbData`  
 [out] A pointer to the size, in bytes, of `ppData`.  
  
 `ppData`  
 [out] A pointer to a pointer to the binary data retrieved.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
