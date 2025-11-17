---
description: "Learn more about: CorDebugExceptionUnwindCallbackType Enumeration"
title: "CorDebugExceptionUnwindCallbackType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugExceptionUnwindCallbackType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugExceptionUnwindCallbackType"
helpviewer_keywords:
  - "CorDebugExceptionUnwindCallbackType enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugExceptionUnwindCallbackType Enumeration

Indicates the event that is being signaled by the callback during the unwind phase.

## Syntax

```cpp
typedef enum CorDebugExceptionUnwindCallbackType {
    DEBUG_EXCEPTION_UNWIND_BEGIN = 1,
    DEBUG_EXCEPTION_INTERCEPTED  = 2
} CorDebugExceptionUnwindCallbackType;
```

## Members

|Member|Description|
|------------|-----------------|
|`DEBUG_EXCEPTION_UNWIND_BEGIN`|The beginning of the unwind process.|
|`DEBUG_EXCEPTION_INTERCEPTED`|The exception was intercepted.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
