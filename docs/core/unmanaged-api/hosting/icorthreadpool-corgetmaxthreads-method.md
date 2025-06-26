---
description: "Learn more about: ICorThreadpool::CorGetMaxThreads Method"
title: "ICorThreadpool::CorGetMaxThreads Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorGetMaxThreads"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorGetMaxThreads"
helpviewer_keywords:
  - "CorGetMaxThreads method [.NET Framework hosting]"
  - "ICorThreadpool::CorGetMaxThreads method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorGetMaxThreads Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorGetMaxThreads (
    [out] DWORD *MaxWorkerThreads,
    [out] DWORD *MaxIOCompletionThreads
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
