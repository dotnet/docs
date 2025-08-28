---
description: "Learn more about: ICorDebugMDA::GetFlags Method"
title: "ICorDebugMDA::GetFlags Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA.GetFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA::GetFlags"
helpviewer_keywords:
  - "ICorDebugMDA::GetFlags method [.NET debugging]"
  - "GetFlags method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMDA::GetFlags Method

Gets the flags associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).

## Syntax

```cpp
HRESULT GetFlags (
    [in] CorDebugMDAFlags *pFlags
);
```

## Parameters

 `pFlags`
 [in] A bitwise combination of the [CorDebugMDAFlags](cordebugmdaflags-enumeration.md) enumeration values that specify the settings of the flags for this MDA.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnosing Errors with Managed Debugging Assistants](../../debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
