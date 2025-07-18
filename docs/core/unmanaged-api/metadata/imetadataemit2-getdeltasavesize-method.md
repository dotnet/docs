---
description: "Learn more about: IMetaDataEmit2::GetDeltaSaveSize Method"
title: "IMetaDataEmit2::GetDeltaSaveSize Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.GetDeltaSaveSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::GetDeltaSaveSize"
helpviewer_keywords:
  - "IMetaDataEmit2::GetDeltaSaveSize method [.NET Framework metadata]"
  - "GetDeltaSaveSize method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::GetDeltaSaveSize Method

Gets a value indicating any change in metadata size that results from the current edit-and-continue session.

## Syntax

```cpp
HRESULT GetDeltaSaveSize (
    [in]  CorSaveSize  fSave,
    [out] DWORD        *pdwSaveSize
);
```

## Parameters

 `fSave`
 [in] One of the [CorSaveSize](corsavesize-enumeration.md) values, indicating the level of precision desired. For .NET Framework version 2.0, this parameter is ignored.

 `pdwSaveSize`
 [out] The change in the size of the metadata.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
