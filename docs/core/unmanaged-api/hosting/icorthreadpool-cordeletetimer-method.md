---
description: "Learn more about: ICorThreadpool::CorDeleteTimer Method"
title: "ICorThreadpool::CorDeleteTimer Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorDeleteTimer"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDeleteTimer"
helpviewer_keywords:
  - "ICorThreadpool::CorDeleteTimer method [.NET Framework hosting]"
  - "CorDeleteTimer method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorDeleteTimer Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorDeleteTimer (
    [in]  HANDLE Timer,
    [in]  HANDLE CompletionEvent,
    [out] BOOL*  result
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
