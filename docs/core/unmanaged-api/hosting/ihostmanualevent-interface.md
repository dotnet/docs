---
description: "Learn more about: IHostManualEvent Interface"
title: "IHostManualEvent Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostManualEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostManualEvent"
helpviewer_keywords:
  - "IHostManualEvent interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostManualEvent Interface

Provides the host's implementation of a representation of a manual reset event.

## Methods

|Method|Description|
|------------|-----------------|
|[Reset Method](ihostmanualevent-reset-method.md)|Resets the current `IHostManualEvent` instance to a non-signaled state.|
|[Set Method](ihostmanualevent-set-method.md)|Sets the current `IHostManualEvent` instance to a signaled state.|
|[Wait Method](ihostmanualevent-wait-method.md)|Causes the current `IHostManualEvent` instance to wait until it is owned, or a specified amount of time elapses.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostSemaphore Interface](ihostsemaphore-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
