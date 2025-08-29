---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetIndex Method"
title: "ICorDebugMergedAssemblyRecord::GetIndex Method"
ms.date: "03/30/2017"
---
# ICorDebugMergedAssemblyRecord::GetIndex Method

Gets the assembly's prefix index.

## Syntax

```cpp
HRESULT GetIndex(
   [out] ULONG32 *pIndex
);
```

## Parameters

 `pIndex`
 [out] A pointer to the prefix index.

## Remarks

The prefix index is used to prevent name collisions in the merged metadata type names.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
