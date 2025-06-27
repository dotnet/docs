---
description: "Learn more about: IMetaDataEmit::DefineNestedType Method"
title: "IMetaDataEmit::DefineNestedType Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineNestedType"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineNestedType"
helpviewer_keywords:
  - "IMetaDataEmit::DefineNestedType method [.NET Framework metadata]"
  - "DefineNestedType method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineNestedType Method

Creates the metadata signature of a type definition, returns an `mdTypeDef` token for that type, and specifies that the defined type is a member of the type referenced by the `tdEncloser` parameter.

## Syntax

```cpp
HRESULT DefineNestedType (
    [in]  LPCWSTR     szTypeDef,
    [in]  DWORD       dwTypeDefFlags,
    [in]  mdToken     tkExtends,
    [in]  mdToken     rtkImplements[],
    [in]  mdTypeDef   tdEncloser,
    [out] mdTypeDef   *ptd
);
```

## Parameters

 `szTypeDef`
 [in] The name of the type in Unicode.

 `dwTypeDefFlags`
 [in] `TypeDef` attributes. This is a bitmask of `CorTypeAttr` values.

 `tkExtends`
 [in] The token of the base class. This is either a `mdTypeDef` or a `mdTypeRef` token.

 `rtkImplements`[]
 [in] An array of tokens that specify the interfaces that this class or interface implements.

 `tdEncloser`
 [in] The token of the enclosing type. The last element of the array must be `mdTokenNil`.

 `ptd`
 [out] The `mdTypeDef` token assigned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
