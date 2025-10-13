---
description: "Learn more about: CorDebugExceptionFlags Enumeration"
title: "CorDebugExceptionFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugExceptionFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugExceptionFlags"
helpviewer_keywords:
  - "CorDebugExceptionFlags enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugExceptionFlags Enumeration

Provides additional information about an exception.

## Syntax

```cpp
typedef enum CorDebugExceptionFlags {
    DEBUG_EXCEPTION_NONE = 0,
    DEBUG_EXCEPTION_CAN_BE_INTERCEPTED = 0x0001
} CorDebugExceptionFlags;
```

## Members

| Member                 | Description            |
|------------------------|------------------------|
| `DEBUG_EXCEPTION_NONE` | There is no exception. |
|`DEBUG_EXCEPTION_CAN_BE_INTERCEPTED`|The exception is interceptable.<br /><br /> The timing of the exception may still be such that the debugger cannot intercept it. For example, if there is no managed code below the current callback or the exception event resulted from a just-in-time (JIT) attachment, the exception cannot be intercepted.|

## Remarks

 New values may be added to this enumeration in later versions, so you should prepare code that uses `CorDebugExceptionFlags` for unexpected values.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
