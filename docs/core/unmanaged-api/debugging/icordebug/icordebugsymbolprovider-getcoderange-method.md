---
description: "Learn more about: ICorDebugSymbolProvider::GetCodeRange Method"
title: "ICorDebugSymbolProvider::GetCodeRange Method"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider::GetCodeRange Method

Gets the method start address and size given a relative virtual address (RVA) in a method.

## Syntax

```cpp
HRESULT GetCodeRange(
   [in] ULONG32 codeRva,
   [out] ULONG32* pCodeStartAddress,
   [out] ULONG32* pCodeSize
);
```

## Parameters

 `codeRva`
 [in] The relative virtual address (RVA) in a method.

 `pCodeStartAddress`
 [out] A pointer to the starting address of the method.

 `pCodeSize`
 A pointer to the method code size (the number of bytes of the method's code).

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
