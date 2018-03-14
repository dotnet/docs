---
title: "IMetaDataAssemblyEmit::DefineAssembly Method"
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
  - "IMetaDataAssemblyEmit.DefineAssembly"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::DefineAssembly"
helpviewer_keywords: 
  - "IMetaDataAssemblyEmit::DefineAssembly method [.NET Framework metadata]"
  - "DefineAssembly method [.NET Framework metadata]"
ms.assetid: a0637d66-74bf-4f2d-8137-9ff838bccece
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::DefineAssembly Method
Creates an `Assembly` structure containing metadata for the specified assembly and returns the associated metadata token.  
  
## Syntax  
  
```  
HRESULT DefineAssembly (  
    [in]  void                 *pbPublicKey,  
    [in]  ULONG                cbPublicKey,  
    [in]  ULONG                uHashAlgId,  
    [in]  LPCWSTR              szName,   
    [in]  ASSEMBLYMETADATA     *pMetaData,  
    [in]  DWORD                dwAssemblyFlags,  
    [out] mdAssembly           *pmda  
);  
```  
  
#### Parameters  
 `pbPublicKey`  
 [in] The public key that identifies the publisher of the assembly, or NULL if the assembly is not strongly named.  
  
 `cbPublicKey`  
 [in] The size in bytes of `pbPublicKey`.  
  
 `uHashAlgId`  
 [in] The identifier of the hashing algorithm to use to encrypt the files in the assembly, or NULL to specify the SHA-1 algorithm.  
  
 `szName`  
 [in] The human-readable text name of the assembly. This value must not exceed 1024 characters.  
  
 `pMetaData`  
 [in] A pointer to an ASSEMBLYMETADATA instance that contains the version, platform, and locale information for the assembly.  
  
 `dwAssemblyFlags`  
 [in] A combination of [CorAssemblyFlags](../../../../docs/framework/unmanaged-api/metadata/corassemblyflags-enumeration.md) values that describe features of the assembly.  
  
 `pmda`  
 [out] A pointer to the metadata token.  
  
## Remarks  
 Only one `Assembly` metadata structure can be defined within a manifest.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
