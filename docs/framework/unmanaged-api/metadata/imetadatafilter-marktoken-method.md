---
title: "IMetaDataFilter::MarkToken Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataFilter.MarkToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataFilter::MarkToken"
helpviewer_keywords: 
  - "IMetaDataFilter::MarkToken method [.NET Framework metadata]"
  - "MarkToken method, IMetaDataFilter interface [.NET Framework metadata]"
ms.assetid: bd492834-6529-4d39-b93d-f8cdbd3e297f
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataFilter::MarkToken Method
Sets a value indicating that the specified metadata token has been processed.  
  
## Syntax  
  
```  
HRESULT MarkToken (  
    [in] mdToken   tk  
);  
```  
  
#### Parameters  
 `tk`  
 [in] The token to mark as processed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataFilter Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-interface.md)
