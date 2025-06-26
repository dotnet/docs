---
description: "Learn more about: ICLROnEventManager::RegisterActionOnEvent Method"
title: "ICLROnEventManager::RegisterActionOnEvent Method"
ms.date: "03/30/2017"
api_name:
  - "ICLROnEventManager.RegisterActionOnEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLROnEventManager::RegisterActionOnEvent"
helpviewer_keywords:
  - "ICLROnEventManager::RegisterActionOnEvent method [.NET Framework hosting]"
  - "RegisterActionOnEvent method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLROnEventManager::RegisterActionOnEvent Method

Registers a callback pointer for the specified event.

## Syntax

```cpp
HRESULT RegisterActionOnEvent (
    [in] EClrEvent event,
    [in] IActionOnCLREvent *pAction
);
```

## Parameters

 `event`
 [in] One of the [EClrEvent](eclrevent-enumeration.md) values, indicating the event for which to register the callback pointer described by `pAction`.

 `pAction`
 [in] A pointer to an [IActionOnCLREvent](iactiononclrevent-interface.md) object that is called when the registered event fires.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`RegisterActionOnEvent` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The host can register callbacks for either or both of the two event types described by `EClrEvent`. The host gets the `ICLROnEventManager` interface by calling the [ICLRControl::GetCLRManager](iclrcontrol-getclrmanager-method.md) method.

> [!NOTE]
> The events that `RegisterActionOnEvent` registers can be fired more than once and from different threads to signal an unload or the disabling of the CLR.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrEvent Enumeration](eclrevent-enumeration.md)
- [IActionOnCLREvent Interface](iactiononclrevent-interface.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLROnEventManager Interface](iclroneventmanager-interface.md)
