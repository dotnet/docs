---
title: "ICorDebugProcess4::ProcessStateChanged Method"
ms.date: "02/07/2019"
api_name:
  - "ICorDebugProcess4::ProcessStateChanged"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess4::ProcessStateChanged"
helpviewer_keywords:
  - "ICorDebugProcess4::ProcessStateChanged method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# ICorDebugProcess4::ProcessStateChanged Method

Notifies the ICorDebug pipeline that the out of process debugger is continuing the debugee's execution.

## Syntax

```cpp
HRESULT ProcessStateChanged(
    [in] CorDebugStateChange change
);
```

## Parameters

 `eChange`\
[in] A member of the [CorDebugStateChange enumeration](cordebugstatechange-enumeration.md) describing a change in the process's execution state.

## Remarks

The provided method is part of the `ICorDebugProcess4` interface and corresponds to the fourth slot of the virtual method table.

## Requirements

 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

 **Header:** None

 **Library:** None
 
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [ICorDebugProcess4 Interface](icordebugprocess4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
