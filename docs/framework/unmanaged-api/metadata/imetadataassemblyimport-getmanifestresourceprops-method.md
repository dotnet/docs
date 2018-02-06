---
title: "IMetaDataAssemblyImport::GetManifestResourceProps Method"
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
  - "IMetaDataAssemblyImport.GetManifestResourceProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::GetManifestResourceProps"
helpviewer_keywords: 
  - "GetManifestResourceProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::GetManifestResourceProps method [.NET Framework metadata]"
ms.assetid: 00be4789-ac63-4397-b2ec-1629a5c5a585
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::GetManifestResourceProps Method
Gets the set of properties of the manifest resource with the specified metadata signature.  
  
## Syntax  
  
```  
HRESULT GetManifestResourceProps (  
    [in]  mdManifestResource   mdmr,   
    [out] LPWSTR               szName,   
    [in]  ULONG                cchName,   
    [out] ULONG                *pchName,   
    [out] mdToken              *ptkImplementation,   
    [out] DWORD                *pdwOffset,   
    [out] DWORD                *pdwResourceFlags  
);  
```  
  
#### Parameters  
 `mdmr`  
 [in] An `mdManifestResource` token that represents the resource for which to get the properties.  
  
 `szName`  
 [out] The name of the resource.  
  
 `cchName`  
 [in] The size, in wide chars, of `szName`.  
  
 `pchName`  
 [out] A pointer to the number of wide chars actually returned in `szName`.  
  
 `ptkImplementation`  
 [out] A pointer to an `mdFile` token or an `mdAssemblyRef` token that represents the file or assembly, respectively, that contains the resource.  
  
 `pdwOffset`  
 [out] A pointer to a value that specifies the offset to the beginning of the resource within the file.  
  
 `pdwResourceFlags`  
 [out] A pointer to flags that describe the metadata applied to a resource. The flags value is a combination of one or more [CorManifestResourceFlags](../../../../docs/framework/unmanaged-api/metadata/cormanifestresourceflags-enumeration.md) values.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
