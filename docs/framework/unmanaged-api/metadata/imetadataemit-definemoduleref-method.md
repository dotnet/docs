---
title: "IMetaDataEmit::DefineModuleRef Method"
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
  - "IMetaDataEmit.DefineModuleRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineModuleRef"
helpviewer_keywords: 
  - "DefineModuleRef method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineModuleRef method [.NET Framework metadata]"
ms.assetid: f2833594-d90b-4a71-9a53-34b12470c64a
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineModuleRef Method
Creates the metadata signature for a module with the specified name.  
  
## Syntax  
  
```  
HRESULT DefineModuleRef (     
    [in]  LPCWSTR           szName,   
    [out] mdModuleRef       *pmur   
);  
```  
  
#### Parameters  
 `szName`  
 [in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.  
  
 `pmur`  
 [out] The assigned `mdModuleRef` token.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
