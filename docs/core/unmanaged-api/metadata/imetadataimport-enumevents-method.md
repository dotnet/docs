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
helpviewer_keywords:
  - "IMetaDataImport::EnumEvents method [.NET Framework metadata]"
  - "EnumEvents method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
