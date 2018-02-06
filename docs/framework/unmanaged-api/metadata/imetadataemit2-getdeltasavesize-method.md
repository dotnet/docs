---
title: "IMetaDataEmit2::GetDeltaSaveSize Method"
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
  - "IMetaDataEmit2.GetDeltaSaveSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::GetDeltaSaveSize"
helpviewer_keywords: 
  - "IMetaDataEmit2::GetDeltaSaveSize method [.NET Framework metadata]"
  - "GetDeltaSaveSize method [.NET Framework metadata]"
ms.assetid: 036db5e7-8211-4645-9a34-03d1a89be955
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit2::GetDeltaSaveSize Method
Gets a value indicating any change in metadata size that results from the current edit-and-continue session.  
  
## Syntax  
  
```  
HRESULT GetDeltaSaveSize (  
    [in]  CorSaveSize  fSave,  
    [out] DWORD        *pdwSaveSize  
);  
```  
  
#### Parameters  
 `fSave`  
 [in] One of the [CorSaveSize](../../../../docs/framework/unmanaged-api/metadata/corsavesize-enumeration.md) values, indicating the level of precision desired. For the .NET Framework version 2.0, this parameter is ignored.  
  
 `pdwSaveSize`  
 [out] The change in the size of the metadata.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
