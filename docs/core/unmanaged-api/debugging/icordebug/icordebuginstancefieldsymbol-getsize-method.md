---
description: "Learn more about: ICorDebugInstanceFieldSymbol::GetSize Method"
title: "ICorDebugInstanceFieldSymbol::GetSize Method"
ms.date: "03/30/2017"
---
# ICorDebugInstanceFieldSymbol::GetSize Method

Gets the size in bytes of the instance field.

## Syntax

```cpp
HRESULT GetSize(
   [out] ULONG32 *pcbSize
);
```

## Parameters

 `pcbSize`
 [out] A pointer to length of the field.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugInstanceFieldSymbol Interface](icordebuginstancefieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
