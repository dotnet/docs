---
description: "Learn more about: IHostAutoEvent Interface"
title: "IHostAutoEvent Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostAutoEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostAutoEvent"
helpviewer_keywords:
  - "IHostAutoEvent interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostAutoEvent Interface

Provides a representation of the host's implementation of an auto-reset event.

## Methods

|Method|Description|
|------------|-----------------|
|[Set Method](ihostautoevent-set-method.md)|Sets the current `IHostAutoEvent` instance to a signaled state.|
|[Wait Method](ihostautoevent-wait-method.md)|Causes the current `IHostAutoEvent` instance to wait until the event is owned or a specified amount of time elapses.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
