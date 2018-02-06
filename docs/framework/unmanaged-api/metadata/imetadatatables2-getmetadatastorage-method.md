---
title: "IMetaDataTables2::GetMetaDataStorage Method"
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
  - "IMetaDataTables2.GetMetaDataStorage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables2::GetMetaDataStorage"
helpviewer_keywords: 
  - "GetMetaDataStorage method [.NET Framework metadata]"
  - "IMetaDataTables2::GetMetaDataStorage method [.NET Framework metadata]"
ms.assetid: 667a6d1e-753d-4ea2-8fd8-a8337d1bb9cd
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables2::GetMetaDataStorage Method
Gets the size and contents of the metadata stored in the specified section.  
  
## Syntax  
  
```  
HRESULT GetMetaDataStorage (  
   [in, out] const void   **ppvMd,  
   [out] ULONG   *pcbMd  
);  
```  
  
#### Parameters  
 `ppvMd`  
 [in, out] A pointer to a metadata section.  
  
 `pcbMd`  
 [out] The size of the metadata stream.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
