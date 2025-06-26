---
description: "Learn more about: IHostSemaphore Interface"
title: "IHostSemaphore Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostSemaphore"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostSemaphore"
helpviewer_keywords:
  - "IHostSemaphore interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostSemaphore Interface

Represents the host's implementation of a semaphore for threading.

## Methods

|Method|Description|
|------------|-----------------|
|[ReleaseSemaphore Method](ihostsemaphore-releasesemaphore-method.md)|Increases the count of the current `IHostSemaphore` instance by the specified amount.|
|[Wait Method](ihostsemaphore-wait-method.md)|Causes the current `IHostSemaphore` instance to wait until it is owned or the specified amount of time elapses.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
