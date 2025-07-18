---
description: "Learn more about: IMetaDataEmit::DefineUserString Method"
title: "IMetaDataEmit::DefineUserString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineUserString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineUserString"
helpviewer_keywords:
  - "DefineUserString method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineUserString method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineUserString Method

Gets a metadata token for the specified literal string.

## Syntax

```cpp
HRESULT DefineUserString (
    [in]  LPCWSTR     szString,
    [in]  ULONG       cchString,
    [out] mdString    *pstk
);
```

## Parameters

 `szString`
 [in] The user string to store.

 `cchString`
 [in] The count of wide characters in `szString`.

 `pstk`
 [out] The string token assigned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
