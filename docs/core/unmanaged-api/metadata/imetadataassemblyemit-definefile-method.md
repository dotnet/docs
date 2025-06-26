---
description: "Learn more about: IMetaDataAssemblyEmit::DefineFile Method"
title: "IMetaDataAssemblyEmit::DefineFile Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyEmit.DefineFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::DefineFile"
helpviewer_keywords: 
  - "IMetaDataAssemblyEmit::DefineFile method [.NET Framework metadata]"
  - "DefineFile method [.NET Framework metadata]"
ms.assetid: c065aadf-c1ca-4981-bde6-597042cb29c4
topic_type: 
  - "apiref"
---
# IMetaDataAssemblyEmit::DefineFile Method

Creates a `File` metadata structure containing metadata for assembly referenced by this assembly, and returns the associated metadata token.  
  
## Syntax  
  
```cpp  
HRESULT DefineFile (  
    [in]  LPCWSTR        szName,
    [in]  const void     *pbHashValue,
    [in]  ULONG          cbHashValue,  
    [in]  DWORD          dwFileFlags,  
    [out] mdFile         *pmdf  
);  
```  
  
## Parameters  

 `szName`  
 [in] The name of the file to be consumed.  
  
 `pbHashValue`  
 [in] A pointer to the hash data associated with the assembly.  
  
 `cbHashValue`  
 [in] The size in bytes of `pbHashValue`.  
  
 `dwFileFlags`  
 [in] A bitwise combination of `FileFlags` values that specify property settings.  
  
 `pmdf`  
 [out] A pointer to the returned `File` token.  
  
## Remarks  

 One `File` metadata structure must be defined for each file that was part of this assembly at the time that this assembly was built, excluding the file that contains the metadata.  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
