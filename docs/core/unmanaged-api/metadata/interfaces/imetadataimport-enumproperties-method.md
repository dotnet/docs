---
description: "Learn more about: IMetaDataImport::EnumProperties Method"
title: "IMetaDataImport::EnumProperties Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumProperties"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumProperties"
  - "EnumProperties method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumProperties Method

Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.

## Syntax

```cpp
HRESULT EnumProperties (
   [in, out] HCORENUM    *phEnum,
   [in]      mdTypeDef   td,
   [out]     mdProperty  rProperties[],
   [in]      ULONG       cMax,
   [out]     ULONG       *pcProperties
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `td`
 [in] A TypeDef token representing the type with properties to enumerate.

 `rProperties`
 [out] The array used to store the PropertyDef tokens.

 `cMax`
 [in] The maximum size of the `rProperties` array.

 `pcProperties`
 [out] The number of PropertyDef tokens returned in `rProperties`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumProperties` returned successfully.|
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcProperties` is zero.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
