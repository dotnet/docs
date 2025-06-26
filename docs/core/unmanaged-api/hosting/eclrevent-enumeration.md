---
description: "Learn more about: EClrEvent Enumeration"
title: "EClrEvent Enumeration"
ms.date: "03/30/2017"
api_name:
  - "EClrEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "EClrEvent"
helpviewer_keywords:
  - "EClrEvent enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# EClrEvent Enumeration

Describes the common language runtime (CLR) events for which the host can register callbacks.

## Syntax

```cpp
typedef enum {
    Event_ClrDisabled,
    Event_DomainUnload,
    Event_MDAFired,
    Event_StackOverflow
} EClrEvent;
```

## Members

| Member                | Description                                                                    |
|-----------------------|--------------------------------------------------------------------------------|
| `Event_ClrDisabled`   | Specifies a fatal CLR error.                                                   |
| `Event_DomainUnload`  | Specifies the unloading of a particular <xref:System.AppDomain>.               |
| `Event_MDAFired`      | Specifies that a Managed Debugging Assistant (MDA) message has been generated. |
| `Event_StackOverflow` | Specifies that a stack overflow error has occurred.                            |

## Remarks

 The host can register callbacks for any of the event types described by `EClrEvent` by calling methods of the [ICLROnEventManager](iclroneventmanager-interface.md) interface. The host gets a pointer to this interface by calling the [ICLRControl::GetCLRManager](iclrcontrol-getclrmanager-method.md) method.

 The `Event_CLRDisabled` and `Event_DomainUnload` events can be raised more than once and from different threads to signal an unload or the disabling of the CLR.

 The `Event_MDAFired` event raises the creation of an [MDAInfo](mdainfo-structure.md) instance that contains the details of the MDA message. For more information about MDAs, see [Diagnosing Errors with Managed Debugging Assistants](../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IActionOnCLREvent Interface](iactiononclrevent-interface.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
