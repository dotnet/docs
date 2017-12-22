---
title: "IMetaDataTables::GetCodedTokenInfo Method"
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
  - "IMetaDataTables.GetCodedTokenInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetCodedTokenInfo"
helpviewer_keywords: 
  - "GetCodedTokenInfo method [.NET Framework metadata]"
  - "IMetaDataTables::GetCodedTokenInfo method [.NET Framework metadata]"
ms.assetid: 31214d3a-715e-49af-92b3-0fd11e4f218a
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables::GetCodedTokenInfo Method
Gets a pointer to an array of tokens associated with the specified row index.  
  
## Syntax  
  
```  
HRESULT GetCodedTokenInfo (   
    [in]  ULONG       ixCdTkn,  
    [out] ULONG       *pcTokens,  
    [out] ULONG       **ppTokens,  
    [out] const char  **ppName  
);  
```  
  
#### Parameters  
 `ixCdTkn`  
 [in] The kind of coded token to return.  
  
 `pcTokens`  
 [out] A pointer to the length of `ppTokens`.  
  
 `ppTokens`  
 [out] A pointer to a pointer to an array that contains the list of returned tokens.  
  
 `ppName`  
 [out] A pointer to a pointer to the name of the token at `ixCdTkn`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
