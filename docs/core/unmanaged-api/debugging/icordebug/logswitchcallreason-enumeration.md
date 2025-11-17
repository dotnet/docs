---
description: "Learn more about: LogSwitchCallReason Enumeration"
title: "LogSwitchCallReason Enumeration"
ms.date: "03/30/2017"
api_name:
  - "LogSwitchCallReason"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "LogSwitchCallReason"
helpviewer_keywords:
  - "LogSwitchCallReason enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# LogSwitchCallReason Enumeration

Indicates the operation that was performed on a debugging/tracing switch.

## Syntax

```cpp
typedef enum LogSwitchCallReason {
    SWITCH_CREATE,
    SWITCH_MODIFY,
    SWITCH_DELETE
} LogSwitchCallReason;
```

## Members

| Member          | Description                              |
|-----------------|------------------------------------------|
| `SWITCH_CREATE` | A debugging/tracing switch was created.  |
| `SWITCH_MODIFY` | A debugging/tracing switch was modified. |
| `SWITCH_DELETE` | A debugging/tracing switch was deleted.  |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
