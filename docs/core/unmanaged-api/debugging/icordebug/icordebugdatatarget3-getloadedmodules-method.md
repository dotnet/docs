---
description: "Learn more about: ICorDebugDataTarget3::GetLoadedModules Method"
title: "ICorDebugDataTarget3::GetLoadedModules Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget3::GetLoadedModules Method

Gets a list of the modules that have been loaded so far.

## Syntax

```cpp
HRESULT GetLoadedModules(
   [in] ULONG32 cRequestedModules,
   [out] ULONG32 *pcFetchedModules,
   [out, size_is(cRequestedModules), length_is(*pcFetchedModules)] ICorDebugLoadedModule *pLoadedModules[]
);
```

## Parameters

 `cRequestedModules`
 [in] The number of modules for which information is requested.

 `pcFetchedModules`
 [out] A pointer to the number of modules about which information was returned.

 `pLoadedModules`
 [out] A pointer to an array of [ICorDebugLoadedModule](icordebugloadedmodule-interface.md) objects that provide information about loaded modules.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDataTarget3 Interface](icordebugdatatarget3-interface.md)
