---
description: "Learn more about: IDebuggerThreadControl Interface"
title: "IDebuggerThreadControl Interface"
ms.date: "03/30/2017"
api_name:
  - "IDebuggerThreadControl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IDebuggerThreadControl"
helpviewer_keywords:
  - "IDebuggerThreadControl interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IDebuggerThreadControl Interface

Provides methods for notifying the host about the blocking and unblocking of threads by the debugging services.

## Methods

|Method|Description|
|------------|-----------------|
|[ThreadIsBlockingForDebugger Method](idebuggerthreadcontrol-threadisblockingfordebugger-method.md)|Notifies the host that the thread that is sending this callback is about to block within the debugging services.|
|[ReleaseAllRuntimeThreads Method](idebuggerthreadcontrol-releaseallruntimethreads-method.md)|Notifies the host that the debugging services are about to release all threads that are blocked.|
|[StartBlockingForDebugger Method](idebuggerthreadcontrol-startblockingfordebugger-method.md)|Notifies the host that the debugging services are about to start blocking all threads.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Interfaces](hosting-interfaces.md)
