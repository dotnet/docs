---
description: "Learn more about: IMetaDataEmit2::SaveDeltaToStream Method"
title: "IMetaDataEmit2::SaveDeltaToStream Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.SaveDeltaToStream"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::SaveDeltaToStream"
  - "SaveDeltaToStream method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::SaveDeltaToStream Method

Saves changes from the current edit-and-continue session to the specified stream.

## Syntax

```cpp
HRESULT SaveDeltaToStream (
    [in] IStream     *pIStream,
    [in] DWORD       dwSaveFlags
);
```

## Parameters

 `pIStream`
 [in] An interface pointer to the writable stream to which to save changes.

 `dwSaveFlags`
 [in] Reserved. This value must be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
