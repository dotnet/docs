---
description: "Learn more about: ICorThreadpool::CorUnregisterWait Method"
title: "ICorThreadpool::CorUnregisterWait Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorUnregisterWait"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorUnregisterWait"
helpviewer_keywords:
  - "CorUnregisterWait method [.NET Framework hosting]"
  - "ICorThreadpool::CorUnregisterWait method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorUnregisterWait Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorUnregisterWait (
    [in] HANDLE hWaitObject,
    [in] HANDLE CompletionEvent,
    [out] BOOL* result
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
