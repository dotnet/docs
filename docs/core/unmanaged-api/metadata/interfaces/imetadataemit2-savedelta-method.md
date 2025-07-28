---
description: "Learn more about: IMetaDataEmit2::SaveDelta Method"
title: "IMetaDataEmit2::SaveDelta Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.SaveDelta"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::SaveDelta"
  - "SaveDelta method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::SaveDelta Method

Saves changes from the current edit-and-continue session to the specified file.

## Syntax

```cpp
HRESULT SaveDelta (
    [in] LPCWSTR     szFile,
    [in] DWORD       dwSaveFlags
);
```

## Parameters

 `szFile`
 [in] The file name under which to save changes.

 `dwSaveFlags`
 [in] Reserved. Must be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
