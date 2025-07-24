---
description: "Learn more about: IMetaDataEmit::SaveToStream Method"
title: "IMetaDataEmit::SaveToStream Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SaveToStream"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SaveToStream"
  - "SaveToStream method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SaveToStream Method

Saves all metadata in the current scope to the specified `IStream`.

## Syntax

```cpp
HRESULT SaveToStream (
    [in]  IStream     *pIStream,
    [in]  DWORD       dwSaveFlags
);
```

## Parameters

 `pIStream`
 [in] The writable stream to save to.

 `dwSaveFlags`
 [in] Reserved. Must be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
