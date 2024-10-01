---
description: "Learn more about: ICorDebugDataTarget2::GetSymbolProviderForImage Method"
title: "ICorDebugDataTarget2::GetSymbolProviderForImage Method"
ms.date: "03/30/2017"
ms.assetid: b7c0a2f0-e904-43b3-98e1-d669e8a589e8
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
