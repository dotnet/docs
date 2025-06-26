---
description: "Learn more about: IMetaDataImport2::EnumGenericParamConstraints Method"
title: "IMetaDataImport2::EnumGenericParamConstraints Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.EnumGenericParamConstraints"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::EnumGenericParamConstraints"
helpviewer_keywords:
  - "EnumGenericParamConstraints method [.NET Framework metadata]"
  - "IMetaDataImport2::EnumGenericParamConstraints method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::EnumGenericParamConstraints Method

Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.

## Syntax

```cpp
HRESULT EnumGenericParamConstraints (
    [in, out] HCORENUM                *phEnum,
    [in]  mdGenericParam              tk,
    [out] mdGenericParamConstraint    rGenericParamConstraints[],
    [in]  ULONG                       cMax,
    [out] ULONG                       *pcGenericParamConstraints
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator.

 `tk`
 [in]   A token that represents the generic parameter whose constraints are to be enumerated.

 `rGenericParamConstraints`
 [out] The array of generic parameter constraints to enumerate.

 `cMax`
 [in]   The requested maximum number of tokens to place in `rGenericParamConstraints`.

 `pcGenericParamConstraints`
 [out] A pointer to the number of tokens placed in `rGenericParamConstraints`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumGenericParameterConstraints` returned successfully.|
|`S_FALSE`|`phEnum` has no member elements. In this case, `pcGenericParameterConstraints` is set to 0 (zero).|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
