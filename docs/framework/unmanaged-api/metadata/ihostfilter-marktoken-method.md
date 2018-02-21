---
title: "IHostFilter::MarkToken Method"
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
  - "IHostFilter.MarkToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostFilter::MarkToken"
helpviewer_keywords: 
  - "MarkToken method, IHostFilter interface [.NET Framework metadata]"
  - "IHostFilter::MarkToken method [.NET Framework metadata]"
ms.assetid: d7061343-d0a3-4fd5-b312-61974f98bd62
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostFilter::MarkToken Method
Indicates that the specified metadata token will be processed.  
  
## Syntax  
  
```  
HRESULT MarkToken (  
    [in]  mdToken         tk  
);  
```  
  
#### Parameters  
 `tk`  
 [in] The metadata token to be processed.  
  
## Remarks  
 Typically, you want a token to be processed if it is in the metadata scope. The `MarkToken` method is passed to the metadata engine via the [IMetaDataEmit::SetHandler](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-sethandler-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)  
 [IHostFilter Interface](../../../../docs/framework/unmanaged-api/metadata/ihostfilter-interface.md)
