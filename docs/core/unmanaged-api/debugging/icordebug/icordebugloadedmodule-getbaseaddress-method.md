---
description: "Learn more about: ICorDebugLoadedModule::GetBaseAddress Method"
title: "ICorDebugLoadedModule::GetBaseAddress Method"
ms.date: "03/30/2017"
---
# ICorDebugLoadedModule::GetBaseAddress Method

Gets the base address of the loaded module.

## Syntax

```cpp
HRESULT GetBaseAddress(
   [out] CORDB_ADDRESS *pAddress
);
```

## Parameters

 `pAddress`
 [out] A pointer to the base address of the loaded module.

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
