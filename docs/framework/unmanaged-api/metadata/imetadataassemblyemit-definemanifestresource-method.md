---
title: "IMetaDataAssemblyEmit::DefineManifestResource Method"
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
  - "IMetaDataAssemblyEmit.DefineManifestResource"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::DefineManifestResource"
helpviewer_keywords: 
  - "DefineManifestResource method [.NET Framework metadata]"
  - "IMetaDataAssemblyEmit::DefineManifestResource method [.NET Framework metadata]"
ms.assetid: 27f6d295-0fe9-4cda-b77e-6e7d5c53df09
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::DefineManifestResource Method
Creates a `ManifestResource` structure containing metadata for the specified manifest resource, and returns the associated metadata token.  
  
## Syntax  
  
```  
HRESULT DefineManifestResource (  
    [in] LPCWSTR                szName,   
    [in] mdToken                tkImplementation,   
    [in] DWORD                  dwOffset,   
    [in] DWORD                  dwResourceFlags,  
    [out] mdManifestResource    *pmdmr  
);  
```  
  
#### Parameters  
 `szName`  
 [in] The name of the resource.  
  
 `tkImplementation`  
 [in] A metadata token of type `mdtFile` or `mdtAssemblyRef` that maps to the resource provider. A NULL value indicates that the file in which the metadata is embedded is the resource provider.  
  
 `dwOffset`  
 [in] The offset to the beginning of the resource within the file. For resources in standalone files, this will always be zero. If the resource is embedded in a PE (portable executable) file, this is an offset of the resource BLOB, which starts at the location specified in the cor.h header file.  
  
 `dwResourceFlags`  
 [in] A bitwise combination of flag values that specify property settings for the resource definition.  
  
 `pmdmr`  
 [out] A pointer to the returned metadata token.  
  
## Remarks  
 One `ManifestResource` metadata structure must be defined for each resource that is implemented in each of the assembly's files.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
