---
description: "Learn more about: IMetaDataAssemblyImport::GetExportedTypeProps Method"
title: "IMetaDataAssemblyImport::GetExportedTypeProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyImport.GetExportedTypeProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::GetExportedTypeProps"
helpviewer_keywords: 
  - "GetExportedTypeProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::GetExportedTypeProps method [.NET Framework metadata]"
ms.assetid: 25ca7623-5a55-4f09-b44a-36b03d142278
topic_type: 
  - "apiref"
---
# IMetaDataAssemblyImport::GetExportedTypeProps Method

Gets the set of properties of the exported type with the specified metadata signature.  
  
## Syntax  
  
```cpp  
HRESULT GetExportedTypeProps (  
    [in]  mdExportedType    mdct,
    [out] LPWSTR            szName,
    [in]  ULONG             cchName,
    [out] ULONG             *pchName,
    [out] mdToken           *ptkImplementation,
    [out] mdTypeDef         *ptkTypeDef,
    [out] DWORD             *pdwExportedTypeFlags  
);  
```  
  
## Parameters  

 `mdct`  
 [in] An `mdExportedType` metadata token that represents the exported type.  
  
 `szName`  
 [out] The name of the exported type.  
  
 `cchName`  
 [in] The size, in wide characters, of `szName`.  
  
 `pchName`  
 [out] The number of wide characters actually returned in `szName`  
  
 `ptkImplementation`  
 [out] An `mdFile`, `mdAssemblyRef`, or `mdExportedType` metadata token that contains or allows access to the properties of the exported type.  
  
 `ptkTypeDef`  
 [out] A pointer to an `mdTypeDef` token that represents a type in the file.  
  
 `pdwExportedTypeFlags`  
 [out] A pointer to the flags that describe the metadata applied to the exported type. The flags value can be one or more [CorTypeAttr](cortypeattr-enumeration.md) values.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
