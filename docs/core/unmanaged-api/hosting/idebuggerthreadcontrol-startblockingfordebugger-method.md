---
description: "Learn more about: IDebuggerThreadControl::StartBlockingForDebugger Method"
title: "IDebuggerThreadControl::StartBlockingForDebugger Method"
ms.date: "03/30/2017"
api_name:
  - "IDebuggerThreadControl.StartBlockingForDebugger"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "StartBlockingForDebugger"
helpviewer_keywords:
  - "IDebuggerThreadControl::StartBlockingForDebugger method [.NET Framework hosting]"
  - "StartBlockingForDebugger method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IDebuggerThreadControl::StartBlockingForDebugger Method

Notifies the host that the debugging services are about to start blocking all threads.

## Syntax

```cpp
HRESULT StartBlockingForDebugger (
    [in] DWORD dwUnused
);
```

## Parameters

 `dwUnused`
 [in] Reserved for future use.

## Remarks

 The `StartBlockingForDebugger` method could be called on a runtime thread.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IDebuggerThreadControl Interface](idebuggerthreadcontrol-interface.md)
