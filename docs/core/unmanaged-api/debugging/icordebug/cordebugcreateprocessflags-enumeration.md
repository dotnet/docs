---
description: "Learn more about: CorDebugCreateProcessFlags Enumeration"
title: "CorDebugCreateProcessFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugCreateProcessFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugCreateProcessFlags"
helpviewer_keywords:
  - "CorDebugCreateProcessFlags enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugCreateProcessFlags Enumeration

Provides additional debugging options that can be used in a call to the [ICorDebug::CreateProcess](icordebug-createprocess-method.md) method.

## Syntax

```cpp
typedef enum CorDebugCreateProcessFlags {
    DEBUG_NO_SPECIAL_OPTIONS    = 0x0000
} CorDebugCreateProcessFlags;
```

## Members

| Member                     | Description                 |
|----------------------------|-----------------------------|
| `DEBUG_NO_SPECIAL_OPTIONS` | No special options are set. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
