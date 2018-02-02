---
title: "IMetaDataAssemblyImport::GetFileProps Method"
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
  - "IMetaDataAssemblyImport.GetFileProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::GetFileProps"
helpviewer_keywords: 
  - "GetFileProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::GetFileProps method [.NET Framework metadata]"
ms.assetid: c5e6216f-ae3d-4697-9688-66b69c1251ec
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::GetFileProps Method
Gets the properties of the file with the specified metadata signature.  
  
## Syntax  
  
```  
HRESULT GetFileProps (  
    [in]  mdFile      mdf,   
    [out] LPWSTR      szName,   
    [in]  ULONG       cchName,   
    [out] ULONG       *pchName,   
    [out] const void  **ppbHashValue,   
    [out] ULONG       *pcbHashValue,   
    [out] DWORD       *pdwFileFlags  
);  
```  
  
#### Parameters  
 `mdf`  
 [in] The `mdFile` metadata token that represents the file for which to get the properties.  
  
 `szName`  
 [out] The simple name of the file.  
  
 `cchName`  
 [in] The size, in wide chars, of `szName`.  
  
 `pchName`  
 [out] The number of wide chars actually returned in `szName`.  
  
 `ppbHashValue`  
 [out] A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the file.  
  
 `pcbHashValue`  
 [out] The number of wide chars in the returned hash value.  
  
 `pdwFileFlags`  
 [out] A pointer to the flags that describe the metadata applied to a file. The flags value is a combination of one or more [CorFileFlags](../../../../docs/framework/unmanaged-api/metadata/corfileflags-enumeration.md) values.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
