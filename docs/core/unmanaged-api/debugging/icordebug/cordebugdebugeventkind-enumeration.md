---
description: "Learn more about: CorDebugDebugEventKind Enumeration"
title: "CorDebugDebugEventKind Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugDebugEventKind"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# CorDebugDebugEventKind Enumeration

Indicates the type of event whose information is decoded by the [DecodeEvent](icordebugprocess6-decodeevent-method.md) method.

## Syntax

```cpp
typedef enum CorDebugDebugEventKind {
    DEBUG_EVENT_KIND_MODULE_LOADED                          = 1,
    DEBUG_EVENT_KIND_MODULE_UNLOADED                        = 2,
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_FIRST_CHANCE         = 3,
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_USER_FIRST_CHANCE    = 4,
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_CATCH_HANDLER_FOUND  = 5,
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_UNHANDLED            = 6
} CorDebugRecordFormat;
```

## Members

| Member                                                 | Description                    |
|--------------------------------------------------------|--------------------------------|
| `DEBUG_EVENT_KIND_MODULE_LOADED`                       | A module load event.           |
| `DEBUG_EVENT_KIND_MODULE_UNLOADED`                     | A module unload event.         |
| `DEBUG_EVENT_KIND_MANAGED_EXCEPTION_FIRST_CHANCE`      | A first-chance exception.      |
| `DEBUG_EVENT_KIND_MANAGED_EXCEPTION_USER_FIRST_CHANCE` | A first-chance user exception. |
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_CATCH_HANDLER_FOUND`|An exception for which a `catch` handler exists.|
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_UNHANDLED`|An unhandled exception.|

## Remarks

 A member of the `CorDebugDebugEventKind` enumeration is returned by calling the [ICorDebugDebugEvent::GetEventKind](icordebugdebugevent-geteventkind-method.md) method.

> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6
