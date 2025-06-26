---
description: "Learn more about: ICorThreadpool::CorCreateTimer Method"
title: "ICorThreadpool::CorCreateTimer Method"
ms.date: "03/30/2017"
api_name:
  - "ICorThreadpool.CorCreateTimer"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorCreateTimer"
helpviewer_keywords:
  - "CorCreateTimer method [.NET Framework hosting]"
  - "ICorThreadpool::CorCreateTimer method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorThreadpool::CorCreateTimer Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT CorCreateTimer (
    [in]  HANDLE*             phNewTimer,
    [in]  WAITORTIMERCALLBACK Callback,
    [in]  PVOID               Parameter,
    [in]  DWORD               DueTime,
    [in]  DWORD               Period,
    [out] BOOL*               result
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
