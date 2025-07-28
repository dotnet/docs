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
  - "IMetaDataEmit::DefineUserString method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
