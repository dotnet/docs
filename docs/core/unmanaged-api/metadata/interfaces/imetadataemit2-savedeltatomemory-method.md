---
description: "Learn more about: IMetaDataEmit2::SaveDeltaToMemory Method"
title: "IMetaDataEmit2::SaveDeltaToMemory Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.SaveDeltaToMemory"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::SaveDeltaToMemory"
  - "IMetaDataEmit2::SaveDeltaToMemory method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::SaveDeltaToMemory Method

Saves changes from the current edit-and-continue session to memory.

## Syntax

```cpp
HRESULT SaveDeltaToMemory (
    [out] void        *pbData,
    [in]  ULONG       cbData
);
```

## Parameters

 `pbData`
 [out] The address at which to begin writing the metadata delta.

 `cbData`
 [in] The size of the changes. Use [IMetaDataEmit2::GetDeltaSaveSize](imetadataemit2-getdeltasavesize-method.md) to determine the size.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
