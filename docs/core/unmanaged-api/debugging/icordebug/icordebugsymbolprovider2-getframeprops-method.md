---
description: "Learn more about: ICorDebugSymbolProvider2::GetFrameProps Method"
title: "ICorDebugSymbolProvider2::GetFrameProps Method"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider2::GetFrameProps Method

Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.

## Syntax

```cpp
HRESULT GetFrameProps(
   [in] ULONG32 codeRva,
   [out] ULONG32 *pCodeStartRva,
   [out] ULONG32 *pParentFrameStartRva
);
```

## Parameters

 `codeRva`
 [in] A code relative virtual address.

 `pCodeStartRva`
 [out] A pointer to the method's starting relative virtual address.

 `pParentFrameStartRva`
 [out] A pointer to the frame's starting relative virtual address.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugSymbolProvider2 Interface](icordebugsymbolprovider2-interface.md)
