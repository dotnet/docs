---
title: "IMetaDataAssemblyEmit::SetAssemblyProps Method"
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
  - "IMetaDataAssemblyEmit.SetAssemblyProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::SetAssemblyProps"
helpviewer_keywords: 
  - "SetAssemblyProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyEmit::SetAssemblyProps method [.NET Framework metadata]"
ms.assetid: 91b633d7-9e75-43c3-a8d2-2144984e5f9e
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::SetAssemblyProps Method
Modifies the specified `Assembly` metadata structure.  
  
## Syntax  
  
```  
HRESULT SetAssemblyProps (  
    [in] mdAssembly               pma,  
    [in] const void               *pbPublicKey,  
    [in] ULONG                    cbPublicKey,  
    [in] ULONG                    ulHashAlgId,  
    [in] LPCWSTR                  szName,  
    [in] const ASSEMBLYMETADATA   *pMetaData,  
    [in] DWORD                    dwAssemblyFlags  
);  
```  
  
#### Parameters  
 `pma`  
 [in] The metadata token that specifies the `Assembly` metadata structure to be modified.  
  
 `pbPublicKey`  
 [in] A pointer to the public key of the publisher of the assembly.  
  
 `cbPublicKey`  
 [in] The size in bytes of `pbPublicKey`.  
  
 `ulHashAlgId`  
 [in] The identifier for the hash algorithm used to hash the assembly files.  
  
 `szName`  
 [in] The human-readable text name of the assembly.  
  
 `pMetaData`  
 [in] A pointer to the ASSEMBLYMETADATA that contains version, platform, and locale information for the assembly.  
  
 `dwAssemblyFlags`  
 [in] A bitwise combination of [AssemblyFlags](../../../../docs/framework/unmanaged-api/metadata/assemblyflags-enumeration.md) values that specify various attributes of the assembly.  
  
## Remarks  
 To create an `Assembly` metadata structure, use the [IMetaDataAssemblyEmit::DefineAssembly](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-defineassembly-method.md) method.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
