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
  - "IMetaDataAssemblyImport::GetExportedTypeProps method [.NET metadata]"
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
 [out] A pointer to the flags that describe the metadata applied to the exported type. The flags value can be one or more [CorTypeAttr](../enumerations/cortypeattr-enumeration.md) values.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
