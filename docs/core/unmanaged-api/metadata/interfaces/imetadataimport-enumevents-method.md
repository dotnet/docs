---
description: "Learn more about: IMetaDataImport::EnumEvents Method"
title: "IMetaDataImport::EnumEvents Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumEvents"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumEvents"
  - "EnumEvents method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumEvents Method

Enumerates event definition tokens for the specified TypeDef token.

## Syntax

```cpp
HRESULT EnumEvents (
   [in, out] HCORENUM    *phEnum,
   [in]      mdTypeDef   td,
   [out]     mdEvent     rEvents[],
   [in]      ULONG       cMax,
   [out]    ULONG        *pcEvents
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator.

 `td`
 [in] The TypeDef token whose event definitions are to be enumerated.

 `rEvents`
 [out] The array of returned events.

 `cMax`
 [in] The maximum size of the `rEvents` array.

 `pcEvents`
 [out] The actual number of events returned in `rEvents`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumEvents` returned successfully.|
|`S_FALSE`|There are no events to enumerate. In that case, `pcEvents` is zero.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
