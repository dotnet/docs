---
title: "IMetaDataImport::GetModuleRefProps Method"
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
  - "IMetaDataImport.GetModuleRefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetModuleRefProps"
helpviewer_keywords: 
  - "GetModuleRefProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetModuleRefProps method [.NET Framework metadata]"
ms.assetid: b558e766-4c11-4628-ae47-b4e0a1800168
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetModuleRefProps Method
Gets the name of the module referenced by the specified metadata token.  
  
## Syntax  
  
```  
HRESULT GetModuleRefProps (  
   [in]  mdModuleRef         mur,  
   [out] LPWSTR              szName,   
   [in]  ULONG               cchName,   
   [out] ULONG               *pchName   
);  
```  
  
#### Parameters  
 `mur`  
 [in] The ModuleRef metadata token that references the module to get metadata information for.  
  
 `szName`  
 [out] A buffer to hold the module name.  
  
 `cchName`  
 [in] The requested size of `szName` in wide characters.  
  
 `pchName`  
 [out] The returned size of `szName` in wide characters.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
