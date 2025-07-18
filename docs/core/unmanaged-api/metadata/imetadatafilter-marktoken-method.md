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
helpviewer_keywords:
  - "IMetaDataFilter::MarkToken method [.NET Framework metadata]"
  - "MarkToken method, IMetaDataFilter interface [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataFilter Interface](imetadatafilter-interface.md)
