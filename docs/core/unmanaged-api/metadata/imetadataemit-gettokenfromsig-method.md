---
description: "Learn more about: IMetaDataEmit::GetTokenFromSig Method"
title: "IMetaDataEmit::GetTokenFromSig Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.GetTokenFromSig"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::GetTokenFromSig"
  - "GetTokenFromSig method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::GetTokenFromSig Method

Gets a token for the specified metadata signature.

## Syntax

```cpp
HRESULT GetTokenFromSig (
    [in]  PCCOR_SIGNATURE pvSig,
    [in]  ULONG       cbSig,
    [out] mdSignature *pmsig
);
```

## Parameters

 `pvSig`
 [in] The signature to be persisted and stored.

 `cbSig`
 [in] The count of bytes in `pvSig`.

 `pmsig`
 [out] The `mdSignature` token assigned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
