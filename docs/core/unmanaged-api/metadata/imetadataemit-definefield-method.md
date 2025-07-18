---
description: "Learn more about: IMetaDataEmit::DefineField Method"
title: "IMetaDataEmit::DefineField Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineField"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineField"
helpviewer_keywords:
  - "IMetaDataEmit::DefineField method [.NET Framework metadata]"
  - "DefineField method, IMetaDataEmit interface [.NET Framework metadata"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineField Method

Creates a definition for a field with the specified metadata signature, and gets a token to that field definition.

## Syntax

```cpp
HRESULT DefineField (
    [in]  mdTypeDef   td,
    [in]  LPCWSTR     szName,
    [in]  DWORD       dwFieldFlags,
    [in]  PCCOR_SIGNATURE pvSigBlob,
    [in]  ULONG       cbSigBlob,
    [in]  DWORD       dwCPlusTypeFlag,
    [in]  void const  *pValue,
    [in]  ULONG       cchValue,
    [out] mdFieldDef  *pmd
);
```

## Parameters

 `td`
 [in] The `mdTypeDef` token for the enclosing class or interface.

 `szName`
 [in] The field name in Unicode.

 `dwFieldFlags`
 [in] The field attributes. This is a bitmask of `CorFieldAttr` values.

 `pvSigBlob`
 [in] The field signature as a BLOB.

 `cbSigBlob`
 [in] The count of bytes in `pvSigBlob`.

 `dwCPlusTypeFlag`
 [in] The `ELEMENT_TYPE_`*\** for the constant value. This is a `CorElementType` value. If not defining a constant value for the field, use `ELEMENT_TYPE_END`.

 `pValue`
 [in] The constant value for the field.

 `cchValue`
 [in] The size in (Unicode) characters of `pValue`.

 `pmd`
 [out] The `mdFieldDef` token assigned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
