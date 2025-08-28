---
description: "Learn more about: ICorDebugDataTarget2::GetSymbolProviderForImage Method"
title: "ICorDebugDataTarget2::GetSymbolProviderForImage Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2::GetSymbolProviderForImage Method

Returns the symbol-provider for a module from the base address of that module.

## Syntax

```cpp
HRESULT GetSymbolProviderForImage(
    [in] CORDB_ADDRESS imageBaseAddress,
    [out] ICorDebugSymbolProvider **ppSymProvider
);
```

## Parameters

 `imageBaseAddress`
 [in] A [CORDB_ADDRESS](../common-data-types-unmanaged-api-reference.md) value that represents the base address of a module.

 `ppSymProvider`
 [out] A pointer to the address of an [ICorDebugSymbolProvider](icordebugsymbolprovider-interface.md) object.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
