---
description: "Learn more about: IMetaDataEmit::SaveToMemory Method"
title: "IMetaDataEmit::SaveToMemory Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SaveToMemory"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SaveToMemory"
  - "SaveToMemory method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SaveToMemory Method

Saves all metadata in the current scope to the specified area of memory.

## Syntax

```cpp
HRESULT SaveToMemory (
    [out]  void        *pbData,
    [in]   ULONG       cbData
);
```

## Parameters

 `pbData`
 [out] The address at which to begin writing metadata.

 `cbData`
 [in] The size, in bytes, of the allocated memory.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
