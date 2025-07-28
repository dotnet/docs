---
description: "Learn more about: IMetaDataEmit2::DefineGenericParam Method"
title: "IMetaDataEmit2::DefineGenericParam Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.DefineGenericParam"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::DefineGenericParam"
  - "DefineGenericParam method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::DefineGenericParam Method

Creates a definition for a generic type parameter, and gets a token to that generic type parameter.

## Syntax

```cpp
HRESULT DefineGenericParam (
    [in]  mdToken         tk,
    [in]  ULONG           ulParamSeq,
    [in]  DWORD           dwParamFlags,
    [in]  LPCWSTR         szname,
    [in]  DWORD           reserved,
    [in]  mdToken         rtkConstraints[],
    [out] mdGenericParam  *pgp
);
```

## Parameters

 `tk`
 [in] An `mdTypeDef` or `mdMethodDef` token that represents the method or constructor for which to define a generic parameter.

 `ulParamSeq`
 [in] The index of the generic parameter.

 `dwParamFlags`
 [in] A value of the [CorGenericParamAttr](../enumerations/corgenericparamattr-enumeration.md) enumeration that describes the type for the generic parameter.

 `szname`
 [in] The name of the parameter.

 `reserved`
 [in] This parameter is reserved for future extensibility.

 `rtkConstraints`
 [in] A zero-terminated array of type constraints. Array members must be an `mdTypeDef`, `mdTypeRef`, or `mdTypeSpec` metadata token.

 `pgp`
 [out] A token that represents the generic parameter.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
