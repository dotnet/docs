---
description: "Learn more about: ICorThreadpool::CorQueueUserWorkItem Method"
title: "ICorThreadpool::CorQueueUserWorkItem Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorQueueUserWorkItem"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorQueueUserWorkItem"
helpviewer_keywords:
  - "ICorThreadpool::CorQueueUserWorkItem method [.NET Framework hosting]"
  - "CorQueueUserWorkItem method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorQueueUserWorkItem Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorQueueUserWorkItem (
    [in] LPTHREAD_START_ROUTINE Function,
    [in] PVOID                  Context,
    [in] BOOL                   executeOnlyOnce,
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
