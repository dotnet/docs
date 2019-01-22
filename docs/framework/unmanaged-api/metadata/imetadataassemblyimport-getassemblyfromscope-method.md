---
title: "IMetaDataAssemblyImport::GetAssemblyFromScope Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyImport.GetAssemblyFromScope"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::GetAssemblyFromScope"
helpviewer_keywords: 
  - "IMetaDataAssemblyImport::GetAssemblyFromScope method [.NET Framework metadata]"
  - "GetAssemblyFromScope method [.NET Framework metadata]"
ms.assetid: 0b437f70-561d-48c7-abe0-0cb9ace10c08
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataAssemblyImport::GetAssemblyFromScope Method
Gets a pointer to the assembly in the current scope.  
  
## Syntax  
  
```  
HRESULT GetAssemblyFromScope (  
    [out] mdAssembly  *ptkAssembly  
);  
```  
  
#### Parameters  
 `ptkAssembly`  
 [out] A pointer to the retrieved `mdAssembly` token that identifies the assembly.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
