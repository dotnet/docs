---
description: "Learn more about: ICorThreadpool::CorBindIoCompletionCallback Method"
title: "ICorThreadpool::CorBindIoCompletionCallback Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorBindIoCompletionCallback"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorBindIoCompletionCallback"
helpviewer_keywords:
  - "CorBindIoCompletionCallback method [.NET Framework hosting]"
  - "ICorThreadpool::CorBindIoCompletionCallback method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorBindIoCompletionCallback Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorBindIoCompletionCallback (
    [in] HANDLE                          fileHandle,
    [in] LPOVERLAPPED_COMPLETION_ROUTINE callback
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
