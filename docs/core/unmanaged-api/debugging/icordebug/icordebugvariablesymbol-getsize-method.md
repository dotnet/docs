---
description: "Learn more about: ICorDebugVariableSymbol::GetSize Method"
title: "ICorDebugVariableSymbol::GetSize Method"
ms.date: "03/30/2017"
---
# ICorDebugVariableSymbol::GetSize Method

Gets the size of a variable in bytes.

## Syntax

```cpp
HRESULT GetSize(
   [out] ULONG32 *pcbValue
);
```

## Parameters

 `pcbValue`
A pointer to a 32-bit unsigned integer containing the size of the variable.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugVariableSymbol Interface](icordebugvariablesymbol-interface.md)
