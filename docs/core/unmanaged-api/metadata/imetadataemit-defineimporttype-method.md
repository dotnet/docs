---
description: "Learn more about: IMetaDataEmit::DefineImportType Method"
title: "IMetaDataEmit::DefineImportType Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineImportType"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineImportType"
helpviewer_keywords:
  - "DefineImportType method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineImportType method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineImportType Method

Creates a reference to the specified type that is defined outside the current scope, and defines a token for that reference.

## Syntax

```cpp
HRESULT DefineImportType (
    [in]  IMetaDataAssemblyImport  *pAssemImport,
    [in]  const void               *pbHashValue,
    [in]  ULONG                    cbHashValue,
    [in]  IMetaDataImport          *pImport,
    [in]  mdTypeDef                tdImport,
    [in]  IMetaDataAssemblyEmit    *pAssemEmit,
    [out] mdTypeRef                *ptr
);
```

## Parameters

 `pAssemImport`
 [in] An [IMetaDataAssemblyImport](imetadataassemblyimport-interface.md) interface that represents the assembly from which the target type is imported.

 `pbHashValue`
 [in] An array that contains the hash for the assembly specified by `pAssemImport`.

 `cbHashValue`
 [in] The number of bytes in the `pbHashValue` array.

 `pImport`
 [in] An [IMetaDataImport](imetadataimport-interface.md) interface that represents the metadata scope from which the target type is imported.

 `tdImport`
 [in] An `mdTypeDef` token that specifies the target type.

 `pAssemEmit`
 [in] An [IMetaDataAssemblyEmit](imetadataassemblyemit-interface.md) interface that represents the assembly into which the target type is imported.

 `ptr`
 [out] The `mdTypeRef` token that is defined in the current scope for the type reference.

## Remarks

 Prior to calling the [IMetaDataEmit::DefineImportMember](imetadataemit-defineimportmember-method.md) method, you can use the `DefineImportType` method to create a type reference, in the current scope, for the member's parent class or parent interface.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
