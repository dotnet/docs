---
description: "Learn more about: ICorDebugStaticFieldSymbol::GetSize Method"
title: "ICorDebugStaticFieldSymbol::GetSize Method"
ms.date: "03/30/2017"
---
# ICorDebugStaticFieldSymbol::GetSize Method

Gets the size in bytes of the static field.

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

- [ICorDebugStaticFieldSymbol Interface](icordebugstaticfieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
