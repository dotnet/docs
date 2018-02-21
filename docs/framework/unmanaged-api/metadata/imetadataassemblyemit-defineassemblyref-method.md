---
title: "IMetaDataAssemblyEmit::DefineAssemblyRef Method"
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
  - "IMetaDataAssemblyEmit.DefineAssemblyRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::DefineAssemblyRef"
helpviewer_keywords: 
  - "DefineAssemblyRef method [.NET Framework metadata]"
  - "IMetaDataAssemblyEmit::DefineAssemblyRef method [.NET Framework metadata]"
ms.assetid: 0b284b18-0084-4b3a-912a-5ebe9f29c88b
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::DefineAssemblyRef Method
Creates an `AssemblyRef` structure containing metadata for the assembly that this assembly references, and returns the associated metadata token.  
  
## Syntax  
  
```  
HRESULT DefineAssemblyRef (  
    [in]  void                *pbPublicKeyOrToken,  
    [in]  ULONG               cbPublicKeyOrToken,  
    [in]  LPCWSTR             szName,  
    [in]  ASSEMBLYMETADATA    pMetaData,  
    [in]  void                *pbHashValue,  
    [in]  ULONG               cbHashValue,  
    [in]  DWORD               dwAssemblyRefFlags,  
    [out] mdAssemblyRef       *pmdar  
);  
```  
  
#### Parameters  
 `pbPublicKeyOrToken`  
 [in] The public key of the publisher of the referenced assembly. The helper function [StrongNameTokenFromAssembly](../../../../docs/framework/unmanaged-api/strong-naming/strongnametokenfromassembly-function.md) can be used to get the hash of the public key to pass as this parameter.  
  
 `cbPublicKeyOrToken`  
 [in] The size in bytes of `pbPublicKeyOrToken`.  
  
 `szName`  
 [in] The human-readable text name of the assembly. This value must not exceed 1024 characters.  
  
 `pMetaData`  
 [in] An ASSEMBLYMETADATA instance that contains the version, platform and locale information of the referenced assembly.  
  
 `pbHashValue`  
 [in] The hash data associated with the referenced assembly. Optional.  
  
 `cbHashValue`  
 [in] The size in bytes of `pbHashValue`.  
  
 `dwAssemblyRefFlags`  
 [in] A bitwise combination of [CorAssemblyFlags](../../../../docs/framework/unmanaged-api/metadata/corassemblyflags-enumeration.md) values that influence the behavior of the execution engine.  
  
 `pmdar`  
 [out] A pointer to the returned `AssemblyRef` metadata token.  
  
## Remarks  
 One `AssemblyRef` metadata structure must be defined for each assembly that this assembly references.  
  
 At run time, the details of a referenced assembly are passed to the assembly resolver with an indication that they represent the "as built" information. The assembly resolver then applies policy.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
