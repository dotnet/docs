---
description: "Learn more about: ICorDebugVariableSymbol::GetSlotIndex Method"
title: "ICorDebugVariableSymbol::GetSlotIndex Method"
ms.date: "03/30/2017"
---
# ICorDebugVariableSymbol::GetSlotIndex Method

Gets the managed slot index of a local variable.

## Syntax

```cpp
HRESULT GetSlotIndex(
   [out] ULONG32 *pSlotIndex
);
```

## Parameters

 `pSlotIndex`
 [out] A pointer to the local variable's slot index.

## Return Value

 `S_OK` if successful. `E_FAIL` if the variable is a function argument.

## Remarks

 The managed slot index of a local variable can be used to retrieve the variable's metadata information

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugVariableSymbol Interface](icordebugvariablesymbol-interface.md)
