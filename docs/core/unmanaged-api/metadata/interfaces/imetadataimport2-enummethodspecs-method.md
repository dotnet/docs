---
description: "Learn more about: IMetaDataImport2::EnumMethodSpecs Method"
title: "IMetaDataImport2::EnumMethodSpecs Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.EnumMethodSpecs"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::EnumMethodSpecs"
  - "EnumMethodSpecs method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::EnumMethodSpecs Method

Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.

## Syntax

```cpp
HRESULT EnumMethodSpecs (
    [in, out] HCORENUM      *phEnum,
    [in]      mdToken       tk,
    [out]     mdMethodSpec  rMethodSpecs[],
    [in]      ULONG         cMax,
    [out]     ULONG         *pcMethodSpecs
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator for `rMethodSpecs`.

 `tk`
 [in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of `tk` is 0 (zero), all MethodSpec tokens in the scope will be enumerated.

 `rMethodSpecs`
 [out] The array of MethodSpec tokens to enumerate.

 `cMax`
 [in] The requested maximum number of tokens to place in `rMethodSpecs`.

 `pcMethodSpecs`
 [out] The returned number of tokens placed in `rMethodSpecs`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumMethodSpecs` returned successfully.|
|`S_FALSE`|`phEnum` has no member elements. In this case, `pcMethodSpecs` is set to 0 (zero).|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
