---
description: "Learn more about: ICorDebugSymbolProvider::GetMethodProps Method"
title: "ICorDebugSymbolProvider::GetMethodProps Method"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider::GetMethodProps Method

Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.

## Syntax

```cpp
HRESULT GetMethodProps(
   [in]  ULONG32 codeRva,
   [out] mdToken *pMethodToken,
   [out] ULONG32 *pcGenericParams,
   [in]  ULONG32 cbSignature,
   [out] ULONG32 *pcbSignature,
   [out, size_is(cbSignature), length_is(*pcbSignature)] BYTE signature[]
);
```

## Parameters

 `codeRVA`
 [in] A relative virtual address in the method about which information is to be retrieved.

 `pMethodToken`
 [out] A pointer to the method's metadata token.

 `pcGenericParams`
 [out] A pointer to the number of generic parameters associated with this method.

 `cbSignature`
 [in] The size of the `signature` array. See the Remarks section.

 `pcbSignature`
 [out] A pointer to the size of the returned `signature` array.

 `signature`
 [out] A buffer that holds the typespec signatures of all generic parameters.

## Remarks

To get the required size of the method's `signature` array, set the `cbSignature` argument to 0 and `signature` to **null**. When the method returns, `pcbSignature` will contain the number of bytes required for the `signature` array.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [GetTypeProps Method](icordebugsymbolprovider-gettypeprops-method.md)
- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
