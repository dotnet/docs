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
helpviewer_keywords:
  - "IMetaDataEmit::SaveToStream method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
