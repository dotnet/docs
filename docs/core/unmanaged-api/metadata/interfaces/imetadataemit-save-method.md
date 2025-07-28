---
description: "Learn more about: IMetaDataEmit::Save Method"
title: "IMetaDataEmit::Save Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.Save"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::Save"
  - "IMetaDataEmit::Save method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::Save Method

Saves all metadata in the current scope to the file at the specified address.

## Syntax

```cpp
HRESULT Save (
    [in]  LPCWSTR     szFile,
    [in]  DWORD       dwSaveFlags
);
```

## Parameters

 `wzFile`
 [in] The name of the file to save to. If this value is null, the in-memory copy will be saved to the last location that was used.

 `dwSaveFlags`
 [in] Reserved. Must be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
