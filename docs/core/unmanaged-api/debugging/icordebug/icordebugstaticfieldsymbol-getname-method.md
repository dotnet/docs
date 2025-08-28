---
description: "Learn more about: ICorDebugStaticFieldSymbol::GetName Method"
title: "ICorDebugStaticFieldSymbol::GetName Method"
ms.date: "03/30/2017"
---
# ICorDebugStaticFieldSymbol::GetName Method

Gets the name of the static field.

## Syntax

```cpp
HRESULT GetName(
   [in] ULONG32 cchName,
   [out] ULONG32 *pcchName,
   [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]
);
```

## Parameters

 `cchName`
 [in] The number of characters in the `szName` buffer.

 `pcchName`
 [out] A pointer to the number of characters actually written to the `szName` buffer.

 `szName`
 [out] A character array that stores the returned name.

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
