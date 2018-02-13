---
title: "IMetaDataImport::GetTypeRefProps Method"
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
  - "IMetaDataImport.GetTypeRefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetTypeRefProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetTypeRefProps method [.NET Framework metadata]"
  - "GetTypeRefProps method [.NET Framework metadata]"
ms.assetid: 01837955-ce1e-4068-b338-fd473bd77d1d
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetTypeRefProps Method
Gets the metadata associated with the <xref:System.Type> referenced by the specified TypeRef token.  
  
## Syntax  
  
```  
HRESULT GetTypeRefProps (  
   [in]  mdTypeRef   tr,  
   [out] mdToken     *ptkResolutionScope,  
   [out] LPWSTR      szName,  
   [in]  ULONG       cchName,  
   [out] ULONG       *pchName  
);  
```  
  
#### Parameters  
 `tr`  
 [in] The TypeRef token that represents the type to return metadata for.  
  
 `ptkResolutionScope`  
 [out] A pointer to the scope in which the reference is made. This value is an AssemblyRef or ModuleRef token.  
  
 `szName`  
 [out] A buffer containing the type name.  
  
 `cchName`  
 [in] The requested size in wide characters of `szName`.  
  
 `pchName`  
 [out] The returned size in wide characters of `szName`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
