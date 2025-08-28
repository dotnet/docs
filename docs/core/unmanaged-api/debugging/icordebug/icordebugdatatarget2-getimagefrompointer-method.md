---
description: "Learn more about: ICorDebugDataTarget2::GetImageFromPointer Method"
title: "ICorDebugDataTarget2::GetImageFromPointer Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2::GetImageFromPointer Method

Returns the module base address and size from an address in that module.

## Syntax

```cpp
HRESULT GetImageFromPointer(
   [in] CORDB_ADDRESS addr,
   [out] CORDB_ADDRESS *pImageBase,
   [out] ULONG32 *pSize
);
```

## Parameters

 `addr`
 A [CORDB_ADDRESS](../../../../framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that represents an address in a module.

 `pImageBase`
 [out] A [CORDB_ADDRESS](../../../../framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that represents the module's base address.

 `pSize`
 A pointer to the module size.

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
