---
description: "Learn more about: IMetaDataEmit::SetTypeDefProps Method"
title: "IMetaDataEmit::SetTypeDefProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetTypeDefProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetTypeDefProps"
helpviewer_keywords:
  - "SetTypeDefProps method [.NET Framework metadata]"
  - "IMetaDataEmit::SetTypeDefProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetTypeDefProps Method

Sets features of a type defined by a prior call to [IMetaDataEmit::DefineTypeDef](imetadataemit-definetypedef-method.md).

## Syntax

```cpp
HRESULT SetTypeDefProps (
    [in]  mdTypeDef   td,
    [in]  DWORD       dwTypeDefFlags,
    [in]  mdToken     tkExtends,
    [in]  mdToken     rtkImplements[]
);
```

## Parameters

 `td`
 [in] An `mdTypeDef` token obtained from original call to [IMetaDataEmit::DefineTypeDef](imetadataemit-definetypedef-method.md).

 `dwTypeDefFlags`
 [in] `TypeDef` attributes. This is a bitmask of `CorTypeAttr` values.

 `tkExtends`
 [in] The `mdToken` of the base class. Obtained from a previous call to [IMetaDataEmit::DefineImportType](imetadataemit-defineimporttype-method.md), or `null`.

 `rtkImplements[]`
 [in] An array of tokens for the interfaces that this type implements. These `mdTypeRef` tokens are obtained using [IMetaDataEmit::DefineImportType](imetadataemit-defineimporttype-method.md). The last element of the array is must be `mdTokenNil`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
