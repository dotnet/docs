---
title: "IMetaDataTables::GetGuidHeapSize Method"
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
  - "IMetaDataTables.GetGuidHeapSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetGuidHeapSize"
helpviewer_keywords: 
  - "GetGuidHeapSize method [.NET Framework metadata]"
  - "IMetaDataTables::GetGuidHeapSize method [.NET Framework metadata]"
ms.assetid: e875cbee-1ad9-4f1a-bf03-38cdb8ff371a
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetGuidHeapSize Method
Gets the size, in bytes, of the GUID heap.  
  
## Syntax  
  
```  
HRESULT GetGuidHeapSize (  
    [out] ULONG   *pcbGuids  
);  
```  
  
#### Parameters  
 `pcbGuids`  
 [out] A pointer to the size, in bytes, of the GUID heap.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
