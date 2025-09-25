---
description: "Learn more about: ICorDebugFunction::GetLocalVarSigToken Method"
title: "ICorDebugFunction::GetLocalVarSigToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetLocalVarSigToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetLocalVarSigToken"
helpviewer_keywords:
  - "ICorDebugFunction::GetLocalVarSigToken method [.NET debugging]"
  - "GetLocalVarSigToken method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetLocalVarSigToken Method

Gets the metadata token for the local variable signature of the function that is represented by this ICorDebugFunction instance.

## Syntax

```cpp
HRESULT GetLocalVarSigToken (
    [out] mdSignature *pmdSig
);
```

## Parameters

 `pmdSig`
 [out] A pointer to the `mdSignature` token for the local variable signature of this function, or `mdSignatureNil`, if this function has no local variables.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
