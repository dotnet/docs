---
description: "Learn more about: ICorDebugProcess4::ProcessStateChanged Method"
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
  - "ICorDebugProcess4::ProcessStateChanged method [.NET debugging]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** None

 **Library:** None

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess4 Interface](icordebugprocess4-interface.md)
