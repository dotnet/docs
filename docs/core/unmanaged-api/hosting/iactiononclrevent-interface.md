---
description: "Learn more about: IActionOnCLREvent Interface"
title: "IActionOnCLREvent Interface"
ms.date: "03/30/2017"
api_name:
  - "IActionOnCLREvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IActionOnCLREvent"
helpviewer_keywords:
  - "IActionOnCLREvent interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IActionOnCLREvent Interface

Provides the [IActionOnCLREvent::OnEvent](iactiononclrevent-onevent-method.md) method, which performs callbacks on events that have been registered by using a call to the [ICLROnEventManager::RegisterActionOnEvent](iclroneventmanager-registeractiononevent-method.md) method.

## Methods

|Method|Description|
|------------|-----------------|
|[OnEvent Method](iactiononclrevent-onevent-method.md)|Performs a callback for a registered event.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrEvent Enumeration](eclrevent-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLROnEventManager Interface](iclroneventmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
