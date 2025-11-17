---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetPublicKeyToken Method"
title: "ICorDebugMergedAssemblyRecord::GetPublicKeyToken Method"
ms.date: "03/30/2017"
---
# ICorDebugMergedAssemblyRecord::GetPublicKeyToken Method

Gets the assembly's public key token.

## Syntax

```cpp
HRESULT GetPublicKeyToken(
   [in] ULONG32 cbPublicKeyToken,
   [out] ULONG32 *pcbPublicKeyToken,
   [out, size_is(cbPublicKeyToken), length_is(*pcbPublicKeyToken)] BYTE pbPublicKeyToken[]
);
```

## Parameters

 `cbPublicKeyToken`
 [in] The maximum number of bytes in the `pbPublicKeyToken` array.

 `pcbPublicKeyToken`
 [out] A pointer to the actual number of bytes written to the `pbPublicKeyToken` array.

 `pbPublicKeyToken`
 [out] A pointer to a byte array that contains the assembly's public key token.

## Remarks

An assembly's public key token is the last eight bytes of a SHA1 hash of its public key.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
