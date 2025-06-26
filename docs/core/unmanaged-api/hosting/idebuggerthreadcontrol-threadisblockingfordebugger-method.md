---
description: "Learn more about: IDebuggerThreadControl::ThreadIsBlockingForDebugger Method"
title: "IDebuggerThreadControl::ThreadIsBlockingForDebugger Method"
ms.date: "03/30/2017"
api_name:
  - "IDebuggerThreadControl.ThreadIsBlockingForDebugger"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ThreadIsBlockingForDebugger"
helpviewer_keywords:
  - "ThreadIsBlockingForDebugger method [.NET Framework hosting]"
  - "IDebuggerThreadControl::ThreadIsBlockingForDebugger method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IDebuggerThreadControl::ThreadIsBlockingForDebugger Method

Notifies the host that the thread that is sending this callback is about to block within the debugging services.

## Syntax

```cpp
HRESULT ThreadIsBlockingForDebugger ( );
```

## Remarks

 The `ThreadIsBlockingForDebugger` method will always be called on a runtime thread.

 The `ThreadIsBlockingForDebugger` method gives the host an opportunity to perform another action while the thread blocks.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **NET Framework Versions:** Available since .NET Framework 2.0

## See also

- [IDebuggerThreadControl Interface](idebuggerthreadcontrol-interface.md)
