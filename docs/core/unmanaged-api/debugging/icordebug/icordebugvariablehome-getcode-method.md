---
description: "Learn more about: ICorDebugVariableHome::GetCode Method"
title: "ICorDebugVariableHome::GetCode Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetCode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetCode"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetCode method [.NET debugging]"
  - "GetCode method, ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome::GetCode Method

Gets the "ICorDebugCode" instance that contains this [ICorDebugVariableHome](icordebugvariablehome-interface.md) object.

## Syntax

```cpp
HRESULT GetCode(
    [out] ICorDebugCode **ppCode
);
```

## Parameters

 `ppCode`
 [out] A pointer to the address of the "ICorDebugCode" instance that contains this [ICorDebugVariableHome](icordebugvariablehome-interface.md) object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
