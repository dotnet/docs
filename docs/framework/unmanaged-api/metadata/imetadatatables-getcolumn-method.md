---
title: "IMetaDataTables::GetColumn Method"
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
  - "IMetaDataTables.GetColumn"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetColumn"
helpviewer_keywords: 
  - "IMetaDataTables::GetColumn method [.NET Framework metadata]"
  - "GetColumn method [.NET Framework metadata]"
ms.assetid: 1032055b-cabb-45c5-a50e-7e853201b175
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetColumn Method
Gets a pointer to the value contained in the cell of the specified column and row in the given table.  
  
## Syntax  
  
```  
HRESULT GetColumn (   
    [in]  ULONG   ixTbl,  
    [in]  ULONG   ixCol,  
    [in]  ULONG   rid,  
    [out] ULONG   *pVal  
);  
```  
  
#### Parameters  
 `ixTbl`  
 [in] The index of the table.  
  
 `ixCol`  
 [in] The index of the column in the table.  
  
 `rid`  
 [in] The index of the row in the table.  
  
 `pVal`  
 [out] A pointer to the value in the cell.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
