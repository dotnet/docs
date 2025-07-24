---
description: "Learn more about: IMetaDataFilter::IsTokenMarked Method"
title: "IMetaDataFilter::IsTokenMarked Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataFilter.IsTokenMarked"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataFilter::IsTokenMarked"
  - "IsTokenMarked method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataFilter::IsTokenMarked Method

Gets a value indicating whether the specified metadata token has been marked as processed.

## Syntax

```cpp
HRESULT IsTokenMarked (
    [in]  mdToken  tk,
    [out] BOOL     *pIsMarked
);
```

## Parameters

 `tk`
 [in] The token to examine for a processing mark.

 `pIsMarked`
 [out] A value that is `true` if `tk` has been processed; otherwise `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataFilter Interface](imetadatafilter-interface.md)
