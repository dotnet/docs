---
description: "Learn more about: ICorDebugCode4::EnumerateVariableHomes Method"
title: "ICorDebugCode4::EnumerateVariableHomes Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode4.EnumerateVariableHomes"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode4::EnumerateVariableHomes"
helpviewer_keywords:
  - "EnumerateVariableHomes method [.NET debugging]"
  - "ICorDebugCode4::EnumerateVariableHomes method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode4::EnumerateVariableHomes Method

Gets an enumerator to the local variables and arguments in a function.

## Syntax

```cpp
HRESULT EnumerateVariableHomes(
    [out] ICorDebugVariableHomeEnum **ppEnum
);
```

## Parameters

 `ppEnum`
 A pointer to the address of an [ICorDebugVariableHomeEnum](icordebugvariablehomeenum-interface.md) interface object that is an enumerator for the local variables and arguments in a function.

## Remarks

 The [ICorDebugVariableHomeEnum](icordebugvariablehomeenum-interface.md) interface object is a standard enumerator derived from the "ICorDebugEnum" interface that allows you to enumerate [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects. The collection may include multiple [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects for the same slot or      argument index if they have different homes at different points in the      function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugCode4 Interface](icordebugcode4-interface.md)
