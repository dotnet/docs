---
description: "Learn more about: ICorDebugDebugEvent::GetEventKind Method"
title: "ICorDebugDebugEvent::GetEventKind Method"
ms.date: "03/30/2017"
---
# ICorDebugDebugEvent::GetEventKind Method

Indicates what kind of event this `ICorDebugDebugEvent` object represents.

## Syntax

```cpp
HRESULT GetEventKind(
    [out]CorDebugDebugEventKind *pDebugEventKind
);
```

## Parameters

 pDebugEventKind
 A pointer to a [CorDebugDebugEventKind](cordebugdebugeventkind-enumeration.md) enumeration member that indicates the type of event.

## Remarks

 Based on the value of `pDebugEventKind`, you can call `QueryInterface` to get a more precise debug event interface that has additional data.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDebugEvent Interface](icordebugdebugevent-interface.md)
