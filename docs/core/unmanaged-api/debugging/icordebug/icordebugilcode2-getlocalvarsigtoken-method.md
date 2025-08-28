---
description: "Learn more about: ICorDebugILCode2::GetLocalVarSigToken Method"
title: "ICorDebugILCode2::GetLocalVarSigToken Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugILCode2.GetLocalVarSigToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugILCode2::GetLocalVarSigToken Method

[Supported in the .NET Framework 4.5.2 and later versions]

 Gets the metadata token for the local variable signature for the function that is represented by this instance.

## Syntax

```cpp
HRESULT GetLocalVarSigToken(
   [out] mdSignature *pmdSig
);
```

## Parameters

 `pmdSig`
 [out] A pointer to the `mdSignature` token for the local variable signature for this function, or `mdSignatureNil` if there is no signature (that is, if the function doesn't have any local variables).

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugILCode2 Interface](icordebugilcode2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
