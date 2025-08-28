---
description: "Learn more about: ICorDebugExceptionDebugEvent::GetFlags Method"
title: "ICorDebugExceptionDebugEvent::GetFlags Method"
ms.date: "03/30/2017"
---
# ICorDebugExceptionDebugEvent::GetFlags Method

Gets a flag that indicates whether the exception can be intercepted.

## Syntax

```cpp
HRESULT GetFlags(
   [out] CorDebugExceptionFlags *pdwFlags
);
```

## Parameters

 `pdwFlags`
 [out] A pointer to a [CorDebugExceptionFlags](cordebugexceptionflags-enumeration.md) value that indicates whether the exception can be intercepted.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugExceptionDebugEvent Interface](icordebugexceptiondebugevent-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
