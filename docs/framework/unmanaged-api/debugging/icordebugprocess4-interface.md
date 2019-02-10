---
title: "ICorDebugProcess4 Interface"
ms.date: "02/07/2019"
api_name:
  - "ICorDebugProcess4"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess4"
helpviewer_keywords:
  - "ICorDebugProcess4 interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# ICorDebugProcess4 Interface

Provides support for out of process execution control.

## Methods

| Method                                                                 | Description                                                                                             |
| ---------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| [ProcessStateChanged](icordebugprocess4-processstatechanged-method.md) | Notifies the ICorDebug pipeline that the out of process debugger is continuing the debugee's execution. |

## Remarks

This interface lives inside the runtime and isn't exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `E930C679-78AF-4953-8AB7-B0AABF0F9F80` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

**Header:** None

**Library:** None

**.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
