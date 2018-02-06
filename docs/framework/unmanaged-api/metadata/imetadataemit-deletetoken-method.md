---
title: "IMetaDataEmit::DeleteToken Method"
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
  - "IMetaDataEmit.DeleteToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DeleteToken"
helpviewer_keywords: 
  - "DeleteToken method [.NET Framework metadata]"
  - "IMetaDataEmit::DeleteToken method [.NET Framework metadata]"
ms.assetid: a4926d0a-261b-46b1-9994-82633661a64b
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DeleteToken Method
Deletes the specified token from the current metadata scope.  
  
## Syntax  
  
```  
HRESULT DeleteToken (   
    [in]  mdToken     tkObj   
);  
```  
  
#### Parameters  
 `tkObj`  
 [in] The token to be deleted.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
