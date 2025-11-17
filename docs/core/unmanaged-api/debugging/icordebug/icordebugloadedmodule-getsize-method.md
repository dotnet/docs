---
description: "Learn more about: ICorDebugLoadedModule::GetSize Method"
title: "ICorDebugLoadedModule::GetSize Method"
ms.date: "03/30/2017"
---
# ICorDebugLoadedModule::GetSize Method

Gets the size in bytes of the loaded module.

## Syntax

```cpp
HRESULT GetSize(
   [out] ULONG32 *pcBytes
);
```

## Parameters

 `pcBytes`
 [out] A pointer to the number of bytes in the loaded module.

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
