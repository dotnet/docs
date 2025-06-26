---
description: "Learn more about: ICLROnEventManager Interface"
title: "ICLROnEventManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLROnEventManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLROnEventManager"
helpviewer_keywords:
  - "ICLROnEventManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLROnEventManager Interface

Provides methods that allow the host to register and unregister callbacks for common language runtime (CLR) events.

## Methods

|Method|Description|
|------------|-----------------|
|[RegisterActionOnEvent Method](iclroneventmanager-registeractiononevent-method.md)|Registers a callback pointer for the specified event.|
|[UnregisterActionOnEvent Method](iclroneventmanager-unregisteractiononevent-method.md)|Unregisters a previously registered callback pointer for the specified event.|

## Remarks

 To register and unregister event callbacks, the host gets a reference to `ICLROnEventManager` by calling the [ICLRControl::GetCLRManager](iclrcontrol-getclrmanager-method.md) method.

> [!NOTE]
> The events described by [EClrEvent](eclrevent-enumeration.md) can be fired more than once and from different threads to signal an unload or the disabling of the CLR.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrEvent Enumeration](eclrevent-enumeration.md)
- [IActionOnCLREvent Interface](iactiononclrevent-interface.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
