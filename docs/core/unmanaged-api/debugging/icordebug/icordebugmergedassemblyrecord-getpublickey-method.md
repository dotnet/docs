---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetPublicKey Method"
title: "ICorDebugMergedAssemblyRecord::GetPublicKey Method"
ms.date: "03/30/2017"
---
# ICorDebugMergedAssemblyRecord::GetPublicKey Method

Gets the assembly's public key.

## Syntax

```cpp
HRESULT GetPublicKey(
   [in] ULONG32 cbPublicKey,
   [out] ULONG32 *pcbPublicKey,
   [out, size_is(cbPublicKey), length_is(*pcbPublicKey)] BYTE pbPublicKey[]);
```

## Parameters

 `cbPublicKey`
 [in] The maximum number of bytes in the `pbPublicKey` array.

 `pcbPublicKey`
 [out] A pointer to the actual number of bytes written to the `pbPublicKey` array.

 `pbPublicKey`
 [out] A pointer to a byte array that contains the assembly's public key.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
