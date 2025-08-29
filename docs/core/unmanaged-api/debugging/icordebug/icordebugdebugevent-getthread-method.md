---
description: "Learn more about: ICorDebugDebugEvent::GetThread Method"
title: "ICorDebugDebugEvent::GetThread Method"
ms.date: "03/30/2017"
---
# ICorDebugDebugEvent::GetThread Method

Gets the thread on which the event occurred.

## Syntax

```cpp
HRESULT GetThread(
        [out]ICorDebugThread **ppThread
);
```

## Parameters

ppThread
 [out] A pointer to the address of an ICorDebugThread object that represents the thread on which the event occurred.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDebugEvent Interface](icordebugdebugevent-interface.md)
