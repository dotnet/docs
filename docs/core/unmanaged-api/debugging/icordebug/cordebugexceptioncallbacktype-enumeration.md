---
description: "Learn more about: CorDebugExceptionCallbackType Enumeration"
title: "CorDebugExceptionCallbackType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugExceptionCallbackType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugExceptionCallbackType"
helpviewer_keywords:
  - "CorDebugExceptionCallbackType enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugExceptionCallbackType Enumeration

Indicates the type of callback that is made from an [ICorDebugManagedCallback2::Exception](icordebugmanagedcallback2-exception-method.md) event.

## Syntax

```cpp
typedef enum CorDebugExceptionCallbackType {
    DEBUG_EXCEPTION_FIRST_CHANCE         = 1,
    DEBUG_EXCEPTION_USER_FIRST_CHANCE    = 2,
    DEBUG_EXCEPTION_CATCH_HANDLER_FOUND  = 3,
    DEBUG_EXCEPTION_UNHANDLED            = 4
} CorDebugExceptionCallbackType;
```

## Members

| Member                              | Description                                     |
|-------------------------------------|-------------------------------------------------|
| `DEBUG_EXCEPTION_FIRST_CHANCE`      | An exception was thrown.                        |
| `DEBUG_EXCEPTION_USER_FIRST_CHANCE` | The exception windup process entered user code. |
| `DEBUG_EXCEPTION_CATCH_HANDLER_FOUND` | The exception windup process found a `catch` block in user code. |
| `DEBUG_EXCEPTION_UNHANDLED`         | The exception was not handled. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
