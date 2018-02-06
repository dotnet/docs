---
title: "IMetaDataAssemblyImport::FindManifestResourceByName Method"
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
  - "IMetaDataAssemblyImport.FindManifestResourceByName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::FindManifestResourceByName"
helpviewer_keywords: 
  - "FindManifestResourceByName method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::FindManifestResourceByName method [.NET Framework metadata]"
ms.assetid: 7b72fa11-3866-402b-bdea-2b966b77cfe0
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::FindManifestResourceByName Method
Gets a pointer to the manifest resource with the specified name.  
  
## Syntax  
  
```  
HRESULT FindManifestResourceByName (  
    [in]  LPCWSTR                szName,   
    [out] mdManifestResource     *ptkManifestResource  
);   
```  
  
#### Parameters  
 `szName`  
 [in] The name of the resource.  
  
 `ptkManifestResource`  
 [out] The array used to store the `mdManifestResource` metadata tokens, each of which represents a manifest resource.  
  
## Remarks  
 The `FindManifestResourceByName` method uses the standard rules employed by the common language runtime for resolving references.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)  
 [How the Runtime Locates Assemblies](../../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)
