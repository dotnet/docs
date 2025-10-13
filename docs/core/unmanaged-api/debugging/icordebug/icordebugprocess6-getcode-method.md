---
description: "Learn more about: ICorDebugProcess6::GetCode Method"
title: "ICorDebugProcess6::GetCode Method"
ms.date: "03/30/2017"
---
# ICorDebugProcess6::GetCode Method

Gets information about the managed code at a particular code address.

## Syntax

```cpp
HRESULT GetCode(
    [in] CORDB_ADDRESS codeAddress,
    [out] ICorDebugCode **ppCode);
```

## Parameters

 `codeAddress`
 [in] A [CORDB_ADDRESS](../../../../framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that specifies the starting address of the managed code segment.

 `ppCode`
 [out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)
