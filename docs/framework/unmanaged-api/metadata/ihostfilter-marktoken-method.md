---
description: "Learn more about: IHostFilter::MarkToken Method"
title: "IHostFilter::MarkToken Method"
ms.date: "03/30/2017"
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
---
# IHostFilter::MarkToken Method

Indicates that the specified metadata token will be processed.  
  
## Syntax  
  
```cpp  
HRESULT MarkToken (  
    [in]  mdToken         tk  
);  
```  
  
## Parameters  

 `tk`  
 [in] The metadata token to be processed.  
  
## Remarks  

 Typically, you want a token to be processed if it is in the metadata scope. The `MarkToken` method is passed to the metadata engine via the [IMetaDataEmit::SetHandler](imetadataemit-sethandler-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IHostFilter Interface](ihostfilter-interface.md)
