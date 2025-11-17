---
description: "Learn more about: ICorDebugSymbolProvider::GetObjectSize Method"
title: "ICorDebugSymbolProvider::GetObjectSize Method"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider::GetObjectSize Method

Returns the object size for an object based on its typespec signature.

## Syntax

```cpp
HRESULT GetObjectSize(
   [in] ULONG32 cbSignature,
   [in, size_is(cbSignature)]  BYTE typeSig[],
   [out] ULONG32 *pObjectSize
);
```

## Parameters

 `cbSignature`
 [in] The number of bytes in the typespec signature.

typeSig
 [in] The typespec signature.

 `pObjectSize`
 [out] A pointer to the size of the object.

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
