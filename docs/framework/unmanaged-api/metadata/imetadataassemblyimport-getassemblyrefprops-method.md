---
title: "IMetaDataAssemblyImport::GetAssemblyRefProps Method"
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
  - "IMetaDataAssemblyImport.GetAssemblyRefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::GetAssemblyRefProps"
helpviewer_keywords: 
  - "IMetaDataAssemblyImport::GetAssemblyRefProps method [.NET Framework metadata]"
  - "GetAssemblyRefProps method [.NET Framework metadata]"
ms.assetid: 5c6b7fb4-cbca-4479-b650-ab9a99732ea0
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::GetAssemblyRefProps Method
Gets the set of properties for the assembly reference with the specified metadata signature.  
  
## Syntax  
  
```  
HRESULT GetAssemblyRefProps (  
    [in]  mdAssemblyRef        mdar,   
    [out] const void          **ppbPublicKeyOrToken,   
    [out] ULONG                *pcbPublicKeyOrToken,   
    [out] LPWSTR               szName,   
    [in]  ULONG                cchName,   
    [out] ULONG                *pchName,   
    [out] ASSEMBLYMETADATA     *pMetaData,   
    [out] const void           **ppbHashValue,   
    [out] ULONG                *pcbHashValue,   
    [out] DWORD                *pdwAssemblyRefFlags  
);  
```  
  
#### Parameters  
 `mdar`  
 [in] The `mdAssemblyRef` metadata token that represents the assembly reference for which to get the properties.  
  
 `ppbPublicKeyOrToken`  
 [out] A pointer to the public key or the metadata token.  
  
 `pcbPublicKeyOrToken`  
 [out] The number of bytes in the returned public key or token.  
  
 `szName`  
 [out] The simple name of the assembly.  
  
 `cchName`  
 [in] The size, in wide chars, of `szName`.  
  
 `pchName`  
 [out] A pointer to the number of wide chars actually returned in `szName`.  
  
 `pMetaData`  
 [out] A pointer to an ASSEMBLYMETADATA structure that contains the assembly metadata.  
  
 `ppbHashValue`  
 [out] A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the `PublicKey` property of the assembly being referenced, unless the arfFullOriginator flag of the [AssemblyRefFlags](../../../../docs/framework/unmanaged-api/metadata/assemblyrefflags-enumeration.md) enumeration is set.  
  
 `pcbHashValue`  
 [out] The number of wide chars in the returned hash value.  
  
 `pdwAssemblyRefFlags`  
 [out] A pointer to flags that describe the metadata applied to an assembly. The flags value is a combination of one or more [CorAssemblyFlags](../../../../docs/framework/unmanaged-api/metadata/corassemblyflags-enumeration.md) values.  
  
## Return Value  
 This method returns S_OK if it succeeds; otherwise, it returns one of the error codes defined in the Winerror.h header file.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
