---
description: "Learn more about: IMetaDataError::OnError Method"
title: "IMetaDataError::OnError Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataError.OnError"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataError::OnError"
  - "OnError method, IMetaDataError interface [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataError::OnError Method

Provides notification of errors that occur during the metadata merge.

## Syntax

```cpp
HRESULT OnError (
    [in] HRESULT   hrError,
    [in] mdToken   token
);
```

## Parameters

 `hrError`
 [in] The HRESULT error value returned to the calling method.

 `token`
 [in] The metadata token of the code object that was being merged when the error occurred.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataError Interface](imetadataerror-interface.md)
