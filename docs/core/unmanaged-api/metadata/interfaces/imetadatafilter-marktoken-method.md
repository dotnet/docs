---
description: "Learn more about: IMetaDataFilter::MarkToken Method"
title: "IMetaDataFilter::MarkToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataFilter.MarkToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataFilter::MarkToken"
  - "MarkToken method, IMetaDataFilter interface [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataFilter::MarkToken Method

Sets a value indicating that the specified metadata token has been processed.

## Syntax

```cpp
HRESULT MarkToken (
    [in] mdToken   tk
);
```

## Parameters

 `tk`
 [in] The token to mark as processed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataFilter Interface](imetadatafilter-interface.md)
