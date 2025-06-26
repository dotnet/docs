---
description: "Learn more about: IDebuggerThreadControl::ReleaseAllRuntimeThreads Method"
title: "IDebuggerThreadControl::ReleaseAllRuntimeThreads Method"
ms.date: "03/30/2017"
api_name:
  - "IDebuggerThreadControl.ReleaseAllRuntimeThreads"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ReleaseAllRuntimeThreads"
helpviewer_keywords:
  - "ReleaseAllRuntimeThreads method [.NET Framework hosting]"
  - "IDebuggerThreadControl::ReleaseAllRuntimeThreads method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IDebuggerThreadControl::ReleaseAllRuntimeThreads Method

Notifies the host that the debugging services are about to release all threads that are blocked.

## Syntax

```cpp
HRESULT ReleaseAllRuntimeThreads ( );
```

## Remarks

 The `ReleaseAllRuntimeThreads` method will never be called on a runtime thread. If the host has a runtime thread blocked, it should release it now.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IDebuggerThreadControl Interface](idebuggerthreadcontrol-interface.md)
