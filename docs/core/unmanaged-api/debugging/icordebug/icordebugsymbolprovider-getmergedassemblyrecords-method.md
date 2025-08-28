---
description: "Learn more about: ICorDebugSymbolProvider::GetMergedAssemblyRecords Method"
title: "ICorDebugSymbolProvider::GetMergedAssemblyRecords Method"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider::GetMergedAssemblyRecords Method

Gets the symbol records for all the merged assemblies.

## Syntax

```cpp
HRESULT GetMergedAssemblyRecords(
   [in] ULONG32 cRequestedRecords,
   [out] ULONG32 *pcFetchedRecords,
   [out, size_is(cRequestedRecords), length_is(*pcFetchedRecords)] ICorDebugMergedAssemblyRecord *pRecords[]
);
```

## Parameters

 `cRequestedRecords`
 [in] The number of symbol records requested.

 `pcFetchedRecords`
 [out] A pointer to the number of symbol records retrieved by the method.

 `pRecords`
 A pointer to an array of [ICorDebugMergedAssemblyRecord](icordebugmergedassemblyrecord-interface.md) objects.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
