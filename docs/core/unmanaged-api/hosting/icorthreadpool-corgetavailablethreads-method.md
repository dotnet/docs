---
description: "Learn more about: ICorThreadpool::CorGetAvailableThreads Method"
title: "ICorThreadpool::CorGetAvailableThreads Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorGetAvailableThreads"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorGetAvailableThreads"
helpviewer_keywords:
  - "CorGetAvailableThreads method [.NET Framework hosting]"
  - "ICorThreadpool::CorGetAvailableThreads method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorGetAvailableThreads Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorGetAvailableThreads (
    [out] DWORD *AvailableWorkerThreads,
    [out] DWORD *AvailableIOCompletionThreads
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
