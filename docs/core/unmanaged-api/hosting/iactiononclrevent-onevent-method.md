---
description: "Learn more about: IActionOnCLREvent::OnEvent Method"
title: "IActionOnCLREvent::OnEvent Method"
ms.date: "03/30/2017"
api_name:
  - "IActionOnCLREvent.OnEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IActionOnCLREvent::OnEvent"
helpviewer_keywords:
  - "OnEvent method [.NET Framework hosting]"
  - "IActionOnCLREvent::OnEvent method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IActionOnCLREvent::OnEvent Method

Performs callbacks on events that have been registered by using a call to the [ICLROnEventManager::RegisterActionOnEvent](iclroneventmanager-registeractiononevent-method.md) method.

## Syntax

```cpp
HRESULT OnEvent (
    [in] EClrEvent event,
    [in] PVOID     data
);
```

## Parameters

 `event`
 [in] One of the [EClrEvent](eclrevent-enumeration.md) values, which indicates the type of event.

 `data`
 [in] A pointer to an object that contains details about `event`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`OnEvent` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was cancelled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to any hosting method return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The `data` parameter is a pointer to an object of unspecified type. If the `event` parameter is `Event_DomainUnload`, `data` is the numeric identifier for the <xref:System.AppDomain> that was unloaded. The host can take appropriate action using this identifier as a key.

 If `event` is `Event_MDAFired`, `data` is a pointer to an [MDAInfo](mdainfo-structure.md) instance that contains the message output from a Managed Debugging Assistant (MDA). MDAs are a feature of the CLR that help developers with debugging, by generating XML messages about events that are otherwise difficult to trap. Such messages can be especially useful in debugging transitions between managed and unmanaged code. For more information, see [Diagnosing Errors with Managed Debugging Assistants](../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Diagnosing Errors with Managed Debugging Assistants](../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
- [EClrEvent Enumeration](eclrevent-enumeration.md)
- [IActionOnCLREvent Interface](iactiononclrevent-interface.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLROnEventManager Interface](iclroneventmanager-interface.md)
- [MDAInfo Structure](mdainfo-structure.md)
