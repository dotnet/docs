---
description: "Learn more about: IMetaDataEmit::DefineParam Method"
title: "IMetaDataEmit::DefineParam Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineParam"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineParam"
  - "DefineParam method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineParam Method

Creates a parameter definition with the specified signature for the method referenced by the specified token, and gets a token for that parameter definition.

## Syntax

```cpp
HRESULT DefineParam (
    [in]  mdMethodDef md,
    [in]  ULONG       ulParamSeq,
    [in]  LPCWSTR     szName,
    [in]  DWORD       dwParamFlags,
    [in]  DWORD       dwCPlusTypeFlag,
    [in]  void const  *pValue,
    [in]  ULONG       cchValue,
    [out] mdParamDef  *ppd
);
```

## Parameters

 `md`
 [in] The token for the method whose parameter is being defined.

 `ulParamSeq`
 [in] The parameter sequence number.

 `szName`
 [in] The name of the parameter in Unicode.

 `dwParamFlags`
 [in] Flags for the parameter. This is a bitmask of `CorParamAttr` values.

 `dwCPlusTypeFlag`
 [in] `ELEMENT_TYPE_`*\** for the constant value.

 `pValue`
 [in] The constant value for the parameter.

 `cchValue`
 [in] The size, in Unicode characters, of `pValue`.

 `ppd`
 [out] The `mdParamDef` token assigned.

## Remarks

 The sequence values in `ulParamSeq` begin with 1 for parameters. A return value has a sequence number of 0.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
