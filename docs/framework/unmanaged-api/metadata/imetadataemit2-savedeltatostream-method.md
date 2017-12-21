---
title: "IMetaDataEmit2::SaveDeltaToStream Method"
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
  - "IMetaDataEmit2.SaveDeltaToStream"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::SaveDeltaToStream"
helpviewer_keywords: 
  - "IMetaDataEmit2::SaveDeltaToStream method [.NET Framework metadata]"
  - "SaveDeltaToStream method [.NET Framework metadata]"
ms.assetid: ecd786e8-f9a4-4190-a6ef-af18e8c6d654
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit2::SaveDeltaToStream Method
Saves changes from the current edit-and-continue session to the specified stream.  
  
## Syntax  
  
```  
HRESULT SaveDeltaToStream (  
    [in] IStream     *pIStream,   
    [in] DWORD       dwSaveFlags  
);  
```  
  
#### Parameters  
 `pIStream`  
 [in] An interface pointer to the writable stream to which to save changes.  
  
 `dwSaveFlags`  
 [in] Reserved. This value must be zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
