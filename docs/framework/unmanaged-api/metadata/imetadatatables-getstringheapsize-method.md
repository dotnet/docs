---
title: "IMetaDataTables::GetStringHeapSize Method"
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
  - "IMetaDataTables.GetStringHeapSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetStringHeapSize"
helpviewer_keywords: 
  - "IMetaDataTables::GetStringHeapSize method [.NET Framework metadata]"
  - "GetStringHeapSize method [.NET Framework metadata]"
ms.assetid: ed8f6335-81f5-4c09-81a9-2a909fc530c9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetStringHeapSize Method
Gets the size, in bytes, of the string heap.  
  
## Syntax  
  
```  
HRESULT GetStringHeapSize (  
    [out] ULONG   *pcbStrings  
);  
```  
  
#### Parameters  
 `pcbStrings`  
 [out] A pointer to the size, in bytes, of the string heap.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
