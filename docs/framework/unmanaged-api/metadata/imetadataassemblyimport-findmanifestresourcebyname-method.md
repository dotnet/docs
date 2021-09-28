---
description: "Learn more about: IMetaDataAssemblyImport::FindManifestResourceByName Method"
title: "IMetaDataAssemblyImport::FindManifestResourceByName Method"
ms.date: "03/30/2017"
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
---
# IMetaDataAssemblyImport::FindManifestResourceByName Method

Gets a pointer to the manifest resource with the specified name.  
  
## Syntax  
  
```cpp
HRESULT FindManifestResourceByName (  
    [in]  LPCWSTR                szName,
    [out] mdManifestResource     *ptkManifestResource  
);
```  
  
## Parameters  

 `szName`  
 [in] The name of the resource.  
  
 `ptkManifestResource`  
 [out] The array used to store the `mdManifestResource` metadata tokens, each of which represents a manifest resource.  
  
## Remarks  

 The `FindManifestResourceByName` method uses the standard rules employed by the common language runtime for resolving references.  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
- [How the Runtime Locates Assemblies](../../deployment/how-the-runtime-locates-assemblies.md)
