---
title: "IMetaDataError::OnError Method"
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
  - "IMetaDataError.OnError"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataError::OnError"
helpviewer_keywords: 
  - "IMetaDataError::OnError method [.NET Framework metadata]"
  - "OnError method, IMetaDataError interface [.NET Framework metadata]"
ms.assetid: c1e744b8-a6fb-4d9c-a971-8babc875d8f0
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataError::OnError Method
Provides notification of errors that occur during the metadata merge.  
  
## Syntax  
  
```  
HRESULT OnError (  
    [in] HRESULT   hrError,   
    [in] mdToken   token  
);  
```  
  
#### Parameters  
 `hrError`  
 [in] The HRESULT error value returned to the calling method.  
  
 `token`  
 [in] The metadata token of the code object that was being merged when the error occurred.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataError Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataerror-interface.md)
