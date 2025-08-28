---
description: "Learn more about: ICorDebugLoadedModule::GetName Method"
title: "ICorDebugLoadedModule::GetName Method"
ms.date: "03/30/2017"
---
# ICorDebugLoadedModule::GetName Method

Gets the name of the loaded module.

## Syntax

```cpp
HRESULT GetName(
   [in] ULONG32 cchName,
   [out] ULONG32 *pcchName,
   [out, size_is(cchName),
   length_is(*pcchName)] WCHAR szName[]
);
```

## Parameters

 `cchName`
 [in] The number of characters in the `szName` buffer.

 `pcchName`
 [out] A pointer to the number of characters actually written to the `szName` buffer.

 `szName`
 [out] An array of characters that contain the name of the loaded module.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugLoadedModule Interface](icordebugloadedmodule-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
