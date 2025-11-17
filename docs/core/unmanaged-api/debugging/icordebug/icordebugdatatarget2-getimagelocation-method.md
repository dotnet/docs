---
description: "Learn more about: ICorDebugDataTarget2::GetImageLocation Method"
title: "ICorDebugDataTarget2::GetImageLocation Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2::GetImageLocation Method

Returns the path of a module from the module's base address.

## Syntax

```cpp
HRESULT GetImageLocation(    [in] CORDB_ADDRESS baseAddress,
    [in] ULONG32 cchName,
    [out] ULONG32 *pcchName,
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]
);
```

## Parameters

 `baseAddress`
 [in] A [CORDB_ADDRESS](../../../../framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that represents the module's base address.

 `cchName`
 [in] The number of characters in the buffer that is to receive the module path.

 `pcchName`
 [out] A pointer to the number of characters written to the `szName` buffer.

 `szName`
 [out] The path of the module.

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
