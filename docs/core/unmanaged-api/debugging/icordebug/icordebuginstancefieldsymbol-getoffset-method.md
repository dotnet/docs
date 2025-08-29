---
description: "Learn more about: ICorDebugInstanceFieldSymbol::GetOffset Method"
title: "ICorDebugInstanceFieldSymbol::GetOffset Method"
ms.date: "03/30/2017"
---
# ICorDebugInstanceFieldSymbol::GetOffset Method

Gets the offset in bytes of this instance field in its parent class.

## Syntax

```cpp
HRESULT GetOffset(
   [out] ULONG32 *pcbOffset
);
```

## Parameters

 `pcbOffset`
A pointer to the number of bytes that this instance field is offset in its parent class.

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
