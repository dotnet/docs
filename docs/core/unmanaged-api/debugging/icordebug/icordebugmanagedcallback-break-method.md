---
description: "Learn more about: ICorDebugManagedCallback::Break Method"
title: "ICorDebugManagedCallback::Break Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.Break"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::Break"
helpviewer_keywords:
  - "Break method [.NET debugging]"
  - "ICorDebugManagedCallback::Break method [.NET debugging]"
topic_type:
  - "apiref"
---

# ICorDebugManagedCallback::Break Method

Notifies the debugger when a <xref:System.Reflection.Emit.OpCodes.Break> instruction in the code stream is executed.

## Syntax

```cpp
HRESULT Break (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread    *thread
);
```

## Parameters

`pAppDomain`\
[in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the break instruction.

`thread`\
[in] A pointer to an ICorDebugThread object that represents the thread that contains the break instruction.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
