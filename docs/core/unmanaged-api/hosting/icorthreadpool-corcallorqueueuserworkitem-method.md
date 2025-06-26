---
description: "Learn more about: ICorThreadpool::CorCallOrQueueUserWorkItem Method"
title: "ICorThreadpool::CorCallOrQueueUserWorkItem Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorCallOrQueueUserWorkItem"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorCallOrQueueUserWorkItem"
helpviewer_keywords:
  - "ICorThreadpool::CorCallOrQueueUserWorkItem method [.NET Framework hosting]"
  - "CorCallOrQueueUserWorkItem method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorCallOrQueueUserWorkItem Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorCallOrQueueUserWorkItem (
    [in] LPTHREAD_START_ROUTINE Function,
    [in] PVOID                  Context,
    [out] BOOL*                 result
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
