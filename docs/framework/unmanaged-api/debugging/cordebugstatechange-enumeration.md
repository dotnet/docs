---
title: "CorDebugStateChange Enumeration"
ms.date: "02/07/2019"
api_name:
  - "CorDebugStateChange"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
ms.assetid: 1d4424ab-5143-4e50-a84a-ceeb4ddf3bba
topic_type:
  - "apiref"
---
# CorDebugStateChange Enumeration

Describes the amount of cached data that must be discarded based on changes to the process.

## Syntax

```cpp
typedef enum CorDebugStateChange
{
    PROCESS_RUNNING = 0x0000001,
    FLUSH_ALL       = 0x0000002,
} CorDebugStateChange;
```

## Members

| Member            | Description                                                              |
| ----------------- | ------------------------------------------------------------------------ |
| `PROCESS_RUNNING` | The process reached a new memory state via forward execution.            |
| `FLUSH_ALL`       | The process' memory may be arbitrarily different than it was previously. |

## Remarks

 A member of the `CorDebugStateChange` enumeration is provided as an argument when the debugger calls the `ProcessStateChanged` method either with [ICorDebugProcess4::ProcessStateChanged](icordebugprocess4-processstatechanged-method.md) or [ICorDebugProcess6::ProcessStateChanged](icordebugprocess6-processstatechanged-method.md)

## Requirements

 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
