---
title: "IMetaDataTables::GetColumnInfo Method"
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
  - "IMetaDataTables.GetColumnInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetColumnInfo"
helpviewer_keywords: 
  - "IMetaDataTables::GetColumnInfo method [.NET Framework metadata]"
  - "GetColumnInfo method [.NET Framework metadata]"
ms.assetid: 68c160ea-ae7d-4750-985d-a038b2c8e7d9
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetColumnInfo Method
Gets data about the specified column in the specified table.  
  
## Syntax  
  
```  
HRESULT GetColumnInfo (   
    [in]  ULONG        ixTbl,  
    [in]  ULONG        ixCol,  
    [out] ULONG        *poCol,  
    [out] ULONG        *pcbCol,  
    [out] ULONG        *pType,  
    [out] const char   **ppName  
);  
```  
  
#### Parameters  
 `ixTbl`  
 [in] The index of the desired table.  
  
 `ixCol`  
 [in] The index of the desired column.  
  
 `poCol`  
 [out] A pointer to the offset of the column in the row.  
  
 `pcbCol`  
 [out] A pointer to the size, in bytes, of the column.  
  
 `pType`  
 [out] A pointer to the type of the values in the column.  
  
 `ppName`  
 [out] A pointer to a pointer to the column name.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
