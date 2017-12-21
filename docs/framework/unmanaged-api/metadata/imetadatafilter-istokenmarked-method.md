---
title: "IMetaDataFilter::IsTokenMarked Method"
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
  - "IMetaDataFilter.IsTokenMarked"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataFilter::IsTokenMarked"
helpviewer_keywords: 
  - "IMetaDataFilter::IsTokenMarked method [.NET Framework metadata]"
  - "IsTokenMarked method [.NET Framework metadata]"
ms.assetid: 7d90dcee-0206-4540-807b-06982fe65f1a
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataFilter::IsTokenMarked Method
Gets a value indicating whether the specified metadata token has been marked as processed.  
  
## Syntax  
  
```  
HRESULT IsTokenMarked (  
    [in]  mdToken  tk,   
    [out] BOOL     *pIsMarked  
);  
```  
  
#### Parameters  
 `tk`  
 [in] The token to examine for a processing mark.  
  
 `pIsMarked`  
 [out] A value that is `true` if `tk` has been processed; otherwise `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataFilter Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-interface.md)
