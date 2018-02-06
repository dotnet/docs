---
title: "IMetaDataTables::GetBlobHeapSize Method"
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
  - "IMetaDataTables.GetBlobHeapSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetBlobHeapSize"
helpviewer_keywords: 
  - "GetBlobHeapSize method [.NET Framework metadata]"
  - "IMetaDataTables::GetBlobHeapSize method [.NET Framework metadata]"
ms.assetid: 6330a9ee-8cd5-4299-86f1-b4de2c701a0d
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetBlobHeapSize Method
Gets the size, in bytes, of the binary large object (BLOB) heap.  
  
## Syntax  
  
```  
HRESULT GetBlobHeapSize (  
    [out] ULONG     *pcbBlobs  
);   
```  
  
#### Parameters  
 `pcbBlobs`  
 [out] A pointer to the size, in bytes, of the BLOB heap.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
