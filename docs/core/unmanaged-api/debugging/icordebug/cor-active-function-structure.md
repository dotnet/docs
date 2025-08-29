---
description: "Learn more about: COR_ACTIVE_FUNCTION Structure"
title: "COR_ACTIVE_FUNCTION Structure"
ms.date: "03/30/2017"
api_name:
  - "COR_ACTIVE_FUNCTION"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_ACTIVE_FUNCTION"
helpviewer_keywords:
  - "COR_ACTIVE_FUNCTION structure [.NET debugging]"
topic_type:
  - "apiref"
---
# COR_ACTIVE_FUNCTION Structure

Contains information about the functions that are currently active in a thread's frames. This structure is used by the [ICorDebugThread2::GetActiveFunctions](icordebugthread2-getactivefunctions-method.md) method.

## Syntax

```cpp
typedef struct  _COR_ACTIVE_FUNCTION {
    ICorDebugAppDomain   *pAppDomain;
    ICorDebugModule      *pModule;
    ICorDebugFunction2   *pFunction;
    ULONG32              ilOffset;
    ULONG32              flags;
} COR_ACTIVE_FUNCTION;
```

## Members

| Member       | Description                                                      |
|--------------|------------------------------------------------------------------|
| `pAppDomain` | Pointer to the application domain owner of the `ilOffset` field. |
| `pModule`    | Pointer to the module owner of the `ilOffset` field.             |
| `pFunction`  | Pointer to the function owner of the `ilOffset` field.           |
| `ilOffset`   | The common intermediate language (CIL) offset of the frame.      |
| `flags`      | Reserved for future extensibility.                               |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
