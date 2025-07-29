---
description: "Learn more about: IMetaDataImport::EnumSignatures Method"
title: "IMetaDataImport::EnumSignatures Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumSignatures"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumSignatures"
  - "IMetaDataImport::EnumSignatures method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumSignatures Method

Enumerates Signature tokens representing stand-alone signatures in the current scope.

## Syntax

```cpp
HRESULT EnumSignatures (
   [in, out] HCORENUM     *phEnum,
   [out]     mdSignature  rSignatures[],
   [in]      ULONG        cMax,
   [out]     ULONG        *pcSignatures
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `rSignatures`
 [out] The array used to store the Signature tokens.

 `cMax`
 [in] The maximum size of the `rSignatures` array.

 `pcSignatures`
 [out] The number of Signature tokens returned in `rSignatures`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumSignatures` returned successfully.|
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcSignatures` is zero.|

## Remarks

 The Signature tokens are created by the [IMetaDataEmit::GetTokenFromSig](imetadataemit-gettokenfromsig-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
