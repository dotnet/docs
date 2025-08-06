---
description: "Learn more about: IMetaDataImport2::EnumGenericParams Method"
title: "IMetaDataImport2::EnumGenericParams Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.EnumGenericParams"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::EnumGenericParams"
  - "IMetaDataImport2::EnumGenericParams method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::EnumGenericParams Method

Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.

## Syntax

```cpp
HRESULT EnumGenericParams (
   [in, out] HCORENUM     *phEnum,
   [in]  mdToken          tk,
   [out] mdGenericParam   rGenericParams[],
   [in]  ULONG            cMax,
   [out] ULONG            *pcGenericParams
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator.

 `tk`
 [in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.

 `rGenericParams`
 [out] The array of generic parameters to enumerate.

 `cMax`
 [in] The requested maximum number of tokens to place in `rGenericParams`.

 `pcGenericParams`
 [out] The returned number of tokens placed in `rGenericParams`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumGenericParams` returned successfully. |
| `S_FALSE` |`phEnum` has no member elements. In this case, `pcGenericParams` is set to 0 (zero).|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
